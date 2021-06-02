public class Solution {
    public int MaximumGap(int[] nums) {
        int n = nums.Length;
        
        int max = nums[0];
        int min = nums[0];
        for (int i = 1; i < n; i++) {
            if (max < nums[i]) {
                max = nums[i];
            }
            if (min > nums[i]) {
                min = nums[i];
            }
        }
        
        if (max == min) {return 0;}
        
        int bSize = (max-min) / (n-1);
        if ((max-min) % (n-1) > 0) {    //ceiling
            bSize++;
        }
        //Console.WriteLine($"{n-1} buckets of size {bSize}");
        
        int[] bMins = new int[n];
        int[] bMaxs = new int[n];
        for (int i = 0; i < n; i++) {
            bMins[i] = -1;
            bMaxs[i] = -1;
        }
        
        foreach (int x in nums) {
            //if (x == min || x == max) {continue;}
            
            int b = (x - min) / bSize;
            Console.WriteLine($"x: {x} b: {b}");
            if (bMaxs[b] == -1 || bMaxs[b] < x) {
                //Console.WriteLine($"bMaxs[{b}] = {x}");
                bMaxs[b] = x;
            }
            if (bMins[b] == -1 || bMins[b] > x) {
                //Console.WriteLine($"bMins[{b}] = {x}");
                bMins[b] = x;
            }
        }
        
        int maxD = 0;
        int last = bMaxs[0];    //should always at least include overall min
        for (int i = 1; i < n; i++) {
            if (bMins[i] == -1) {continue;}
                        
            int d = bMins[i] - last;
            if (maxD < d) {
                maxD = d;
            }
            
            last = bMaxs[i];
        }
        
        return maxD;
    }
}