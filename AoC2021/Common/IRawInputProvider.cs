namespace AoC2021.Common;

internal interface IRawInputProvider
{
    IAsyncEnumerable<string> ProvideRawInputAsync();
}

