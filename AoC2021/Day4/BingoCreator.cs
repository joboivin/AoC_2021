using AoC2021.Common;

namespace AoC2021.Day4;

internal class BingoCreator : IBingoCreator
{
    private readonly IRawInputProvider _rawInputProvider;

    public BingoCreator(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<(IList<Bingo> bingoBoards, IList<int> numbersToBeDrawed)> CreateBingoBoardsAsync()
    {
        var index = 0;
        var bingoBoards = new List<Bingo>();
        var numbersToBeDrawed = new List<int>();
        var boardLines = new List<string>();

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            if (index == 0)
                numbersToBeDrawed = line.Split(',').Select(n => int.Parse(n)).ToList();
            else
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (index != 1)
                        bingoBoards.Add(CreateNewBoard(boardLines));
                }
                else
                    boardLines.Add(line);
            }

            index++;
        }

        if (boardLines.Any())
            bingoBoards.Add(CreateNewBoard(boardLines));

        return (bingoBoards, numbersToBeDrawed);
    }

    private static Bingo CreateNewBoard(IList<string> boardLines)
    {
        var newBoard = new Bingo();
        newBoard.LoadCells(boardLines);
        boardLines.Clear();

        return newBoard;
    }
}
