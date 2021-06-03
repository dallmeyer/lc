public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        IList<string> final = new List<string>();
        int n = pattern.Length;
        
        Dictionary<char,char> map = new Dictionary<char,char>();
        string pKey = "";
        foreach (char c in pattern) {
            if (map.ContainsKey(c)) {
                pKey += map[c];
            } else {
                map[c] = (char) ('a' + map.Count);
                pKey += map[c];
            }
        }
        
        foreach (string w in words) {
            map = new Dictionary<char,char>();
            string key = "";
            foreach (char c in w) {
                if (map.ContainsKey(c)) {
                    key += map[c];
                } else {
                    map[c] = (char) ('a' + map.Count);
                    key += map[c];
                }
            }
            
            if (key == pKey) {
                final.Add(w);
            }
        }
        
        return final;
    }
}