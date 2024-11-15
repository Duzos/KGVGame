using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FirstProject.games.form.impl.Snake
{
    public class Snake : FormGame // followed this tutorial https://youtu.be/uzAXxFBbVoE
    {
        public int Rows { get; }
        public int Cols { get; }
        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }
        private SnakeForm form;

        private readonly LinkedList<Direction> DirectionChanges;
        private readonly LinkedList<Position> SnakePositions;
        private readonly Random Random = new Random();

        public Snake(int rows, int cols) : base("snake")
        {
            SnakePositions = new LinkedList<Position>();
            DirectionChanges = new LinkedList<Direction>();
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[Rows, Cols];
            Dir = Direction.RIGHT;

            AddSnake();
            AddFood();
        }
        public static int QuerySize(Game game, int min, int max)
        {
            string response = "";

            Util.InputBox(game.Name(), "Size? ( " + min + " -> " + max + " )", ref response);

            bool success = int.TryParse(response, out int result);

            if (!success || (result < min) || result > max) result = min;

            return result;
        }

        public override string Name()
        {
            return "Snake";
        }

        protected override Form CreateForm()
        {
            if (form == null)
            {
                form = new SnakeForm(this);
            }

            return form;
        }

        protected override void OnRestart()
        {
            Fill(GridValue.EMPTY);

            SnakePositions.Clear();
            AddSnake();
            AddFood();

            Score = 0;
            GameOver = false;
            Dir = Direction.RIGHT;

            StartGameLoop();
        }

        protected override bool Run()
        {
            return !GameOver;
        }

        private void StartGameLoop()
        {
            var task = Task.Run(async () =>
            {
                await GameLoop();
            });
        }
        private async Task GameLoop()
        {
            while (!GameOver)
            {
                await Task.Delay(150);

                Move();
                form.Invalidate();
            }
        }

        private void Fill(GridValue value)
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Grid[r, c] = value;
                }
            }
        }

        private void AddSnake()
        {
            int r = Rows / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.SNAKE;
                SnakePositions.AddFirst(new Position(r, c));
            }
        }
        private IEnumerable<Position> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == GridValue.EMPTY)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = EmptyPositions().ToList();

            if (empty.Count == 0)
            {
                Console.WriteLine("No empty positions available to place food.");
                return;
            }

            Position pos = empty[Random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.FOOD;
            Console.WriteLine($"Food placed at position: ({pos.Row}, {pos.Col})");
        }

        public Position Head()
        {
            return SnakePositions.First.Value;
        }
        public Position Tail()
        {
            return SnakePositions.Last.Value;
        }

        public IEnumerable<Position> Positions()
        {
            return SnakePositions;
        }

        private void AddHead(Position pos)
        {
            SnakePositions.AddFirst(pos);
            Grid[pos.Row, pos.Col] = GridValue.SNAKE;
        }
        private void RemoveTail()
        {
            Position tail = Tail();
            SnakePositions.RemoveLast();
            Grid[tail.Row, tail.Col] = GridValue.EMPTY;
        }
        public void ChangeDirection(Direction dir)
        {
            if (!CanChangeDirection(dir)) return;

            DirectionChanges.AddLast(dir);
        }
        private Direction getLastDirection()
        {
            if (DirectionChanges.Count == 0)
            {
                return Dir;
            }

            return DirectionChanges.Last.Value;
        }
        private bool CanChangeDirection(Direction newDir)
        {
            if (DirectionChanges.Count == 2) return false;

            Direction last = getLastDirection();
            return last != newDir && newDir != last.Opposite();
        }

        private bool Outside(Position pos)
        {
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
        }
        private GridValue WillHit(Position head)
        {
            if (Outside(head)) return GridValue.OUTSIDE;

            if (head == Tail()) return GridValue.EMPTY;

            return Grid[head.Row, head.Col];
        }

        public void Move()
        {
            if (DirectionChanges.Count > 0)
            {
                Dir = DirectionChanges.First.Value;
                DirectionChanges.RemoveFirst();
            }

            Position next = Head().Translate(Dir);
            GridValue hit = WillHit(next);

            if (hit == GridValue.SNAKE || hit == GridValue.OUTSIDE)
            {
                GameOver = true;
                return;
            }

            AddHead(next);

            if (hit != GridValue.FOOD)
            {
                RemoveTail();
            }
            else
            {
                Score++;
                AddFood();
            }
        }
    }
}
