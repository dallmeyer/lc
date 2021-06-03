public class Solution {
    private static int[] bounds = {
        1,          // 26^0
        27,         // 26^1 + 26^0
        703,        // 26^2 + 26^1 + 26^0
        18279,      // 26^3 ...
        475255,     // 26^4 ...
        12356631,   // 26^5 ...
        321272407  // 26^6 ...
    };
    
    private static int[] ts = {
        1,
        26,
        676,
        17576,
        456976,
        11881376,
        308915776
    };

    public string ConvertToTitle(int columnNumber) {
        string s = "";
        for (int i = 6; i >= 0; i--) {
            if (columnNumber >= bounds[i]) {
                int offset = (columnNumber-1) / ts[i];
                columnNumber -= (offset * ts[i]);
                
                char c = (char) ('A' + offset - 1);
                if (i == 0) {
                    c++;
                }
                s += c;
            }
        }
        
        return s;
    }
}