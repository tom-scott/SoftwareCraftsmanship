using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TikTakToeGame
{
    public class TikTakToe
    {
        private readonly Move[,] state = new Move[3,3];
        
        protected bool Equals(TikTakToe other)
        {
            var columns = Enumerable.Range(0, 2);
            var rows = Enumerable.Range(0, 2);
            foreach (int col in columns)
                foreach (var row in rows)
                {
                    var areEqual = 
                        state[row, col] == other.state[row, col];
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