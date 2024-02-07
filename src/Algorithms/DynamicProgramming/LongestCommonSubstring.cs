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

    public static string GetLongestCommonSubstring(Cell[,] grid, Cell maxCell, int maxRow, int maxCol)
    {
        var lcs = new Stack<char>();
        
        // Go back diagonally until there's a break
        while (maxCell.Character is not null)
        {
            lcs.Push(maxCell.Character.Value);
            maxRow--;
            maxCol--;
            maxCell = grid[maxRow, maxCol];
        }

        return new string(lcs.ToArray());
    }

    public static (Cell MaxCell, int MaxRow, int MaxCol) GetMaxCell(Cell[,] grid)
    {
        int maxRow = 0, maxCol = 0;
        var maxCell = grid[maxRow, maxCol];
        var gridRows = grid.GetLength(0);
        var gridCols = grid.GetLength(1);

        // Find the max cell and its location
        // You only have to go through the words' length portion of the original grid.  For eg: (1,1) to (noOfGridRows-1,noOfGridCols-1)
        for (var row = 1; row <= gridRows - 1; row++)
        {
            for (var col = 1; col <= gridCols - 1; col++)
            {
                if (grid[row, col].Value > maxCell.Value)
                {
                    maxCell = grid[row, col];
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        return (maxCell, maxRow, maxCol);
    }
}