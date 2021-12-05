namespace AoC2021.Day4;

internal class Bingo
{
    public const int GridDimension = 5;

    internal BingoCell[,] Cells { get; }

    public Bingo()
    {
        Cells = new BingoCell[GridDimension, GridDimension];

        HasWon = false;
        UnmarkedCellsTotal = null;
    }

    public bool HasWon { get; private set; }
    public int? UnmarkedCellsTotal { get; private set; }

    public void LoadCells(IList<string> lines)
    {
        //2 chars per number, separated by a space
        const int expectedLineLength = GridDimension * 2 + (GridDimension - 1);

        if (lines.Count != GridDimension)
            throw new ArgumentException($"{GridDimension} lines are required", nameof(lines));

        for (var i = 0; i < GridDimension; i++)
        {
            if (lines[i].Length != expectedLineLength)
                throw new ArgumentException($"Line {lines[i]} doesn't have {GridDimension} numbers");

            for (var j = 0; j < GridDimension; j++)
                //3 chars by number, including white space
                Cells[i, j] = new BingoCell(int.Parse(lines[i].Substring(j * 3, 2).Trim()));
        }
    }

    public void NewNumberDrawed(int newNumber)
    {
        (int line, int column)? newNumberPosition = null;
        int unmarkedCellsTotal = 0;

        for (var i = 0; i < GridDimension; i++)
        {
            for (var j = 0; j < GridDimension; j++)
            {
                if (!Cells[i, j].IsMarked)
                {
                    Cells[i, j].NewNumberDrawed(newNumber);

                    if (Cells[i, j].IsMarked)
                        newNumberPosition = (i, j);
                    else
                        unmarkedCellsTotal += Cells[i, j].Value;
                }
            }
        }

        if (newNumberPosition != null)
            DetermineIfBingoHasWon(newNumberPosition.Value, unmarkedCellsTotal);
    }

    private void DetermineIfBingoHasWon((int line, int column) newNumberPosition, int unmarkedCellsTotal)
    {
        var allNumbersMarked = true;

        for (int i = 0; i < GridDimension; i++)
        {
            if (!Cells[newNumberPosition.line, i].IsMarked)
                allNumbersMarked = false;
        }

        if (allNumbersMarked)
        {
            HasWon = true;
            UnmarkedCellsTotal = unmarkedCellsTotal;
        }
        else
        {
            allNumbersMarked = true;

            for (int i = 0; i < GridDimension; i++)
            {
                if (!Cells[i, newNumberPosition.column].IsMarked)
                    allNumbersMarked = false;
            }

            if (allNumbersMarked)
            {
                HasWon = true;
                UnmarkedCellsTotal = unmarkedCellsTotal;
            }
        }
    }
}
