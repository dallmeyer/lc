public class SeatManager {
    private static SortedSet<int> free;

    public SeatManager(int n) {
        free = new SortedSet<int>();
        for (int i = 1; i <= n; i++) {
            free.Add(i);
        }
    }
    
    public int Reserve() {
        int min = free.Min;
        free.Remove(min);
        return min;
    }
    
    public void Unreserve(int seatNumber) {
        free.Add(seatNumber);
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */