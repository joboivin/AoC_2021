namespace AoC2021.Day8;

internal class Digit
{
    public Digit(string segments)
    {
        Segments = segments;
        Value = null;
    }

    public int? Value { get; set; }
    public string Segments { get; }
}
