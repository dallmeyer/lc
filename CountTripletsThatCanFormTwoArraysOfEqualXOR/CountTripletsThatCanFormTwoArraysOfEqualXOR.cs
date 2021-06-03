public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int[][] xors = new int[n][];
        for (int i = 0; i < n; i++) {
            xors[i] = new int[n];
            xors[i][i] = arr[i];
            for (int j = i+1; j < n; j++) { // O(n^2) fine for n <= 300
                xors[i][j] = (xors[i][j-1] ^ arr[j]);
            }
        }
        
        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i+1; j < n; j++) {
                for (int k = j; k < n; k++) {
                    if (xors[i][j-1] == xors[j][k]) {
                        //Console.WriteLine($"{i},{j-1} -> {xors[i][j-1]} | {j},{k} -> {xors[j][k]}");
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
}