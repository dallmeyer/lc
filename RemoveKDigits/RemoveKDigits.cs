public class Solution {
    public string RemoveKdigits(string num, int k) {        
        int count = 0;
        int n = num.Length;
        int? last = null;
        for (int i = 0; i < n; i++) {
            if (count == k) {break;}
            
            //Console.Write($"i={i} num={num}");
            int x = num[i] - '0';
            //Console.WriteLine($" x={x}");
            
            if (i == 0 || last.HasValue && last.Value <= x) {
                // still increasing
                //Console.WriteLine("not decreasing");
                last = x;
                continue;
            } else {
                // decreasing, we should remove last (at i-1)
                //Console.WriteLine($"decreasing! removing last={last}");
                
                if (i > 1) {
                    // last was not in position 0, need to check if increasing or not from previous value
                    last = num[i-2] - '0';   //not -2 since we removed a character
                } else {
                    last = null;    
                }
                
                // remove char at i-1
                num = num.Substring(0,i-1) + num.Substring(i,n-i);
                count++;
                i -= 2; //since we removed an element, and we want to reevaluate if i is increasing vs what came before last
                n--;
                
                //Console.WriteLine($"new last={last}");
            }
        }
        
        num = num.Substring(0, n-(k-count));
        n = num.Length;
        
        int z = 0;
        while (z < n && num[z] == '0') {
            z++;
        }
        num = num.Substring(z);
        if (num == "") {return "0";}
        return num;
    }
}