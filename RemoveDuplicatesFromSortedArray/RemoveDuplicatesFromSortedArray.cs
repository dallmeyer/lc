public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int n = nums.Length;
        if (n == 0) {return 0;}

        int len = 1;
        int last = nums[0];
        
        for (int i = 1; i < n; i++) {
            if (nums[i] != last) {
                nums[len] = nums[i];
                last = nums[i];
                len++;
            }
        }
        
        return len;
    }
}