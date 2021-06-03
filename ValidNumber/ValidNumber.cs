public class Solution {
    public bool IsNumber(string s) {
        s = s.Trim().ToLower();

        if (s.Length == 0) {return false;}

        string[] s2 = s.Split("e");
        if (s2.Length > 2) {return false;}
        
        //s2[0]
        if (s2[0].Length == 0) {return false;}
        if (s2[0][0] == '-' || s2[0][0] == '+') {
            s2[0] = s2[0].Substring(1);//trim initial +/-
        }
        if (IsDecimal(s2[0]) == false) {
            return false;
        }
        
        //s2[1]
        if (s2.Length > 1) {
            if (s2[1].Length > 0) {
                if (s2[1][0] == '-' || s2[1][0] == '+') {
                    s2[1] = s2[1].Substring(1);//trim initial +/-
                }
                if (IsInt(s2[1]) == false) {
                    return false;
                }
            } else {
                return false;
            }
        }
        
        return true;
    }
    
    public bool IsDecimal(string s) {
        int dec = 0;
        bool decOnly = true;
        if (s == "") {return false;}
        foreach (char c in s) {
            switch (c) {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    decOnly = false;
                    break;
                case '.':
                    dec++;
                    break;
                default:
                    return false;
            }
        }

        return (decOnly == false) && (dec <= 1);
    }
    
    public bool IsInt(string s) {
        if (s == "") {return false;}
        foreach (char c in s) {
            switch (c) {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    break;
                default:
                    return false;
            }
        }
        
        return true;
    }
}