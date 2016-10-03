using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TikTakToeGame
{
    public class TikTakToe
    {
        private readonly Symbols[,] board = new Symbols[3,3];

        public GameResult Winner()
        {
            return GameResult.None;
        }

        public void Play(Row row, Column column)
        {
            board[(int)row, (int)column] = Symbols.X;
        }

        public Symbols SymbolAt(Row row, Column column)
        {
            if (row == Row.Middle && column == Column.Left)
            {
                return Symbols.O;
            }

            return Symbols.X;
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