public class Solution {
    public bool ValidMountainArray(int[] arr) {
        int n = arr.Length;
        if (n < 3) {return false;}
        if (arr[0] >= arr[1] || arr[n-1] >= arr[n-2]) { return false; }
        
        bool inc = true;
        int i = 1;
        while (i+1 < n) {
            if (arr[i] == arr[i+1]) { return false; }
            
            // decreasing
            if (arr[i] > arr[i+1]) {
                inc = false;
            } 
            // increasing
            else {
                if (inc == false) {
                    return false;
                }
            }
            
            i++;
        }
        
        return true;
    }
}