public class Solution {
    static int[] rDelta = { -1, 1, 0, 0 };
    static int[] cDelta = { 0, 0, -1, 1 };
    
    public int CountBattleships(char[][] board) {
        int R = board.Length;
        int C = board[0].Length;
        
        int count = 0;
        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                switch (board[r][c]) {
                    case 'V': {continue;}
                    case 'X': {
                        count++;
                        board[r][c] = 'V';
                        //Console.WriteLine($"Found battleship #{count} at {r},{c}");

                        int d = 0;
                        for ( ; d < 4; d++) {
                            int r2 = r + rDelta[d];
                            int c2 = c + cDelta[d];

                            if (0 <= r2 && r2 < R && 0 <= c2 && c2 < C && board[r2][c2] == 'X') {
                                //Console.WriteLine($"Battleship extends in direction {d}");
                                break;
                            }
                        }

                        if (d < 4) {
                            // battleship extends in direction d
                            int i = 1;
                            int r2 = r + i*rDelta[d];
                            int c2 = c + i*cDelta[d];
                            while (0 <= r2 && r2 < R && 0 <= c2 && c2 < C && board[r2][c2] == 'X') {
                                board[r2][c2] = 'V';
                                //Console.WriteLine($"Extends to {r2},{c2}");

                                i++;
                                r2 = r + i*rDelta[d];
                                c2 = c + i*cDelta[d];
                            }
                        }
                        break;
                    }
                    default:
                        board[r][c] = 'V';
                        break;
                }                
            }
        }
        
        return count;
    }
}