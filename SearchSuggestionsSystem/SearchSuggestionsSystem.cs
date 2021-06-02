public class Solution {
    class Node {
        public bool isWord;
        public Node[] children;
        public string s;
        
        public Node(string s) {
            isWord = false;
            children = new Node[26];
            this.s = s;
        }
    }
    
    private static Node root;
    
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        root = new Node("");
        
        // prep trie
        Node cur;
        foreach (string p in products) {
            cur = root;
            
            foreach (char c in p) {
                int idx = (c - 'a');
                if (cur.children[idx] == null) {
                    cur.children[idx] = new Node(cur.s + c);
                }
                cur = cur.children[idx];
            }
            
            cur.isWord = true;
        }
        
        IList<IList<string>> ans = new List<IList<string>>();
        int n = searchWord.Length;
        cur = root;
        for (int i = 0; i < n; i++) {
            int idx = (searchWord[i] - 'a');
            IList<string> list = new List<string>();
            
            if (cur != null && cur.children[idx] != null) {
                //Console.WriteLine($"Found prefix {cur.children[idx].s}");
                
                // dfs for matches from cur.children[idx]
                Node x = cur.children[idx];
                Stack<Node> stk = new Stack<Node>();
                stk.Push(x);
                
                while (stk.Any() && list.Count < 3) {
                    x = stk.Pop();
                    //Console.WriteLine($"Popped {x.s}");
                    
                    if (x.isWord) {
                        list.Add(x.s);
                        //Console.WriteLine($"Added word {x.s}!");
                    }
                    
                    for (int j = 25; j >= 0; j--) {
                        if (x.children[j] != null) {
                            stk.Push(x.children[j]);
                            //Console.WriteLine($"Pushed {x.children[j].s}");
                        }
                    }
                }
                
                cur = cur.children[idx];    //possibly null
            } else {
                cur = null;
            }
            
            ans.Add(list);
        }
        
        return ans;
    }
}