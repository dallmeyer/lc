public class Solution {
    private class State {
        public int n;
        public bool[][] v;
        public bool[] cv;
        public HashSet<int> duv;    //diagonals going / (0 = center)
        public HashSet<int> ddv;    //diagonals going \ (0 = center)
        
        
        public int count;   //also functions as which row to insert next
        
        public State (int n) {
            this.n = n;
            v = new bool[n][];
            for (int i = 0; i < n; i++) {
                v[i] = new bool[n];
            }
            cv = new bool[n];
            duv = new HashSet<int>();
            ddv = new HashSet<int>();
            count = 0;
        }
        
        public State clone() {
            State s = new State(this.n);
            s.count = this.count;
            
            for (int i = 0; i < n; i++) {
                s.cv[i] = this.cv[i];
                for (int j = 0; j < n; j++) {
                    s.v[i][j] = this.v[i][j];
                }
            }
            
            s.duv = new HashSet<int>(this.duv);
            s.ddv = new HashSet<int>(this.ddv);
            
            return s;
        }
        
        public string Print() {
            return String.Join('\n', this.Answer());
        }
        
        public IList<string> Answer() {
            IList<string> ans = new List<string>();
            for (int i = 0; i < n; i++) {
                string s = "";
                for (int j = 0; j < n; j++) {
                    if (v[i][j]) {
                        s += "Q";
                    } else {
                        s += ".";
                    }
                }
                ans.Add(s);
            }
            
            return ans;
        }
    }
    
    public int TotalNQueens(int n) {
        int ans = 0;
        
        State s = new State(n);
        Queue<State> q = new Queue<State>();
        q.Enqueue(s);
        
        while (q.Any()) {
            s = q.Dequeue();
            //Console.WriteLine($"r={s.count}\n{s.Print()}");
            int r = s.count;
            if (r == n) {
                ans++;
                continue;
            }
            
            for (int c = 0; c < n; c++) {
                if (s.cv[c]) { continue; }
                int du = (c - n + 1 + r);
                int dd = (c - r);
                
                //Console.WriteLine($"Considering r={r}, c={c} w/ du={du} dd={dd}.");
                
                if (s.duv.Contains(du) || s.ddv.Contains(dd)) { continue; }
                
                State s2 = s.clone();
                s2.cv[c] = true;
                s2.v[r][c] = true;
                s2.duv.Add(du);
                s2.ddv.Add(dd);
                s2.count++;
                
                q.Enqueue(s2);
            }
        }
        
        return ans;
    }
}