public class Solution {
    private static int M, N;
    private static int[] rDelta = {-1, 1, 0, 0}, cDelta = {0, 0, -1, 1};
    
    class State {
        public bool[][] v;
        public int r, c, wIdx;
        
        
        public State() {
            v = new bool[M][];
            
            for (int i = 0; i < M; i++) {
                v[i] = new bool[N];
            }
        }
        
        public State clone() {
            State s = new State();
            
            for (int i = 0; i < M; i++) {
                for (int j = 0; j < N; j++) {
                    s.v[i][j] = this.v[i][j];
                }
            }
            
            s.r = this.r;
            s.c = this.c;
            s.wIdx = this.wIdx;
            
            return s;
        }
    }
    
    public bool Exist(char[][] board, string word) {
        M = board.Length;
        N = board[0].Length;
        
        char x = word[0];
        Queue<State> q = new Queue<State>();
        State s;
        HashSet<char> seen = new HashSet<char>();
        
        for (int i = 0; i < M; i++) {
            for (int j = 0; j < N; j++) {
                seen.Add(board[i][j]);
                if (board[i][j] == x) {
                    s = new State();
                    s.r = i;
                    s.c = j;
                    s.wIdx = 1;
                    s.v[i][j] = true;
                    q.Enqueue(s);
                }
            }
        }
        
        foreach (char y in word) {
            // check for any characters missing altogether on board
            if (seen.Contains(y) == false) {return false;}
        }
        
        while (q.Any()) {
            s = q.Dequeue();
            
            if (s.wIdx == word.Length) {
                return true;
            }
            
            x = word[s.wIdx];
            for (int d = 0; d < 4; d++) {
                int r2 = s.r + rDelta[d];
                int c2 = s.c + cDelta[d];
                
                if (0 <= r2 && r2 < M && 0 <= c2 && c2 < N  // in bounds
                    && s.v[r2][c2] == false && x == board[r2][c2]) {    // unused match for next char
                    State s2 = s.clone();
                    s2.wIdx++;
                    s2.r = r2;
                    s2.c = c2;
                    s2.v[r2][c2] = true;
                    
                    q.Enqueue(s2);
                }
            }
        }
        
        return false;
    }
}