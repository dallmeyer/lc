class Solution:
    def openLock(self, deadends: List[str], target: str) -> int:
        adj = dict()
        
        # connect graph
        for i in range(10000):
            cur = format(i, '04')
            for j in range(4):
                val = int(cur[j])
                upC = (val+1) % 10
                up = cur[:j] + str(upC) + cur[j+1:]
                #print(val, " - ", cur[:j], "/", str(upC), "/", cur[j+1:])
                #print("connect ", cur, " and ", up)
                
                if cur not in adj:
                    adj[cur] = set()
                adj[cur].add(up)
                
                if up not in adj:
                    adj[up] = set()
                adj[up].add(cur)
            
        cur = "0000"
        
        # disconnect deadends
        for x in deadends:
            if x == cur:
                return -1
            
            if x in adj:
                for y in adj[x]:
                    adj[y].remove(x)
                adj.pop(x)
            
        
        d = dict()
        d[cur] = 0
        
        if target == cur:
            return d[cur]
        
        q = [cur]
        while len(q) > 0:
            cur = q.pop(0)
            
            for x in adj[cur]:
                if x not in d:
                    d[x] = d[cur]+1
                    #print("from ", cur, " to ", x)
                    
                    if target == x:
                        return d[x]
                    
                    q.append(x)
            
        return -1        
        