public class Solution {
    public bool CheckIfExist(int[] arr) {
        HashSet<int> v = new HashSet<int>();
        foreach (int i in arr) {
            if (v.Contains(2*i) || (i % 2 == 0 && v.Contains(i/2))) {
                return true;
            }
            v.Add(i);
        }
        
        return false;
    }
}