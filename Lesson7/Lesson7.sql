CREATE TABLE Student (
    StudentId INT PRIMARY KEY identity(1,1),
    Name VARCHAR(100),
    Surname VARCHAR(100),
    Age INT,
    Email VARCHAR(100),
    GroupId INT,
    AverageGrade DECIMAL(5,2),
    FOREIGN KEY (GroupId) REFERENCES [Group](GroupId)
);

CREATE TABLE [Group] (
    GroupId INT PRIMARY KEY identity(1,1),
    GroupName VARCHAR(100),
    StudentsCount INT DEFAULT 0
);

CREATE TABLE Course (
    CourseId INT PRIMARY KEY identity(1,1),
    CourseName VARCHAR(100),
    GroupId int foreign key REFERENCES Groups(GroupId),
    TeacherId INT,
    FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId)
);

CREATE TABLE Teacher (
    TeacherId INT PRIMARY KEY identity(1,1),
    Name VARCHAR(100),
    Surname VARCHAR(100)
);

CREATE TABLE Grade (
    GradeId INT PRIMARY KEY identity(1,1),
    StudentId INT,
    CourseId INT,
    Grade INT,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

CREATE TABLE Attendance (
    AttendanceId INT PRIMARY KEY identity(1,1),
    StudentId INT,
    Date DATE,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE RetakeList (
    StudentId INT,
    CourseId INT,
    PRIMARY KEY (StudentId, CourseId),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

CREATE TABLE Payment (
    PaymentId INT PRIMARY KEY identity(1,1),
    StudentId INT,
    Amount DECIMAL(10,2),
    Date DATE,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE Warnings (
    WarningId INT PRIMARY KEY identity(1,1),
    StudentId INT,
    Reason VARCHAR(255),
    Date DATE,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE GradeHistory (
    HistoryId INT PRIMARY KEY identity(1,1),
    GradeId INT,
    OldGrade INT,
    ChangeDate DATETIME,
    FOREIGN KEY (GradeId) REFERENCES Grade(GradeId)
);




CREATE TRIGGER CheckStudentsCount on Student
FOR INSERT
AS
BEGIN
    IF (SELECT COUNT(*) FROM Student
        INNER JOIN [Group] on [Group].GroupId = Student.GroupId) >= 30
        BEGIN
            print(N'Student limit !');
            ROLLBACK TRANSACTION;
        END
END





CREATE TRIGGER UpdateStudents on Student
FOR INSERT
AS
BEGIN
    update Groups set StudentsCount = StudentsCount + 1
END



CREATE TRIGGER AutoREgister on Student
FOR INSERT
AS
BEGIN
    if(inserted.GroupId is null)
    begin
        update inserted set GroupId = (select GroupId from Groups inner join Course on Course.GroupId = Groups.GroupId where CourseName = 'Intro Programming')
    end
END





