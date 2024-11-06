using System.Collections.Generic;

namespace FirstProject.games.form.impl.Snake
{
    public class Direction
    {
        public static readonly Direction UP = new Direction(-1, 0);
        public static readonly Direction DOWN = new Direction(1, 0);
        public static readonly Direction LEFT = new Direction(0, -1);
        public static readonly Direction RIGHT = new Direction(0, 1);

        public int RowOffset { get; }
        public int ColOffset { get; }

        private Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }

        public Direction Opposite()
        {
            return new Direction(-RowOffset, -ColOffset);
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   RowOffset == direction.RowOffset &&
                   ColOffset == direction.ColOffset;
        }

        public override int GetHashCode()
        {
            int hashCode = -1482510490;
            hashCode = hashCode * -1521134295 + RowOffset.GetHashCode();
            hashCode = hashCode * -1521134295 + ColOffset.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }
    }
}
