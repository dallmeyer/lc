public class Solution {
    public int MinPartitions(string n) {
        int max = 0;
        foreach (char c in n) {
            int val = c - '0';
            if (val > max) {
                max = val;
            }
        }
        return max;
    }
}