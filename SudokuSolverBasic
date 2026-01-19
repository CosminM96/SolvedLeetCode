public class Solution {
    // Uses char[][] to comply with LeetCode's rules
    // Function to check if it is safe to place num at mat[row][col]
    static bool isSafe(char[][] mat, int row, int col, int num)
    {

        // Check if num exists in the row
        for (int x = 0; x < 9; x++)
            if (mat[row][x] == num.ToString()[0])
                return false;

        // Check if num exists in the col
        for (int x = 0; x < 9; x++)
            if (mat[x][col] == num.ToString()[0])
                return false;

        // Check if num exists in the 3x3 sub-matrix
        int startRow = row - (row % 3), startCol = col - (col % 3);

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (mat[i + startRow][ j + startCol] == num.ToString()[0])
                    return false;

        return true;
    }

    // Function to solve the Sudoku problem
    static bool solveSudokuRec(char[][] mat, int row, int col)
    {

        // base case: Reached nth column of the last row
        if (row == 8 && col == 9)
            return true;

        // If last column of the row go to the next row
        if (col == 9)
        {
            row++;
            col = 0;
        }

        // If cell is already occupied then move forward
        if (mat[row][col] != '.')
            return solveSudokuRec(mat, row, col + 1);

        for (int num = 1; num <= 9; num++)
        {

            // If it is safe to place num at current position
            if (isSafe(mat, row, col, num))
            {
                mat[row][col] = num.ToString().ToCharArray()[0];
                if (solveSudokuRec(mat, row, col + 1))
                    return true;
                mat[row][col] = '.';
            }
        }

        return false;
    }
    public void SolveSudoku(char[][] mat)
    {
        char [,] grid = new char[9, 9];

        solveSudokuRec(mat, 0, 0);
    }

}
