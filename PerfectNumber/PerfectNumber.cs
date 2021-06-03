public class Solution {
    public bool CheckPerfectNumber(int num) {
        if (num == 1) {return false;}
        int i = 2;
        int sum = 1;
        while (i*i <= num) {
            if (num % i == 0) {
                int j = num / i;
                //Console.WriteLine(i + " " + j);
                
                if (i == j) {
                    sum += i;
                } else {
                    sum += i + j;
                }
            }
            
            i++;
        }
        
        //Console.WriteLine("sum:" + sum);
        return num == sum;
    }
}