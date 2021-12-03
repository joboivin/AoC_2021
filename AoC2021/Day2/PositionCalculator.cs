using System.Text.RegularExpressions;

namespace AoC2021.Day2;

internal class PositionCalculator : IPositionCalculator
{
    public async Task<(int horizontal, int vertical)> CalculateBasicPositionAsync(IAsyncEnumerable<string> commands)
    {
        (int horizontal, int vertical) position = (0, 0);

        await CalculateAsync(commands, i => { position.horizontal += i; }, i => { position.vertical -= i; }, i => { position.vertical += i; });

        return position;
    }

    public async Task<(int horizontal, int vertical)> CalculateAdvancedPositionAsync(IAsyncEnumerable<string> commands)
    {
        (int horizontal, int vertical) position = (0, 0);
        var aim = 0;

        await CalculateAsync(commands, i => { position.horizontal += i; position.vertical += aim * i; }, i => { aim -= i; }, i => { aim += i; });

        return position;
    }

    private async Task CalculateAsync(IAsyncEnumerable<string> commands, Action<int> forwardAction, Action<int> upAction, Action<int> downAction)
    {
        var forwardPattern = new Regex("^forward (\\d*)$");
        var upPattern = new Regex("^up (\\d*)$");
        var downPattern = new Regex("^down (\\d*)$");

        await foreach (var command in commands)
        {
            var forwardMatch = forwardPattern.Match(command);

            if (forwardMatch.Success)
            {
                forwardAction(int.Parse(forwardMatch.Groups[1].Value));
                continue;
            }

            var upMatch = upPattern.Match(command);

            if (upMatch.Success)
            {
                upAction(int.Parse(upMatch.Groups[1].Value));
                continue;
            }

            var downMatch = downPattern.Match(command);

            if (downMatch.Success)
            {
                downAction(int.Parse(downMatch.Groups[1].Value));
                continue;
            }

            throw new Exception("Unexpected command");
        }
    }
}

