create database schoolManagement
use schoolManagement

-----------------------------------Admin---------------------------------------------
create table RoleCreation
(
ID int primary key identity(1,1),
Name varchar(500),
IsDeleted bit
);

select * from RoleCreation
create table Registration
(
ID int primary key identity(1,1),
RoleID int foreign key references RoleCreation(ID),
Name varchar(500),
Email varchar(500),
PhoneNumber varchar(10),
IsDeleted bit
);


Select *from Registration
alter table Registration
add Password varchar(100);

create table StudentRegistration
(
ID int primary key identity(1,1),
RoleID int foreign key references RoleCreation(ID),
StudentUSN varchar(50),
Name varchar(500),
Email varchar(500),
PhoneNumber varchar(10),

IsDeleted bit
);

alter table StudentRegistration
 add Gender varchar(20),
AadharCard varchar(100),
Address varchar(500)
  
  Select * from StudentRegistration


Create table DashboardAnalytics
(
ID int primary key identity(1,1),
StudentsTotal varchar(500),
TeachersTotal varchar(500),
ClassesTotal varchar(500),
Events varchar(500),
IsDeleted bit
);

select * from RoleCreation

select * from Registration

select * from DashboardAnalytics

------------------------------------Teacher----------------------------------------------------

create table TeacherDetails 
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
Geander varchar(20),
Qulification varchar(100),
Address varchar(500),
JoiningDate varchar(50),
AccountNumber varchar(50),
Attendance varchar(50),
TotalLeaves varchar(50),
IsDeleted bit
);


create table studentAttendance
(
ID int primary key identity(1,1),
StudentDetailID int foreign key references StudentDetails(ID),
Attendance varchar(90),
Isdeleted bit
);

alter table studentAttendance 
add Date varchar(100);


Drop table studentAttendance;


alter table TeacherDetails
drop column Name,
Email ;

alter table TeacherDetails 
add phone varchar(10);

alter table TeacherDetails 
add Name varchar(100);

alter table TeacherDetails 
add Email varchar(100);



create table SubjectTakenByTeacher
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
SubjectName varchar(200),
Time varchar(200),
IsDeleted bit
);

create table  ApprovedforExamination
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
TeacherDetailsID int foreign key references TeacherDetails(ID),
ExamHallNumber  varchar(200),
IsDeleted bit
);


alter table ApprovedforExamination
add SubjectTakenID int foreign key
references SubjectTakenByTeacher(ID);


alter table TeacherDetails
add RoleID int foreign key
references RoleCreation(ID);


alter table SubjectTakenByTeacher
add RoleID int foreign key
references RoleCreation(ID);



create table subject
(
ID int primary key identity(1,1),
SubjectName varchar(100),
IsDeleted bit

);


create table MarksEntry
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
ExamID int foreign key references  Exams(ID),
Marks varchar(200),
IsDeleted bit
);

alter table ResultEntry
add TotalMakes varchar(50);

alter table ResultEntry
add passingMarks varchar(50);


alter table MarksEntry
add passingMarks varchar(50);


alter table MarksEntry
add TotalMakes varchar(50);

create table  ResultEntry
(
ID int Primary key  identity(1,1),
RegistrationID int foreign key references Registration(ID),
ExamID int foreign key references  Exams(ID),
MarksEntryID int foreign key references MarksEntry(ID),

Result varchar(200),
IsDeleted bit
);

alter table ResultEntry
add SubjectID int foreign key
references subject(ID);

alter table ResultEntry
add StudentDetailID int foreign key
references StudentDetails(ID);


alter table MarksEntry
add SubjectID int foreign key
references subject(ID);

alter table MarksEntry
add StudentDetailID int foreign key
references StudentDetails(ID);

alter table SubjectTakenByTeacher
add SubjectID int foreign key
references subject(ID);


alter table SubjectTakenByTeacher
add TeacherDetailsID int foreign key
references TeacherDetails(ID);



alter table ApprovedforExamination
add SubjectID int foreign key
references subject(ID);

select * from TeacherDetails

select * from SubjectTakenByTeacher

select * from ApprovedforExamination


------------------------------------------------Student----------------------------------------------------

create table StudentDetails
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
Gender varchar(20),
Class varchar(100),
Address varchar(500),
Attendance varchar(50),
IsDeleted bit
);

alter table StudentDetails
add SubjectID int foreign key
references subject(ID);


alter table StudentDetails
add ResultEntryid int foreign key
references ResultEntry(ID);

alter table StudentDetails
add MarksID int foreign key
references MarksEntry(ID);


select * from StudentDetails

create table Leave
(
ID int primary key identity(1,1),
StudentDetailID int foreign key references StudentDetails(ID),
USN varchar(50),
Name varchar(50),
reason varchar(5000),
approved varchar(100),
Isdeleted bit
);



create table StudentLeave 
(
ID int primary key identity(1,1),
LeaveID int foreign key references Leave(ID),
approved varchar(100),
Isdeleted bit

);




select * from StudentLeave;
select * from Leave


alter table StudentDetails 
add Usn varchar(100);


alter table Leave
add USN varchar(50),
Name varchar(50);

alter table Leave
add USN varchar(50),
Name varchar(50);

alter table StudentDetails 
add Name varchar(100);

alter table StudentDetails 
add Email varchar(100);


alter table StudentDetails 
add phone varchar(10);


create table Feesinfo
(
ID int primary key identity(1,1),
RegistrationID int foreign key references Registration(ID),
TotalFees varchar(500),
IsDeleted bit
);

alter table Feesinfo 
add PaidFess varchar(100),
DueFees varchar(100);



alter table Feesinfo
add StudentDetailID int foreign key
references StudentDetails(ID);

select * from Feesinfo



create table Exams
(
ID int primary key identity(1,1),
SubjectName varchar(200),
ExamTiming varchar(200),
ExamDuration varchar(200),
IsDeleted bit
);




alter table StudentDetails
add RoleID int foreign key
references RoleCreation(ID);

alter table ResultEntry
add RoleID int foreign key
references RoleCreation(ID);

alter table MarksEntry
add RoleID int foreign key
references RoleCreation(ID);





alter table StudentDetails
add StudentRegistrationID int foreign key
references StudentRegistration(ID);

alter table ResultEntry
add StudentRegistrationID int foreign key
references StudentRegistration(ID);


alter table MarksEntry
add StudentRegistrationID int foreign key
references StudentRegistration(ID);



alter table Feesinfo
add StudentRegistrationID int foreign key
references StudentRegistration(ID);

select * from StudentDetails

select * from Feesinfo

select * from Exams

select * from MarksEntry

select * from ResultEntry




create table checkresult
(
Id int primary key identity(1,1),
markID int foreign key references MarksEntry(ID),
ResultID int foreign key references ResultEntry(ID),
IsDeleted bit 
);


alter table checkresult
add StudentDetailID int foreign key
references StudentDetails(ID);



select * From checkresult


create table LeaveStatus(
Id int primary key identity(1,1),
LeaveID int foreign key references Leave(ID),
ISdeleted bit

);

select * From LeaveStatus
