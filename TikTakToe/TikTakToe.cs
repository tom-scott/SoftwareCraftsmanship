using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TikTakToeGame
{
    public class TikTakToe
    {
        private readonly Symbols[,] board = new Symbols[3,3];
        private Symbols previousMoveSymbol = Symbols.Empty;

        public GameResult Winner()
        {
            return GameResult.None;
        }

        public void Play(Row row, Column column)
        {
            var currentMoveSymbol = Symbols.X;

            if (previousMoveSymbol == Symbols.X)
            {
                currentMoveSymbol = Symbols.O;
            }

            board[(int)row, (int)column] = currentMoveSymbol;

            previousMoveSymbol = currentMoveSymbol;
        }

        public Symbols SymbolAt(Row row, Column column)
        {
            return board[(int) row, (int)column];
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
            return (board != null ? board.GetHashCode() : 0);
        }

        protected bool Equals(TikTakToe other)
        {
            var columnsIndexes = Enumerable.Range(0, 3);
            var rowsIndexes = Enumerable.Range(0, 3);

            return AreAllSymbolsEqual(rowsIndexes, columnsIndexes, other);
        }

        private bool AreAllSymbolsEqual(IEnumerable<int> rowsIndexes, IEnumerable<int> columnsIndexes, TikTakToe other)
        {
            return (
                from columnIndex in columnsIndexes
                from rowIndex in rowsIndexes
                select SymbolEqualsAt(rowIndex, columnIndex, other))
                .All(equal => equal);
        }

        private bool SymbolEqualsAt(int rowIndex, int columnIndex, TikTakToe other)
        {
            var symbol = (int) board[rowIndex, columnIndex];
            var otherSymbol = (int) other.board[rowIndex, columnIndex];
            var areSymbolEqual = symbol == otherSymbol;
            return areSymbolEqual;
        }
    }

    public enum Symbols
    {
        Empty,
        X,
        O
    }

    public enum GameResult
    {
        None
    }
}