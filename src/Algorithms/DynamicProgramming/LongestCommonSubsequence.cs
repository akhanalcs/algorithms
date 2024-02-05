namespace Algorithms.DynamicProgramming;

public static class LongestCommonSubsequence
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
                // Create the padding, so something like: grid[row - 1, col - 1] won't get you into Index out of bounds exceptions
                if (row == 0 || col == 0)
                {
                    grid[row, col] = new Cell(0, null);
                }
                else if (currentRowLetter == currentColumnLetter)
                {
                    var topLeftNeighbor = grid[row - 1, col - 1];
                    grid[row, col] = new Cell(topLeftNeighbor.Value + 1, currentRowLetter);
                }
                else
                {
                    var topNeighbor = grid[row - 1, col];
                    var leftNeighbor = grid[row, col - 1];
                    grid[row, col] = new Cell(Math.Max(topNeighbor.Value, leftNeighbor.Value), null);
                }
            }
        }

        return grid;
    }

    // Backtracking the grid
    public static string GetLongestCommonSubsequence(Cell[,] grid)
    {
        var lcs = new Stack<char>();

        // Only go through the words' length portion of the original grid.  For eg: (noOfGridRows,noOfGridCols) to (1,1)
        // Don't go to the padded row/ column, that's why -1
        var rows = grid.GetLength(0) - 1;
        var cols = grid.GetLength(1) - 1;
        
        while (rows > 0 && cols > 0)
        {
            // If you get a character, go towards diagonal
            if (grid[rows, cols].Character.HasValue)
            {
                lcs.Push(grid[rows, cols].Character!.Value);
                rows--;
                cols--;
            }
            // Otherwise, just go towards the left or top neighbor (whichever is bigger)
            else
            {
                if (grid[rows - 1, cols].Value > grid[rows, cols - 1].Value)
                    rows--; // If the top neighbor:grid[row - 1, col] is bigger, go towards it
                else
                    cols--; // If the left neighbor:grid[row, col - 1] is bigger, go towards it
            }
        }
        
        return new string(lcs.ToArray());
    }
}