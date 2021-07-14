func findMaxConsecutiveOnes(nums []int) int {
    n := len(nums)
    i := 0
    j := 0
    z := 0
    
    for ; j < n; j++ {
        if nums[j] == 0 {
            z++
        }
        if z > 0 {
            if nums[i] == 0 {
                z--
            }
            i++
        }
    }
    
    return j - i
}