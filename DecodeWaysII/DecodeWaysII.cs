public class Solution {
    public static Dictionary<string,BigInteger> fMemo;
    public static HashSet<string> vMemo;    
    
    public int NumDecodings(string s) {
        fMemo = new Dictionary<string,BigInteger>();
        fMemo.Add("", 1);
        fMemo.Add("0", 0);
        
        vMemo = new HashSet<string>(new List<string> {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", 
            "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
            "20", "21", "22", "23", "24", "25", "26"
        });

        return (int) (f(s) % 1000000007);
    }
    
    public BigInteger f(string s) {
        //Console.WriteLine(s + " start");
        if (fMemo.ContainsKey(s)) {
            return fMemo[s];
        }
        
        BigInteger sum = 0;
        
        if (s[0] == '*') {
            char c = '1';
            for (int i = 0; i < 9; i++) {
                char[] temp = s.ToCharArray();
                temp[0] = c++;
                                
                sum = sum + f(new string(temp));
            }
        } else if (s.Length > 1 && s[1] == '*') {
            char c = '1';
            for (int i = 0; i < 9; i++) {
                char[] temp = s.ToCharArray();
                temp[1] = c++;
                                
                sum = sum + f(new string(temp));
            }
        } else {

            // use 1 char
            string pre1 = s.Substring(0, 1);
            string suf1 = s.Substring(1);

            sum = sum + v(pre1)*f(suf1);

            // use 2 char
            if (s.Length == 2) {
                sum = sum + v(s);
            } else if (s.Length > 2) {
                string pre2 = s.Substring(0, 2);
                string suf2 = s.Substring(2);

                sum = sum + v(pre2)*f(suf2);
            }
        }

        //Console.WriteLine(s + " end: " + sum);
        fMemo.Add(s, sum);
        return sum;
    }
    
    
    public int v(string s) {
        return vMemo.Contains(s) ? 1 : 0;
    }
}