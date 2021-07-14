public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        bool[][] v = new bool[n][];
        for (int i = 0; i < n; i++) {
            v[i] = new bool[n];
        }
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (v[i][j]) {continue;}
                
                int i1 = i;
                int j1 = j;
                int nxt = matrix[i1][j1];
                while (true) {                
                    int j2 = n-1-i1;
                    int i2 = j1;
                    if (v[i2][j2]) {break;}
                    int tmp = matrix[i2][j2];
                    
                    matrix[i2][j2] = nxt;
                    nxt = tmp;
                    i1 = i2;
                    j1 = j2;
                    v[i2][j2] = true;
                }
            }
        }
    }
}