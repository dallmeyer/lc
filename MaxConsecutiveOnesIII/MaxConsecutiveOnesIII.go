func longestOnes(nums []int, k int) int {
    n := len(nums)
    i := 0
    j := 0
    z := 0
    
    for ; j < n; j++ {
        if nums[j] == 0 {
            z++
        }
        if z > k {
            if nums[i] == 0 {
                z--
            }
            i++
        }
    }
    
    return j - i
}