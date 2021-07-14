class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        bestBuy = prices[0]
        bestProfit = 0
        
        for i in range(1, len(prices)):
            profit = prices[i] - bestBuy
            bestProfit = max(bestProfit, profit)
            bestBuy = min(bestBuy, prices[i])
            
        return bestProfit