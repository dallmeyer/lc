public class Solution {    
    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length,
            n = s2.Length;
        
        if (s3.Length != m+n) {return false;}
        
        bool[] v = new bool[n+1];
        for (int i = 0; i < m+1; i++) {
            bool[] v2 = new bool[n+1];
            for (int j = 0; j < n+1; j++) {
                if (i == 0) {
                    if (j == 0) {
                        v2[0] = true;
                    } else {    // j > 0
                        if (v2[j-1] && s2[j-1] == s3[i+j-1]) {
                            v2[j] = true;
                        }
                    }
                } else {    // i > 0
                    if (j == 0) {
                        if (v[0] && s1[i-1] == s3[i+j-1]) {
                            v2[0] = true;
                        }
                    } else {    // j > 0
                        if (v[j] && s1[i-1] == s3[i+j-1]) {
                            v2[j] = true;
                        }
                        if (v2[j-1] && s2[j-1] == s3[i+j-1]) {
                            v2[j] = true;
                        }
                    }
                }
            }
            
            v = v2;
        }       
        
        return v[n];
    }
}