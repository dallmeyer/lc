public class Solution {
    static int[] twos = {
        1,
        2,
        4,
        8,
        16,
        32,
        64,
        128,
        256,
        512,
        1024,
        2048,
        4096,
        8192,
        16384,
        32768,
        65536,
        131072,
        262144,
        524288,
        1048576
    };
    
    public int MatrixScore(int[][] A) {
        int m = A.Length; //height
        int n = A[0].Length; //width
        
        int score = 0;
        for (int i = 0; i < m; i++) {
            if (A[i][0] == 0) {
                // flip this row
                for (int j = 0; j < n; j++) {
                    A[i][j] += 1;
                    A[i][j] %= 2;
                }
            }
            score += twos[n-1];
        }
        
        for (int j = 1; j < n; j++) {
            int ones = 0;
            for (int i = 0; i < m; i++) {
                if (A[i][j] == 1) {
                    ones++;
                }
            }
            
            if (m - ones > ones) {
                ones = m - ones;
            }
            score += ones * twos[n-j-1];
        }
        
        return score;
    }
}