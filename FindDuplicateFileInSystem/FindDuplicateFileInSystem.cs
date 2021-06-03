public class Solution {
    /*
    Example 1:
    Input: paths = [
        "root/a 1.txt(abcd) 2.txt(efgh)",
        "root/c 3.txt(abcd)",
        "root/c/d 4.txt(efgh)",
        "root 4.txt(efgh)"
    ]
    Output: [
        ["root/a/2.txt","root/c/d/4.txt","root/4.txt"],
        ["root/a/1.txt","root/c/3.txt"]
    ]
    
    Example 2:
    Input: paths = ["root/a 1.txt(abcd) 2.txt(efgh)","root/c 3.txt(abcd)","root/c/d 4.txt(efgh)"]
    Output: [["root/a/2.txt","root/c/d/4.txt"],["root/a/1.txt","root/c/3.txt"]]
    */
    
    public IList<IList<string>> FindDuplicate(string[] paths) {
        Dictionary<string, List<string>> files = new Dictionary<string,List<string>>();
        
        foreach (string p in paths) {
            string[] toks = p.Split(' ');
            string dir = toks[0] + "/";
            
            for (int i = 1; i < toks.Length; i++) {
                string[] toks2 = toks[i].Split('(');
                string fullPath = dir + toks2[0];
                string fileContents = toks2[1];
                fileContents = fileContents.Substring(0, fileContents.Length-1);
                
                if (files.ContainsKey(fileContents) == false) {
                    files[fileContents] = new List<string>();
                }
                files[fileContents].Add(fullPath);
            }
        }
        
        IList<IList<string>> ans = new List<IList<string>>();
        foreach (string key in files.Keys) {
            if (files[key].Count > 1) {
                ans.Add(files[key]);
            }
        }
        
        return ans;
    }
}