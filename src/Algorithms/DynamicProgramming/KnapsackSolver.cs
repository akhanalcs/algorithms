namespace Algorithms.DynamicProgramming;

public record Item(string Name, int Weight, int Value);
public record GridCell(int Value, List<Item> Items);
public static class KnapsackSolver
{
    public static GridCell[,] Solve(Item[] items, int maxCapacity)
    {
        // 2 dimensional array of GridCells with items.Length rows and (maxCapacity + 1) columns
        var grid = new GridCell[items.Length, maxCapacity + 1];

        for (var row = 0; row < items.Length; row++)
        {
            for (var capacity = 0; capacity <= maxCapacity; capacity++)
            {
                // The first row is special. It kinda sets the stage for everything that follows.
                if (row == 0)
                {
                    if (items[row].Weight <= capacity)
                    {
                        grid[row, capacity] = new GridCell(items[row].Value, [items[row]]);
                    }
                    else
                    {
                        // The first column has no capacity, so [i=0,j=0] will bring you here
                        grid[row, capacity] = new GridCell(0, []);
                    }
                }
                // For the rest of the rows
                // The item fits
                else if (items[row].Weight <= capacity)
                {
                    var item = items[row]; // Item under test
                    var valueInRemainingSpace = grid[row - 1, capacity - item.Weight].Value;
                    var valueIfTaken = item.Value + valueInRemainingSpace;
                    var valueIfNotTaken = grid[row - 1, capacity].Value; // Previous Max
                    if (valueIfTaken > valueIfNotTaken)
                    {
                        var itemsInRemainingSpace = grid[row - 1, capacity - item.Weight].Items;
                        // Note: List.Add modifies original data, but List.Append returns new array without modifying original data
                        grid[row, capacity] = new GridCell(valueIfTaken, itemsInRemainingSpace.Append(item).ToList());
                    }
                    // If you don't take the new value (valueIfTaken), just grab the cell from right above
                    else
                    {
                        grid[row, capacity] = grid[row - 1, capacity];
                    }
                }
                // The item doesn't fit, so grab the cell from right above
                else
                {
                    grid[row, capacity] = grid[row - 1, capacity];
                }
            }
        }

        return grid;
    }
}