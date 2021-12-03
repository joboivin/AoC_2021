namespace AoC2021.Common;

internal class RawInputProvider : IRawInputProvider
{
    private readonly string _inputPath;

    public RawInputProvider(string inputPath)
    {
        _inputPath = inputPath;
    }

    public async IAsyncEnumerable<string> ProvideRawInputAsync()
    {
        using var reader = new StreamReader(_inputPath);

        while (!reader.EndOfStream)
            yield return await reader.ReadLineAsync();
    }
}

