CREATE TABLE Students
(
  Id INT PRIMARY KEY IDENTITY,
  FirstName nvarchar(30) not null,
  LastName nvarchar(30) not null,
  AverageRating int not null
)