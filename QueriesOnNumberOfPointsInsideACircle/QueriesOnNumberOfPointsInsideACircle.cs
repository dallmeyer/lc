public class Solution {
    public int[] CountPoints(int[][] points, int[][] queries) {
        int[] counts = new int[queries.Length];
        
        int i = 0;
        foreach (int[] q in queries) {
            int xc = q[0], yc = q[1], r = q[2];
            foreach(int[] p in points) {
                int xp = p[0], yp = p[1];
                int xd = xp-xc, yd = yp-yc;
                if (xd*xd + yd*yd <= r*r) {
                    counts[i]++;
                }
            }
            i++;
        }
        
        return counts;
    }
}