public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int n = nums.Length;
        
        int[] pre = new int[n];
        Dictionary<int,int> last = new Dictionary<int,int>();
        
        int best = 0;
        int start = 0;
        int cur = 0;
        
        for (int i = 0; i < n; i++) {
            int x = nums[i];
            
            pre[i] = x;
            if (i > 0) {
                pre[i] += pre[i-1];
            }
            
            if (last.ContainsKey(x) && last[x] >= start) {
                // x has been used since start
                cur = pre[i-1];
                //Console.Write($"cur = {pre[i-1]}");
                if (start > 0) {
                    cur -= pre[start-1];
                }
                
                if (best < cur) {
                    best = cur;
                }
                
                start = last[x]+1;
            }
            
            last[x] = i;
        }
        
        cur = pre[n-1];
        if (start > 0) {
            cur -= pre[start-1];
        }

        if (best < cur) {
            best = cur;
        }
               
        return best;
    }
}