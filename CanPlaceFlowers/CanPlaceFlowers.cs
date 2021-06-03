public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        for (int i = 0; i < flowerbed.Length; i++) {
            switch (flowerbed[i]) {
                case 0:
                    if ((i == 0 || flowerbed[i-1] == 0) && (i == flowerbed.Length-1 || flowerbed[i+1] == 0)) {
                        n--;
                        flowerbed[i] = 1;
                    }
                    break;
                case 1:
                default:
                    break;
            }
        }
        
        return n <= 0;
    }
}