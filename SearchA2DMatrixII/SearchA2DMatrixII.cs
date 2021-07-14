public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int y = 0;
        int lo = matrix.Length-1;
        
        while (lo >= 0 && y < matrix[0].Length) {
            while (lo-1 >= 0 && matrix[lo-1][y] >= target) {
                lo -= 1;
            }
            
            if (matrix[lo][y] == target) {
                return true;
            }
            
            y += 1;
        }
        
        return false;
    }
}

/*

class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        y = 0
        lo = len(matrix)-1
        
        while lo >= 0 and y < len(matrix[0]):
            #print(lo, y,  customfunction.f(lo, y))
            
            while lo-1 >= 0 and matrix[lo-1][y] >= target:
                lo -= 1
                #print("moved lo", lo, y, customfunction.f(lo, y), customfunction.f(lo, y), customfunction.f(lo, y), z)
                
            if matrix[lo][y] == target:
                return True
                
            y += 1
            #print("moved y", lo, y,  customfunction.f(lo, y))
                
                
        return False

*/