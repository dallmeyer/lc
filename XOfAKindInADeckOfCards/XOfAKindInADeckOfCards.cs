public class Solution {
    public bool HasGroupsSizeX(int[] deck) {
        Dictionary<int,int> v = new Dictionary<int,int>();
        foreach (int d in deck) {
            if (v.ContainsKey(d) == false) {
                v[d] = 0;
            }
            v[d]++;
        }
        
        int? count = null;
        foreach (int k in v.Keys) {
            if (count == null) {
                count = v[k];
            } 
            else if (count != v[k]) {
                int gcd = (int) BigInteger.GreatestCommonDivisor((int) count, v[k]);
                if (gcd == 1) {
                    return false;
                }
                count = gcd;
            }
        }
        
        if (count == 1) {
            return false;
        }
        return true;
    }
}