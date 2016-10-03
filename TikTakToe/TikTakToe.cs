using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TikTakToeGame
{
    public class TikTakToe
    {
        private readonly Move[,] state = new Move[3,3];

        public TikTakToe()
        {
            var columns = Enumerable.Range(0, 2);
            var rows = Enumerable.Range(0, 2);

            foreach (var column in columns)
            {
                foreach (var row in rows)
                {
                    state[row, column] = Move.Empty;
                }
            }
        }
        
        protected bool Equals(TikTakToe other)
        {
            var columns = Enumerable.Range(0, 3);
            var rows = Enumerable.Range(0, 3);
            foreach (int col in columns)
                foreach (var row in rows)
                {
                    var stateMove = (int) state[row, col];
                    var otherMove = (int) other.state[row, col];
                    var areEqual = stateMove == otherMove;
                    if (!areEqual)
                    {
                        return false;
                    }
                }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TikTakToe) obj);
        }

        public override int GetHashCode()
        {
            return (state != null ? state.GetHashCode() : 0);
        }

        public GameResult Winner()
        {
            return GameResult.None;
        }

        public void Play(Row row, Column column)
        {
            state[(int)row, (int)column] = Move.ContainsX;
        }
    }

    internal enum Move
    {
        Empty,
        ContainsX,
        ContainsO
    }

    public enum GameResult
    {
        None
    }
}