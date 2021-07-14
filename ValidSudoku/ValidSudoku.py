class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        hSeen = [set() for i in range(9)]
        vSeen = [set() for i in range(9)]
        sqSeen = [set() for i in range(9)]
        
        for i in range(9):
            for j in range(9):
                x = board[i][j]
                if x == ".":
                    continue
                
                if x in hSeen[i]:
                    return False
                hSeen[i].add(x)
                
                if x in vSeen[j]:
                    return False
                vSeen[j].add(x)
                
                sq = 3*int(i/3) + int(j/3)
                #print(i,j,"->",sq)
                if x in sqSeen[sq]:
                    return False
                sqSeen[sq].add(x)
                
        return True