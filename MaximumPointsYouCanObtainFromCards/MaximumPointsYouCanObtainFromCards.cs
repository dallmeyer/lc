public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        int n = cardPoints.Length;
        
        int[] pre = new int[n];
        pre[0] = cardPoints[0];
        for (int i = 1; i < n; i++) {
            pre[i] = pre[i-1] + cardPoints[i];
        }
        
        if (n == k) {return pre[n-1];}
        
        int min = Int32.MaxValue;
        int d = n-k;
        for (int i = 0; i + d - 1 < n; i++) {
            int sum = pre[i+d-1];
            if (i > 0) {
                sum -= pre[i-1];
            }
            
            if (sum < min) {
                min = sum;
            }
        }
        
        return pre[n-1] - min;
    }
}