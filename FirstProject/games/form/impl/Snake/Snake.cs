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

        private readonly LinkedList<Position> SnakePositions;
        private readonly Random Random = new Random();

        public Snake(int rows, int cols) : base("snake")
        {
            SnakePositions = new LinkedList<Position>();
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[Rows, Cols];
            Dir = Direction.RIGHT;

            AddSnake();
            AddFood();
        }

        public override string Name()
        {
            return "Snake";
        }

        protected override Form CreateForm()
        {
            return new SnakeForm(this);
        }

        protected override void OnRestart()
        {
            SnakePositions.Clear();
            Score = 0;
            GameOver = false;
            Dir = Direction.RIGHT;

            var task = Task.Run(async () =>
            {

 
                await GameLoop();
            });
        }

        private async Task GameLoop()
        {
            while (!GameOver)
            {
                await Task.Delay(100);

                Move();
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

            if (empty.Count == 0) return;

            Position pos = empty[Random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.FOOD;
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
            Dir = dir;
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
