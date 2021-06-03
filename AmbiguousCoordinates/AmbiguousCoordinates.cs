public class Solution {
    public IList<string> AmbiguousCoordinates(string s) {
        int n = s.Length;
        IList<string> coors = new List<string>();
        
        for (int i = 2; i < n-1; i++) {
            string a = s.Substring(1, i-1);
            string b = s.Substring(i, n-i-1);
            //Console.WriteLine("considering " + a + " | " + b);
            
            List<string> aa = DecParse(a);
            List<string> bb = DecParse(b);
            
            foreach (string ai in aa) {
                foreach (string bi in bb) {
                    string s2 = "(" + ai + ", " + bi + ")";
                    //Console.WriteLine(s2);
                    coors.Add(s2);
                }
            }
        }
        
        return coors;
    }
    
    private List<string> DecParse(string s) {
        List<string> l = new List<string>();
        
        if (s.Length == 0) {return l;}
        if (ValidDec(s, false)) {
            l.Add(s);
        }
        int n = s.Length;
        for (int i = 1; i < n; i++) {
            string s2 = s.Substring(0, i) + "." + s.Substring(i, n-i);
            if (ValidDec(s2, true)) {
                l.Add(s2);
            }
        }
        
        return l;
    }
    
    private bool ValidDec(string s, bool dec) {
        if (s[0] == '0') {
            if (s.Length == 1) {
                return true;
            } else if (s[1] != '.') {
                return false;
            } else if (s[s.Length-1] == '0') {
                return false;
            } else {
                return true;
            }
        } else {
            if (dec && s[s.Length-1] == '0') {
                return false;
            } else {
                return true;
            }
        }
    }
}