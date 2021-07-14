public class Solution {
    public class UnionFind {
        int n;
        int[] id;
        
        public UnionFind(int n) {
            this.n = n;
            id = Enumerable.Repeat(-1, n).ToArray();
        }
        
        public int Find(int i) {
            if (id[i] < 0)
                return i;
        
            id[i] = Find(id[i]);
            return id[i];
        }
        
        public int Union(int a, int b) {
            int rootA = Find(a);
            int rootB = Find(b);
            
            if (rootA == rootB) {
                return 0;
            }
            
            this.n--;
            if (id[rootB] < id[rootA]) {
                id[rootA] = rootB;
                return -1;
            } else if (id[rootA] < id[rootB]) {
                id[rootB] = rootA;
                return 1;
            } else {
                id[rootB] = rootA;
                id[rootA]--;
                return 1;
            }
        }
    }
    
    public int[] FindRedundantConnection(int[][] edges) {
        int? lastRedundantU = null;
        int? lastRedundantV = null;
        
        int n = edges.Length;
        UnionFind uf = new UnionFind(n);
        for (int i = 0; i < n; i++) {
            int u = edges[i][0];
            int v = edges[i][1];
            if (uf.Union(u-1, v-1) == 0) {
                // already unioned
                lastRedundantU = u;
                lastRedundantV = v;
            }
        }
        
        return new int[] {(int)lastRedundantU, (int)lastRedundantV};
    }
}