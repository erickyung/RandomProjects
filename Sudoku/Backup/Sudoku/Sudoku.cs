using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SudokuPuzzle
{
    public class Sudoku
    {
        private int _Size = 9;
        private int _BoxSize = 3;
        private SudokuCell[,] _Problem = null;
        private SudokuCell[,] _Solution = null;

        #region Constructors
        public Sudoku()
        {
            this.PreparePuzzle();
        }

        public Sudoku(int size)
        {
            if (size == (int)Math.Pow(((int)Math.Sqrt(size)), 2.00))
            {
                this._Size = size;
                this._BoxSize = (int)Math.Sqrt(this._Size);
                
                this.PreparePuzzle();
            }
            else
            {
                throw new Exception("Invalid Sudoku Puzzle Size.");
            }
        }
        #endregion

        public bool IsSolved()
        {
            for (int y = 0; y < this._Size; y++)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Solve()
        {
            bool _Change = true;

            while (!this.IsSolved() && _Change)
            {
                _Change = false;

                // look for single pencil marks in box/row/col
                _Change = this.CheckForSinglePencilMarks();
                if (_Change) continue;

                // look for locked candidates in box
                _Change = this.CheckForLockedCandidatesInBoxPencilMarks();
                if (_Change) continue;

                // look for locked candidates in lines
                _Change = this.CheckForLockedCandidatesInLinesPencilMarks();
                if (_Change) continue;
            }
        }

        #region Fill all possible pencil marks
        public void FillPossiblePencilMarks()
        {
            for (int y = 0; y < this._Size; y++)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        for (int i = 1; i <= this._Size; i++)
                        {
                            if (!this.CheckBox(new CellCoordinate(x, y), i) &&
                                !this.CheckHorizontalLine(new CellCoordinate(x, y), i) &&
                                !this.CheckVerticalLine(new CellCoordinate(x, y), i))
                            {
                                this._Solution[y, x].AddPencilMark(i);
                            }
                        }
                    }
                }
            }
        }

        private bool CheckBox(CellCoordinate cell, int number)
        {
            CellCoordinate boxcoordinate = this.GetBoxCoordinate(cell);
            for (int y = (boxcoordinate.Y * this._BoxSize); y < (boxcoordinate.Y * this._BoxSize) + this._BoxSize; y++)
            {
                for (int x = (boxcoordinate.X * this._BoxSize); x < (boxcoordinate.X * this._BoxSize) + this._BoxSize; x++)
                {
                    if ((x != cell.X) || (y != cell.Y))
                    {
                        if (this._Solution[y, x].IsFilled())
                        {
                            if (this._Solution[y, x].Number == number)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckHorizontalLine(CellCoordinate cell, int number)
        {
            for (int x = 0; x < this._Size; x++)
            {
                if (x != cell.X)
                {
                    if (this._Solution[cell.Y, x].IsFilled())
                    {
                        if (this._Solution[cell.Y, x].Number == number)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckVerticalLine(CellCoordinate cell, int number)
        {
            for (int y = 0; y < this._Size; y++)
            {
                if (y != cell.Y)
                {
                    if (this._Solution[y, cell.X].IsFilled())
                    {
                        if (this._Solution[y, cell.X].Number == number)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion

        #region Single pencil marks in box/row/col
        public bool CheckForSinglePencilMarks()
        {
            bool _Change = false;

            for (int y = 0; y < this._Size; y++)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        if (this._Solution[y, x].PencilMarks.Count == 1)
                        {
                            Array pencilmark = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                            
                            _Change = true;

                            this._Solution[y, x].Number = this.ConvertToNumber(pencilmark.GetValue(0).ToString());
                            if (this.CleanSinglePencilMarks(new CellCoordinate(x, y), this._Solution[y, x].Number))
                            {
                                _Change = true;
                            }
                            continue;
                        }

                        Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                        for (int p = 0; p < pencilmarks.Length; p++)
                        {
                            if (!this.CheckBoxForSinglePencilMarks(new CellCoordinate(x, y), this.ConvertToNumber(pencilmarks.GetValue(p).ToString())) ||
                                !this.CheckHorizontalLineForSinglePencilMarks(new CellCoordinate(x, y), this.ConvertToNumber(pencilmarks.GetValue(p).ToString())) ||
                                !this.CheckVerticalLineForSinglePencilMarks(new CellCoordinate(x, y), this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                            {
                                _Change = true;

                                this._Solution[y, x].Number = this.ConvertToNumber(pencilmarks.GetValue(p).ToString());
                                if (this.CleanSinglePencilMarks(new CellCoordinate(x, y), this._Solution[y, x].Number))
                                {
                                    _Change = true;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return _Change;
        }

        public bool CleanSinglePencilMarks(CellCoordinate cell, int number)
        {
            bool _Change = false;

            for (int x = 0; x < this._Size; x++)
            {
                if (this._Solution[cell.Y, x].IsEmpty())
                {
                    if (x != cell.X)
                    {
                        if (this._Solution[cell.Y, x].ContainPencilMark(number))
                        {
                            _Change = true;
                        }
                        this._Solution[cell.Y, x].RemovePencilMark(number);
                    }
                }
            }

            for (int y = 0; y < this._Size; y++)
            {
                if (this._Solution[y, cell.X].IsEmpty())
                {
                    if (y != cell.Y)
                    {
                        if (this._Solution[y, cell.X].ContainPencilMark(number))
                        {
                            _Change = true;
                        }
                        this._Solution[y, cell.X].RemovePencilMark(number);
                    }
                }
            }

            CellCoordinate boxcoordinate = this.GetBoxCoordinate(cell);
            for (int y = (boxcoordinate.Y * this._BoxSize); y < (boxcoordinate.Y * this._BoxSize) + this._BoxSize; y++)
            {
                for (int x = (boxcoordinate.X * this._BoxSize); x < (boxcoordinate.X * this._BoxSize) + this._BoxSize; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        if ((x != cell.X) && (y != cell.Y))
                        {
                            if (this._Solution[y, x].ContainPencilMark(number))
                            {
                                _Change = true;
                            }
                            this._Solution[y, x].RemovePencilMark(number);
                        }
                    }
                }
            }

            return _Change;
        }

        private bool CheckBoxForSinglePencilMarks(CellCoordinate cell, int number)
        {
            CellCoordinate boxcoordinate = this.GetBoxCoordinate(cell);
            for (int y = (boxcoordinate.Y * this._BoxSize); y < (boxcoordinate.Y * this._BoxSize) + this._BoxSize; y++)
            {
                for (int x = (boxcoordinate.X * this._BoxSize); x < (boxcoordinate.X * this._BoxSize) + this._BoxSize; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        if ((x != cell.X) || (y != cell.Y))
                        {
                            if (this._Solution[y, x].ContainPencilMark(number))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckHorizontalLineForSinglePencilMarks(CellCoordinate cell, int number)
        {
            for (int x = 0; x < this._Size; x++)
            {
                if (this._Solution[cell.Y, x].IsEmpty())
                {
                    if (x != cell.X)
                    {
                        if (this._Solution[cell.Y, x].ContainPencilMark(number))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckVerticalLineForSinglePencilMarks(CellCoordinate cell, int number)
        {
            for (int y = 0; y < this._Size; y++)
            {
                if (this._Solution[y, cell.X].IsEmpty())
                {
                    if (y != cell.Y)
                    {
                        if (this._Solution[y, cell.X].ContainPencilMark(number))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion

        #region Locked Candidates in box pencil marks
        public bool CheckForLockedCandidatesInBoxPencilMarks()
        {
            bool _Change = false;

            for (int i = 0; i < this._BoxSize; i++)
            {
                for (int j = 0; j < this._BoxSize; j++)
                {
                    ArrayList _AlreadyLooked = new ArrayList();

                    for (int y = (i * this._BoxSize); y < (i * this._BoxSize) + this._BoxSize; y++)
                    {
                        for (int x = (j * this._BoxSize); x < (j * this._BoxSize) + this._BoxSize; x++)
                        {
                            if (this._Solution[y, x].IsEmpty())
                            {
                                Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                                for (int p = 0; p < pencilmarks.Length; p++)
                                {
                                    if (!_AlreadyLooked.Contains(pencilmarks.GetValue(p)))
                                    {
                                        CellCoordinate[] cells = new CellCoordinate[this._BoxSize];
                                        cells[0] = new CellCoordinate(x, y);
                                        if (this.CheckBoxForLockedCandidatesPencilMarks(ref cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                        {
                                            if (this.CleanLockCandidatesInLinesPencilMarks(cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                            {
                                                _Change = true;
                                            }
                                        }
                                    }
                                    _AlreadyLooked.Add(pencilmarks.GetValue(p));
                                }
                            }
                        }
                    }
                }
            }

            return _Change;
        }

        public bool CleanLockCandidatesInLinesPencilMarks(CellCoordinate[] cells, int number)
        {
            bool _Change = false;

            // clean vertically
            if (cells[0].X == cells[1].X)
            {
                for (int y = 0; y < this._Size; y++)
                {
                    if (this._Solution[y, cells[0].X].IsEmpty())
                    {
                        bool _Other = true;
                        for (int i = 0; i < cells.Length; i++)
                        {
                            if (cells[i] != null)
                            {
                                if (_Other && (y == cells[i].Y))
                                {
                                    _Other = false;
                                }
                            }
                        }

                        if (_Other)
                        {
                            if (this._Solution[y, cells[0].X].ContainPencilMark(number))
                            {
                                _Change = true;
                            }
                            this._Solution[y, cells[0].X].RemovePencilMark(number);
                        }
                    }
                }
                
                return _Change;
            }

            // clean horizontally
            if (cells[0].Y == cells[1].Y)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[cells[0].Y, x].IsEmpty())
                    {
                        bool _Other = true;
                        for (int i = 0; i < cells.Length; i++)
                        {
                            if (cells[i] != null)
                            {
                                if (_Other && (x == cells[i].X))
                                {
                                    _Other = false;
                                }
                            }
                        }

                        if (_Other)
                        {
                            if (this._Solution[cells[0].Y, x].ContainPencilMark(number))
                            {
                                _Change = true;
                            }
                            this._Solution[cells[0].Y, x].RemovePencilMark(number);
                        }
                    }
                }

                return _Change;
            }

            return _Change;
        }

        private bool CheckBoxForLockedCandidatesPencilMarks(ref CellCoordinate[] cells, int number)
        {
            int _Count = 0;

            CellCoordinate boxcoordinate = this.GetBoxCoordinate(cells[0]);
            for (int y = (boxcoordinate.Y * this._BoxSize); y < (boxcoordinate.Y * this._BoxSize) + this._BoxSize; y++)
            {
                for (int x = (boxcoordinate.X * this._BoxSize); x < (boxcoordinate.X * this._BoxSize) + this._BoxSize; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        if ((x != cells[0].X) || (y != cells[0].Y))
                        {
                            if (this._Solution[y, x].ContainPencilMark(number))
                            {
                                _Count++;
                                if (_Count > (this._BoxSize - 1))
                                {
                                    return false;
                                }

                                cells[_Count] = new CellCoordinate(x, y);
                            }
                        }
                    }
                }
            }

            if (_Count == 0)
                return false;

            bool _Horizontal = true;
            bool _Vertical = true;

            for (int i = 1; i < cells.Length; i++)
            {
                if (cells[i] != null)
                {
                    if (_Vertical && (cells[0].X != cells[i].X))
                    {
                        _Vertical = false;
                    }

                    if (_Horizontal && (cells[0].Y != cells[i].Y))
                    {
                        _Horizontal = false;
                    }
                }
            }

            return (_Horizontal || _Vertical);
        }
        #endregion

        #region Locked Candidates in lines pencil marks
        public bool CheckForLockedCandidatesInLinesPencilMarks()
        {
            bool _Change = false;
            
            for (int y = 0; y < this._Size; y++)
            {
                ArrayList _AlreadyLooked = new ArrayList();

                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                        for (int p = 0; p < pencilmarks.Length; p++)
                        {
                            if (!_AlreadyLooked.Contains(pencilmarks.GetValue(p)))
                            {
                                CellCoordinate[] cells = new CellCoordinate[this._BoxSize];
                                cells[0] = new CellCoordinate(x, y);
                                if (this.CheckHorizontalLineForLockedCandidatesPencilMarks(ref cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                {
                                    if (this.CleanLockedCandidatesInBoxPencilMarks(cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                    {
                                        _Change = true;
                                    }
                                }
                            }
                            _AlreadyLooked.Add(pencilmarks.GetValue(p));
                        }
                    }
                }
            }
            
            for (int x = 0; x < this._Size; x++)
            {
                ArrayList _AlreadyLooked = new ArrayList();
                
                for (int y = 0; y < this._Size; y++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                        for (int p = 0; p < pencilmarks.Length; p++)
                        {
                            if (!_AlreadyLooked.Contains(pencilmarks.GetValue(p)))
                            {
                                CellCoordinate[] cells = new CellCoordinate[this._BoxSize];
                                cells[0] = new CellCoordinate(x, y);
                                if (this.CheckVerticalLineForLockedCandidatesPencilMarks(ref cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                {
                                    if (this.CleanLockedCandidatesInBoxPencilMarks(cells, this.ConvertToNumber(pencilmarks.GetValue(p).ToString())))
                                    {
                                        _Change = true;
                                    }
                                }
                            }
                            _AlreadyLooked.Add(pencilmarks.GetValue(p));
                        }
                    }
                }
            }

            return _Change;
        }

        public bool CleanLockedCandidatesInBoxPencilMarks(CellCoordinate[] cells, int number)
        {
            bool _Change = false;

            CellCoordinate boxcoordinate = this.GetBoxCoordinate(cells[0]);
            for (int y = (boxcoordinate.Y * this._BoxSize); y < (boxcoordinate.Y * this._BoxSize) + this._BoxSize; y++)
            {
                for (int x = (boxcoordinate.X * this._BoxSize); x < (boxcoordinate.X * this._BoxSize) + this._BoxSize; x++)
                {
                    if (this._Solution[y, x].IsEmpty())
                    {
                        bool _Other = true;
                        for (int i = 0; i < cells.Length; i++)
                        {
                            if (cells[i] != null)
                            {
                                if (_Other && ((new CellCoordinate(x, y)).Equals(cells[i])))
                                {
                                    _Other = false;
                                }
                            }
                        }

                        if (_Other)
                        {
                            if (this._Solution[y, x].ContainPencilMark(number))
                            {
                                _Change = true;
                            }
                            this._Solution[y, x].RemovePencilMark(number);
                        }
                    }
                }
            }

            return _Change;
        }

        private bool CheckHorizontalLineForLockedCandidatesPencilMarks(ref CellCoordinate[] cells, int number)
        {
            int _Count = 0;

            for (int x = 0; x < this._Size; x++)
            {
                if (this._Solution[cells[0].Y, x].IsEmpty())
                {
                    if (x != cells[0].X)
                    {
                        if (this._Solution[cells[0].Y, x].ContainPencilMark(number))
                        {
                            _Count++;
                            if (_Count > (this._BoxSize - 1))
                            {
                                return false;
                            }

                            cells[_Count] = new CellCoordinate(x, cells[0].Y);
                        }
                    }
                }
            }

            if (_Count == 0)
                return false;

            bool _Horizontal = true;
            for (int i = 1; i < cells.Length; i++)
            {
                if (cells[i] != null)
                {
                    if (_Horizontal && (!this.GetBoxCoordinate(cells[0]).Equals(this.GetBoxCoordinate(cells[i]))))
                    {
                        _Horizontal = false;
                    }
                }
            }

            return _Horizontal;
        }

        private bool CheckVerticalLineForLockedCandidatesPencilMarks(ref CellCoordinate[] cells, int number)
        {
            int _Count = 0;

            for (int y = 0; y < this._Size; y++)
            {
                if (this._Solution[y, cells[0].X].IsEmpty())
                {
                    if (y != cells[0].Y)
                    {
                        if (this._Solution[y, cells[0].X].ContainPencilMark(number))
                        {
                            _Count++;
                            if (_Count > (this._BoxSize - 1))
                            {
                                return false;
                            }

                            cells[_Count] = new CellCoordinate(cells[0].X, y);
                        }
                    }
                }
            }

            if (_Count == 0)
                return false;

            bool _Vertical = true;
            for (int i = 1; i < cells.Length; i++)
            {
                if (cells[i] != null)
                {
                    if (_Vertical && (!this.GetBoxCoordinate(cells[0]).Equals(this.GetBoxCoordinate(cells[i]))))
                    {
                        _Vertical = false;
                    }
                }
            }

            return _Vertical;
        }
        #endregion

        #region Hidden/Naked Pair pencil marks
        public bool CheckHiddenNakedPairPencilMarks()
        {
            bool _Change = false;

            for (int i = 0; i < this._BoxSize; i++)
            {
                for (int j = 0; j < this._BoxSize; j++)
                {
                    ArrayList _AlreadyLooked = new ArrayList();

                    for (int y = (i * this._BoxSize); y < (i * this._BoxSize) + this._BoxSize; y++)
                    {
                        for (int x = (j * this._BoxSize); x < (j * this._BoxSize) + this._BoxSize; x++)
                        {
                            if (this._Solution[y, x].IsEmpty())
                            {
                                Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                                for (int p = 0; p < pencilmarks.Length; p++)
                                {
                                    if (!_AlreadyLooked.Contains(pencilmarks.GetValue(p)))
                                    {

                                    }
                                    _AlreadyLooked.Add(pencilmarks.GetValue(p));
                                }
                            }
                        }
                    }
                }
            }

            return _Change;
        }


        #endregion

        #region Debuggers
        public void PrintProblemGrid()
        {
            this.PrintGrid(this._Problem);
        }

        public void PrintSolutionGrid()
        {
            this.PrintGrid(this._Solution);
        }

        public void PrintPencilMarks()
        {
            this.PrintPencilMarks(false);
        }
        #endregion

        #region Helpers
        private CellCoordinate GetBoxCoordinate(CellCoordinate cell)
        {
            int x = (int)(cell.X / this._BoxSize);
            int y = (int)(cell.Y / this._BoxSize);

            return new CellCoordinate(x, y);
        }

        private void PreparePuzzle()
        {
            this._Problem = new SudokuCell[this._Size, this._Size];
            this._Solution = new SudokuCell[this._Size, this._Size];

            for (int y = 0; y < this._Size; y++ )
            {
                for (int x = 0; x < this._Size; x++)
                {
                    this._Problem[y, x] = new SudokuCell();
                    this._Solution[y, x] = new SudokuCell();
                }
            }
        }

        private int ConvertToNumber(string number)
        {
            int _ReturnValue = 0;

            try
            {
                _ReturnValue = int.Parse(number);
            }
            catch (Exception e)
            {

            }

            return _ReturnValue;
        }

        private string ConvertToString(int number)
        {
            if (number < 10)
            {
                if (number == 0)
                    return " ";
                else
                    return number.ToString();
            }
            else
            {
                switch (number)
                {
                    case 10:
                        return "0";
                    case 11:
                        return "A";
                    case 12:
                        return "B";
                    case 13:
                        return "C";
                    case 14:
                        return "D";
                    case 15:
                        return "E";
                    case 16:
                        return "F";
                    case 17:
                        return "G";
                    case 18:
                        return "H";
                    case 19:
                        return "I";
                    case 20:
                        return "J";
                    case 21:
                        return "K";
                    case 22:
                        return "L";
                    case 23:
                        return "M";
                    case 24:
                        return "N";
                    case 25:
                        return "O";
                    default:
                        return " ";
                }
            }
        }

        private void PrintPencilMarks(bool showpencilmarksonly)
        {
            for (int y = 0; y < this._Size; y++)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    if (this._Solution[y, x].IsFilled())
                    {
                        if (!showpencilmarksonly)
                            System.Console.Write(string.Format("({0},{1}) = [{2}]\n", x, y, this._Solution[y, x].Number));
                    }
                    else
                    {
                        string _PencilMarksString = "";
                        Array pencilmarks = this._Solution[y, x].PencilMarks.ToArray(typeof(int));
                        for (int p = 0; p < pencilmarks.Length; p++)
                        {
                            if (p != 0) _PencilMarksString += ",";
                            _PencilMarksString += pencilmarks.GetValue(p).ToString();
                        }
                        System.Console.Write(string.Format("({0},{1}) = {2}\n", x, y, _PencilMarksString));
                    }
                }
            }
        }

        private void PrintGrid(SudokuCell[,] grid)
        {
            int size = (int)Math.Sqrt(grid.Length);
            int boxsize = (int)Math.Sqrt(size);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (y % boxsize == 0)
                    {
                        System.Console.Write("+===");
                    }
                    else
                    {
                        System.Console.Write("+---");
                    }
                }
                System.Console.Write("+\n");
                for (int x = 0; x < size; x++)
                {
                    if (x % boxsize == 0)
                    {
                        System.Console.Write("H " + this.ConvertToString(grid[y, x].Number) + " ");
                    }
                    else
                    {
                        System.Console.Write("| " + this.ConvertToString(grid[y, x].Number) + " ");
                    }
                }
                System.Console.Write("H\n");
            }

            for (int x = 0; x < size; x++)
            {
                System.Console.Write("+===");
            }
            System.Console.Write("+\n");
        }
        
        public void Initialize(string problem)
        {
            string[] _NumberArray = problem.Split(',');
            int _Index = 0;

            for (int y = 0; y < this._Size; y++)
            {
                for (int x = 0; x < this._Size; x++)
                {
                    this._Problem[y, x].Number = this.ConvertToNumber(_NumberArray[_Index]);
                    this._Solution[y, x].Number = this._Problem[y, x].Number;

                    _Index++;
                    if (_Index == _NumberArray.Length)
                    {
                        return;
                    }
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            //Sudoku s = new Sudoku(int.Parse(args[0]));
            Sudoku s = new Sudoku();
            //s.Initialize("4,,7,,,,,,2,,2,3,,7,4,,9,6,,9,8,,1,,4,,7,,6,,,3,,,,9,,,,,8,,,,,2,,,,4,,,1,,9,,1,,2,,6,3,,8,4,,3,6,,9,7,,3,,,,,,5,,8");
            //s.Initialize(",3,,,,1,,,,,,6,,,,,5,,5,,,,,,9,8,3,,8,,,,6,3,,2,,,,,5,,,,,9,,3,8,,,,6,,7,1,4,,,,,,9,,2,,,,,8,,,,,,4,,,,3,");
            //s.Initialize(",1,3,9,,,,,,8,,,,,1,3,9,6,,6,9,,3,,7,1,8,,,4,1,,,,5,3,,,1,,5,3,,,,3,,,,,,1,,,1,3,8,,,9,4,,,5,4,6,3,1,7,,8,,9,7,2,8,,,,3,1");
            //s.Initialize(",1,4,8,7,,3,,,,,9,4,,,5,,1,,,,,,,,8,,,,,9,3,,2,4,,,,,,,,,,,,8,2,,4,7,,,,,4,,,,,,,,9,,7,,,5,1,,,,,8,,2,4,7,3,");//pointing pair/triple
            //s.Initialize(",,,9,,4,,,,7,9,,,,,,2,4,8,,,2,,,,,1,,8,,4,5,1,,3,,,,,,,,,,,,7,,3,6,9,,4,,2,,,,,7,,,3,4,1,,,,,,6,2,,,,5,,6,,,,");//line box reduction
            //s.Initialize(",8,,,,4,,6,,,,2,,,,,,9,7,6,,,,,,1,2,,,,8,,6,,,,8,,,,,,,,3,,,,1,,7,,,,6,7,,,,5,,4,1,1,,,,,,7,,,,5,,9,,,,2,");//naked triple/quad
            s.Initialize(",,,,,,,,,8,2,,6,,1,,7,4,1,,,3,,4,,,6,5,1,,,,,,6,3,,,,,5,,,,,9,4,,,,,,2,5,2,,,8,,9,,,1,6,3,,1,,2,,5,9,");//hidden triple
            s.PrintProblemGrid();
            s.FillPossiblePencilMarks();
            //s.PrintPencilMarks(true);
            s.Solve();
            s.PrintSolutionGrid();
            s.PrintPencilMarks(true);
        }
    }

    public class SudokuCell
    {
        private int _Number = 0;
        private ArrayList _PencilMarks = new ArrayList();

        public int Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                this._Number = value;
                if (this._Number != 0)
                {
                    this._PencilMarks = new ArrayList();
                }
            }
        }

        public ArrayList PencilMarks
        {
            get
            {
                return this._PencilMarks;
            }
            set
            {
                IEnumerator IEnum = value.GetEnumerator();
                while (IEnum.MoveNext())
                {
                    this._PencilMarks.Add(IEnum.Current);
                }
            }
        }

        public SudokuCell()
        {
            
        }

        public SudokuCell(int number)
        {
            this.Number = number;
        }

        public SudokuCell(int number, ArrayList pencilmarks)
        {
            this.Number = number;
            this.PencilMarks = pencilmarks;
        }

        public bool IsFilled()
        {
            return (this._Number != 0);
        }

        public bool IsEmpty()
        {
            return !this.IsFilled();
        }

        public void AddPencilMark(int pencilmark)
        {
            this._PencilMarks.Add(pencilmark);
        }

        public void RemovePencilMark(int pencilmark)
        {
            this._PencilMarks.Remove(pencilmark);
        }

        public bool ContainPencilMark(int number)
        {
            return this._PencilMarks.Contains(number);
        }
    }

    public class CellCoordinate
    {
        private int _X = 0;
        private int _Y = 0;

        public int X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }

        public int Y
        {
            get
            {
                return this._Y;
            }
            set
            {
                this._Y = value;
            }
        }

        public CellCoordinate()
        {

        }

        public CellCoordinate(int x, int y)
        {
            this._X = x;
            this._Y = y;
        }

        public bool Equals(CellCoordinate cell)
        {
            if ((this._X == cell._X) && (this._Y == cell._Y))
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            System.Console.WriteLine(string.Format("({0},{1})", this._X, this._Y));
        }
    }
}
