public class Solution {
    public int MaxIceCream(int[] costs, int coins) {
        Array.Sort(costs);
        int i = 0;
        foreach (int c in costs){
            if (c <= coins) {
                i++;
                coins-=c;
            }
        }
        return i;
    }
}