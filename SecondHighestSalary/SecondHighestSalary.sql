/* Write your T-SQL query statement below */
DECLARE @Salary INT = NULL;

WITH CTE1 AS (
    SELECT DISTINCT
        Salary
    FROM Employee
), CTE2 AS (
    SELECT
        Salary,
        ROW_NUMBER() OVER(ORDER BY Salary DESC) AS RowNum
    FROM CTE1
)
SELECT @Salary = Salary
FROM CTE2
WHERE RowNum = 2

SELECT @Salary AS SecondHighestSalary