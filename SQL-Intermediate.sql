USE DotNetCourseDatabase
SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[Users].[Email],
[Users].[Gender],
[Users].[Active] 
FROM TutorialAppSchema.Users AS Users
WHERE Active = 1
ORDER By Users.UserId DESC
--merge tables
USE DotNetCourseDatabase
SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[Users].[Email],
[Users].[Gender],
[Users].[Active],
[UserJobInfo].[UserId],
[UserJobInfo].[JobTitle],
[UserJobInfo].[Department]
FROM TutorialAppSchema.Users AS Users
    --INNER JOIN
    JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo
        ON UserJobInfo.UserId = Users.UserId
WHERE Active = 1
ORDER By Users.UserId DESC
--
USE DotNetCourseDatabase
SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[Users].[Email],
[Users].[Gender],
[Users].[Active],
[UserJobInfo].[UserId],
[UserJobInfo].[JobTitle],
[UserJobInfo].[Department]
FROM TutorialAppSchema.Users AS Users
    JOIN TutorialAppSchema.UserSalary AS UserSalary
        ON UserSalary.UserId = Users.UserId
    LEFT JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo
        ON UserJobInfo.UserId = Users.UserId
WHERE Active = 1
ORDER By Users.UserId DESC
--make a query run faster
CREATE CLUSTERED INDEX cix_UserSalary_UserId ON TutorialAppSchema.UserSalary(UserId)
--
DELETE FROM TutorialAppSchema.UserSalary WHERE UserId > 500
--when we use BETWEEN we also include the Lower and Upper Bound of the value we're checking
DELETE FROM TutorialAppSchema.UserSalary WHERE UserId BETWEEN 250 AND 500
--
SELECT [UserSalary].[UserId],
    [UserSalary].[Salary] 
FROM TutorialAppSchema.UserSalary AS UserSalary
    WHERE EXISTS (
        SELECT * FROM TutorialAppSchema.UserJobInfo AS UserJobInfo
            WHERE UserJobInfo.UserId = UserSalary.UserId)
                AND UserId <> 7
--merge tables
SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary
-- UNION --Distinct between two datasets
UNION ALL --Merge all data
SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary
--
