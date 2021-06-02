public class Solution {
    private static Dictionary<Tuple<int,int>, bool> memo;
    private static int _maxInt;
    private static int _maxSum;
    
    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        _maxInt = maxChoosableInteger;
        _maxSum = (_maxInt * (_maxInt+1)) / 2;
        
        memo = new Dictionary<Tuple<int,int>, bool>();
        int bm = 0;
        
        Tuple<int,int> t = new Tuple<int,int>(bm, desiredTotal);
        return recurse(t);
    }
    
    private static bool recurse(Tuple<int,int> t) {
        if (memo.ContainsKey(t)) {
            return memo[t];
        }
        
        int bm = t.Item1;
        int tgt = t.Item2;
        
        if (tgt > _maxSum) {
            memo[t] = false;
            return false;   //undefined
        }
        
        //Console.WriteLine($"bm={bm}[{Convert.ToString(bm, 2)}] tgt:{tgt}");
        
        for (int i = 0; i < _maxInt; i++) {
            int b = (1 << i);
            if ((bm & b) == 0) {
                // unused bit
                int x = i+1;
                //Console.WriteLine($"Unused bit {i}, b = {b}, x = {x}, OR {bm | b}[{Convert.ToString(bm|b, 2)}],  AND {bm & b}[{Convert.ToString(bm&b, 2)}]");
                
                if (tgt <= x) {
                    memo[t] = true;
                    return true;
                }
                
                Tuple<int,int> t2 = new Tuple<int,int>((bm | b), tgt - x);
                if (recurse(t2) == false) {
                    //Console.WriteLine($"bm={bm} tgt:{tgt} found win using {x}");
                    memo[t] = true;
                    return true;
                }
            }
        }
        
        //Console.WriteLine($"bm={bm} tgt:{tgt} NO win");
        
        memo[t] = false;
        return false;
    }
}