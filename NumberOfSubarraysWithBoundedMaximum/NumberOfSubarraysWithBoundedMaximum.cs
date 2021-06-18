public class Solution {
    public int NumSubarrayBoundedMax(int[] nums, int left, int right) {        
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            if (nums[i] < left) {
                nums[i] = -1;
            } else if (nums[i] > right) {
                nums[i] = 1;
            } else {
                nums[i] = 0;
            }
        }
        
        int ans = 0;
        for (int i = 0; i < n; i++) {
            bool val = false;
            
            for (int j = i; j < n; j++) { 
                if (nums[j] == 0) {
                    val = true;
                }
                
                if (nums[j] == 1) {
                    break;  // no point in continuing for this i
                }

                if (val) {
                    ans++;
                }
            }
        }
        
        return ans;
    }
}