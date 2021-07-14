func maxProfit(prices []int) int {
    max := 0
    
    min := prices[0]
    for i := 1; i < len(prices); i++ {
        tmp := prices[i] - min
        if tmp > max {
            max = tmp
        }
        if prices[i] < min {
            min = prices[i]
        }
    }
    
    return max
}