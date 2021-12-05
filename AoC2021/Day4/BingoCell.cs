namespace AoC2021.Day4;

internal class BingoCell
{
    public BingoCell(int value)
    {
        Value = value;
        IsMarked = false;
    }

    public int Value { get; }
    public bool IsMarked { get; private set; }

    public void NewNumberDrawed(int newNumber)
    {
        if (newNumber == Value)
            IsMarked = true;
    }
}

