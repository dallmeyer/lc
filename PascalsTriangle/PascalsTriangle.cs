public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> ans = new List<IList<int>>();
        IList<int> prev = null;
        
        for (int i = 1; i <= numRows; i++) {
            IList<int> row = new List<int>();
            
            for (int j = 0; j < i; j++) {
                if (j == 0 || j == i-1) {
                    row.Add(1);
                } else {
                    row.Add(prev[j-1] + prev[j]);
                }
            }
            
            ans.Add(row);
            prev = row;
        }
        
        return ans;
    }
}