public class Solution {
    class State {
        public int i;
        public long[] sides;
        
        public State() {
            sides = new long[4];
        }
        
        public State clone() {
            State s = new State();
            s.i = this.i;
            s.sides[0] = this.sides[0];
            s.sides[1] = this.sides[1];
            s.sides[2] = this.sides[2];
            s.sides[3] = this.sides[3];
            
            return s;
        }
    }
    
    private static int n;
    private static long side;
    
    public bool Makesquare(int[] matchsticks) {
        n = matchsticks.Length;
        
        int max = -1;
        long sum = 0;
        foreach (int x in matchsticks) {
            sum += x;
            if (max < x) {
                max = x;
            }
        }
        
        if (sum % 4 != 0) {return false;}
        
        side = sum/4;
        if (max > side) {return false;}
        
        State s = new State();
        s.i = 1;
        s.sides[0] += matchsticks[0];
        return dfs(s, matchsticks);
    }
    
    private static bool dfs(State s, int[] matchsticks) {    
        if (s.i == n) {
            bool sq = true;
            foreach (int x in s.sides) {
                if (x != side) {
                    sq = false;
                    break;
                }
            }

            if (sq) {
                return true;
            }
        } else {
            for (int i = 0; i < 4; i++) {
                if (s.sides[i] + matchsticks[s.i] <= side) {
                    State s2 = s.clone();
                    s2.sides[i] += matchsticks[s.i];
                    s2.i++;

                    if (dfs(s2, matchsticks)) {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
}