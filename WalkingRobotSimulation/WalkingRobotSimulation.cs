public class Solution {
    static int[] xDelta = {0, 1, 0, -1},
                 yDelta = {1, 0, -1, 0};
                        // N0 E1 S2 W3
    static string[] dir = {"N", "E", "S", "W"};
    
    public int RobotSim(int[] commands, int[][] obstacles) {
        int x = 0, y = 0;
        int d = 0;  // N
        
        HashSet<Tuple<int,int>> o = new HashSet<Tuple<int,int>>();
        foreach (int[] ob in obstacles) {
            o.Add(new Tuple<int,int>(ob[0], ob[1]));
        }
        
        int max = 0;
        foreach (int c in commands) {
            switch (c) {
                case -2:
                    d = (d + 4 - 1) % 4;
                    //Console.WriteLine("Turning left to " + dir[d]);
                    break;
                case -1:
                    d = (d + 4 + 1) % 4;
                    //Console.WriteLine("Turning right to " + dir[d]);
                    break;
                default:
                    //Console.WriteLine("Moving " + c + " in " + dir[d]);
                    for (int i = 0; i < c; i++) {
                        if (o.Contains(new Tuple<int,int>(x+xDelta[d], y+yDelta[d]))) {
                            break;
                        }
                        
                        x += xDelta[d];
                        y += yDelta[d];
                    }
                    break;
            }
            
            int ed = x*x + y*y;
            if (max < ed) {
                max = ed;
            }
        }
               
        return max;
    }
}