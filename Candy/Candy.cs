public class Solution {
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        if (n == 1) {return 1;}
        
        int[] candy = new int[n];
        
        for (int i = 0; i < n; i++) {
            candy[i] = 1;
        }
        
        for (int i = 0; i < n; i++) {
            if (i > 0) {
                // check left
                if (ratings[i] > ratings[i-1]) {
                    if (candy[i] <= candy[i-1]) {
                        candy[i] = candy[i-1]+1;
                    }
                }
            }
            
            if (i+1 < n) {
                // check right
                if (ratings[i] > ratings[i+1]) {
                    if (candy[i] <= candy[i+1]) {
                        candy[i] = candy[i+1]+1;
                        
                        int j = i-1;
                        while (j >= 0 && ratings[j] > ratings[j+1] && candy[j] <= candy[j+1]) {
                            candy[j] = candy[j+1]+1;
                            j--;
                        }
                    }
                }
            }
        }
        
        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans += candy[i];
        }
        
        return ans;        
    }
}