namespace AoC2021.Day4;

internal class Day4Solver : IDaySolver
{
    private readonly IBingoCreator _bingoCreator;

    public Day4Solver(IBingoCreator bingoCreator)
    {
        _bingoCreator = bingoCreator;
    }

    public async Task<int> SolveBonusProblemAsync()
    {
        var (bingoBoards, numbersToBeDrawed) = await _bingoCreator.CreateBingoBoardsAsync();
        var winnerBoardsCount = 0;

        foreach (var newNumber in numbersToBeDrawed)
        {
            foreach (var bingoBoard in bingoBoards)
            {
                if (!bingoBoard.HasWon)
                {
                    bingoBoard.NewNumberDrawed(newNumber);

                    if (bingoBoard.HasWon)
                        winnerBoardsCount++;

                    if (winnerBoardsCount == bingoBoards.Count)
                        return bingoBoard.UnmarkedCellsTotal.Value * newNumber;
                }

            }
        }

        throw new Exception("At least 1 board never wins");
    }

    public async Task<int> SolveProblemAsync()
    {
        var (bingoBoards, numbersToBeDrawed) = await _bingoCreator.CreateBingoBoardsAsync();

        foreach (var newNumber in numbersToBeDrawed)
        {
            foreach (var bingoBoard in bingoBoards)
            {
                bingoBoard.NewNumberDrawed(newNumber);

                if (bingoBoard.HasWon)
                    return bingoBoard.UnmarkedCellsTotal.Value * newNumber;
            }
        }

        throw new Exception("No board has won");
    }
}
