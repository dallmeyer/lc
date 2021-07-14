func maxProfit(prices []int) int {
    prev := prices[0]
    profit := 0
    for i := 1; i < len(prices); i++ {
        tmp := prices[i] - prev
        if tmp > 0 {
            profit += tmp
        }
        prev = prices[i]
    }
    
    return profit
}