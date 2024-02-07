using Algorithms.DynamicProgramming;

namespace Algorithms.UnitTests.DynamicProgramming;

public class LongestCommonSubstringTests
{
    [Test]
    public void LCS_Finds_Longest_Common_Substring()
    {
        // Arrange
        const string word1 = "FISH";
        const string word2 = "FOSH";
        
        // Act
        var grid = LongestCommonSubstring.Find(word1, word2);
        var (maxCell, maxRow, maxCol) = LongestCommonSubstring.GetMaxCell(grid);
        var lcs = LongestCommonSubstring.GetLongestCommonSubstring(grid, maxCell, maxRow, maxCol);

        // Assert
        Assert.That(maxCell.Value, Is.EqualTo(2));
        Assert.That(lcs, Is.EqualTo("SH"));
    }
}