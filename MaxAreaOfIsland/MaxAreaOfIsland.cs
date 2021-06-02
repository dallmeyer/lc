public class Solution {
    private static int[] rDelta = { -1, 1, 0, 0 };
    private static int[] cDelta = { 0, 0, -1, 1 };
    
    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        int max = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {continue;}
                
                int cur = 0;                            
                grid[i][j] = 0; // so we don't cycle
                Queue<Tuple<int,int>> q = new Queue<Tuple<int,int>>();
                Tuple<int,int> t = new Tuple<int,int>(i, j);
                q.Enqueue(t);
                                
                while (q.Any()) {
                    t = q.Dequeue();
                    cur++;
                    
                    
                    for (int d = 0; d < 4; d++) {
                        int r2 = t.Item1 + rDelta[d];
                        int c2 = t.Item2 + cDelta[d];
                        
                        if (0 <= r2 && r2 < m && 0 <= c2 && c2 < n && grid[r2][c2] == 1) {
                            grid[r2][c2] = 0; // so we don't cycle
                            q.Enqueue(new Tuple<int,int>(r2,c2));
                        }
                    }
                }
                
                if (max < cur) {
                    max = cur;
                }
            }
        }
        
        return max;
    }
}