public class Solution {
    
    private class Node {
        public Dictionary<char,Node> children;
        public int? wordIdx;
        
        public Node() {
            children = new Dictionary<char,Node>();
        }
    }
    
    public IList<IList<int>> PalindromePairs(string[] words) {
        int n = words.Length;
        
        // build suffix trees O(n*m)
        Node suf = new Node();
        
        for (int i = 0; i < n; i++) {
            string w = words[i];
            int m = w.Length;
            
            Node s = suf;
            
            for (int j = 0; j < m; j++) {
                char c = w[m-1-j];
                if (s.children.ContainsKey(c) == false) {
                    s.children[c] = new Node();
                }
                s = s.children[c];
            }
            
            s.wordIdx = i;
        }
        
        // for each word...
        IList<IList<int>> ans = new List<IList<int>>();
        for (int i = 0; i < n; i++) {
            string w = words[i];
            int m = w.Length;
            
            Queue<Tuple<Node,string>> q = new Queue<Tuple<Node,string>>();
            // ...find matching suffixes...
            Node s = suf;
            for (int j = 0; s != null && j < m; j++) {
                char c = w[j];
                
                if (s.wordIdx.HasValue && s.wordIdx != i) {
                    string leftover = w.Substring(j);
                    
                    // check if leftover substring is palindromic
                    bool pal = true;
                    for (int k = 0; k < leftover.Length/2; k++) {
                        if (leftover[k] != leftover[leftover.Length-1-k]) {
                            pal = false;
                            break;
                        }
                    }
                    
                    //Console.WriteLine(pal);
                    if (pal) {
                        IList<int> pair = new List<int>();
                        pair.Add(i);
                        pair.Add(s.wordIdx.Value);
                        ans.Add(pair);
                    }
                }
                
                if (s.children.ContainsKey(c)) {
                    s = s.children[c];
                } 
                else {
                    s = null;
                }
            }
            
            // no matching suffixes, move on
            if (s == null) {
                //Console.WriteLine("no suffix found for " + w);
                continue;
            }
            //Console.WriteLine("suffix found for " + w);
            
            // ...BFS to find potential matches, see if leftover substrings are palindromic
            Tuple<Node,string> t = new Tuple<Node,string>(s, "");
            q.Enqueue(t);
            
            while (q.Any()) {
                t = q.Dequeue();
                Node cur = t.Item1;
                string sub = t.Item2;
                
                if (cur.wordIdx.HasValue && cur.wordIdx != i) {
                    //Console.Write(" word " + cur.wordIdx + " had matching suffix, but is it palindromic? ");
                    
                    // check if leftover substring is palindromic
                    bool pal = true;
                    for (int j = 0; j < sub.Length/2; j++) {
                        if (sub[j] != sub[sub.Length-1-j]) {
                            pal = false;
                            break;
                        }
                    }
                    
                    //Console.WriteLine(pal);
                    if (pal) {
                        IList<int> pair = new List<int>();
                        pair.Add(i);
                        pair.Add(cur.wordIdx.Value);
                        ans.Add(pair);
                    }
                }
                
                foreach (char cc in cur.children.Keys) {
                    Tuple<Node,string> t2 = new Tuple<Node,string>(cur.children[cc], sub + cc);
                    q.Enqueue(t2);                    
                }
            }
        }
        
        return ans;
    }
}