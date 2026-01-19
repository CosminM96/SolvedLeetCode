public class Solution {
   private int[] masks = new int[27];
    
    public void SolveSudoku(char[][] board) 
    {
        // Step 1: Initialize bitmasks with given numbers
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    int num = board[i][j] - '1';           // 0 to 8
                    int bit = 1 << num;
                    
                    int rowIdx  = i;
                    int colIdx  = 9 + j;
                    int boxIdx  = 18 + (i / 3) * 3 + j / 3;

                    // If already used → invalid board (but assume input valid)
                    masks[rowIdx] |= bit;
                    masks[colIdx] |= bit;
                    masks[boxIdx] |= bit;
                }
            }
        }

        // Step 2: Start backtracking
        Solve(board, 0);
    }
    
    private bool Solve(char[][] board, int pos) 
    {
        if (pos == 81) return true; // Solved

        int row = pos / 9;
        int col = pos % 9;

        if (board[row][col] != '.') 
            return Solve(board, pos + 1);

        int boxIdx = 18 + (row / 3) * 3 + col / 3;
        int rowMask = masks[row];
        int colMask = masks[col + 9];
        int boxMask = masks[boxIdx];

        // Try numbers 1–9 (bits 0–8)
        for (int num = 0; num < 9; num++)
        {
            int bit = 1 << num;
            
            if ((rowMask & bit) == 0 && 
                (colMask & bit) == 0 && 
                (boxMask & bit) == 0)
            {
                // Place
                board[row][col] = (char)('1' + num);
                masks[row]      |= bit;
                masks[col + 9]  |= bit;
                masks[boxIdx]   |= bit;

                if (Solve(board, pos + 1))
                    return true;

                // Backtrack
                board[row][col] = '.';
                masks[row]      &= ~bit;
                masks[col + 9]  &= ~bit;
                masks[boxIdx]   &= ~bit;
            }
        }

        return false;
    }

}
