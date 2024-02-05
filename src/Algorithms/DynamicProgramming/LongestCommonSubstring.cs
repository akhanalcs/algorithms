namespace Algorithms.DynamicProgramming;

public record Cell(int Value, char? Character);
public static class LongestCommonSubstring
{
    public static Cell[,] Find(string word1, string word2)
    {
        var grid = new Cell[word1.Length + 1, word2.Length + 1];

        for (var row = 0; row <= word1.Length; row++)
        {
            // First row and first column are padded with zeroes, so we put nullable char in those places
            char? currentRowLetter = row == 0 ? null : word1[row - 1];
            for (var col = 0; col <= word2.Length; col++)
            {
                char? currentColumnLetter = col == 0 ? null : word2[col - 1];
                // Create the padding, so something like: grid[row - 1, column - 1] won't get you into Index out of bounds exceptions
                if (currentRowLetter is null || currentColumnLetter is null)
                {
                    grid[row, col] = new Cell(0, null);
                }
                // If the character matches, go 1 row up and 1 column left, grab that cell, add 1 to its value and put it in this cell
                else if (currentRowLetter == currentColumnLetter)
                {
                    var topLeftNeighbor = grid[row - 1, col - 1];
                    grid[row, col] = new Cell(topLeftNeighbor.Value + 1, currentRowLetter);
                }
                else
                {
                    grid[row, col] = new Cell(0, null);
                }
            }
        }

        return grid;
    }
}