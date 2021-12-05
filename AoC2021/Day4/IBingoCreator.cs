namespace AoC2021.Day4;

internal interface IBingoCreator
{
    Task<(IList<Bingo> bingoBoards, IList<int> numbersToBeDrawed)> CreateBingoBoardsAsync();
}

