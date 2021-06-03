public class Solution {
    public int MinMoves2(int[] nums) {
        Array.Sort(nums);
        
        int n = nums.Length;
        int med = nums[n/2];
        
        long mMoves = 0;
        
        foreach(int x in nums) {
            if (x < med) {
                mMoves += (med - x);
            } else {
                mMoves += (x - med);
            }
        }
        
        return (int) mMoves;
    }
}