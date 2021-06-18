class Solution:
    def minRefuelStops(self, target: int, startFuel: int, stations: List[List[int]]) -> int:
        n = len(stations)
        
        last = target
        q = dict()
        q[0] = 0
        
        for i in reversed(range(n)):
            #print(q)
            dist = last - stations[i][0]
            gas = stations[i][1]
            
            q2 = dict()
            best = None
            for refuels in q.keys():
                
                # first consider without refueling at station i
                need = q[refuels] + dist
                
                # keys should be in sorted order so if we already have lower need with <= refuels we can skip this
                if best is None or need < best:
                    best = need
                    q2[refuels] = need
                    
                # next consider refueling at station i
                need = max(0, need-gas)
                if need < best:
                    best = need
                    q2[refuels+1] = need
                
            q = q2
            last = stations[i][0]
            
        #print(q)
        for refuels in q.keys():
            if q[refuels] + last <= startFuel:
                return refuels
            
        return -1