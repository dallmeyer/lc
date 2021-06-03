public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        int n = seq.Length;
        int[] ds = new int[n];
        int maxD = 0;
        int d = 0;
        for (int i = 0; i < n; i++) {
            if (seq[i] == '(') {
                d++;
                if (maxD < d) {
                    maxD = d;
                }
                
                ds[i] = d;
            } else {
                ds[i] = d;
                d--;
            }
        }
        
        for (int i = 0; i < n; i++) {
            if (ds[i]*2 <= maxD) {
                ds[i] = 0;
            } else {
                ds[i] = 1;
            }
        }
        
        return ds;
    }
}