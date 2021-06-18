public class Solution {
    public int SingleNumber(int[] nums) {
        HashSet<int> v = new HashSet<int>();
        
        foreach (int x in nums) {
            if (v.Contains(x)) {
                v.Remove(x);
            } else {
                v.Add(x);
            }
        }
        
        foreach (int x in v) {
            return x;
        }
        
        return -1;
    }
}