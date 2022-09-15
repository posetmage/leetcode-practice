// 240. Search a 2D Matrix II

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0 || matrix.First().Length == 0)
        {
            return false;
        }

        int row = matrix.Length;            
        int col = matrix.First().Length;
        int i = 0, j = col - 1;

        while (i < row && j >= 0)
        {
            int num = matrix[i][j];

            if (num == target)
            {
                return true;
            }
            else if (num > target)
            {
                j--;
            }
            else
            {
                i++;
            }
        }

        return false;
    }
}
