class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        sdt = dict()
        tds = dict()
        n = len(s)
        
        for i in range(n):
            cs = s[i]
            ct = t[i]
            
            if cs in sdt:
                if sdt[cs] != ct:
                    return False
            else:
                sdt[cs] = ct
                
            if ct in tds:
                if tds[ct] != cs:
                    return False
            else:
                tds[ct] = cs
        
        return True