SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='HRManagement')
		drop database HRManagement
go

create database HRManagement;

go
use HRManagement;
create table Department (
	DepartmentID int identity(1,1) primary key,
	Name nvarchar(32)
);
create table Position (
	PositionID int identity(1,1) primary key,
	Name nvarchar(32)
);
create table Employee (
	EmpID int identity(1,1) primary key,
	FName nvarchar(32),
	LName nvarchar(32),
	BirthDate date,
	DepartmentID int foreign key references Department(DepartmentID),
	PositionID int foreign key references Position(PositionID),
	Email nvarchar(32),
	Number nvarchar(12),
	Holidays int default 0,
	isAdmin bit default 0,
	Password nvarchar(128)
);

create table EmployeeStatus (
	EmpID int foreign key references Employee(EmpID),
	Attendance int,
	LastAttend date,
	Strikes int
);
create table Salary (
	EmpID int foreign key references Employee(EmpID),
	BaseSal int,
	Extra int,
);
create table Fine (
	id int primary key identity(1,1),
	EmpID int foreign key references Employee(EmpID),
	Fine int,
	[Desc] nvarchar(1024)
);
create table TaskInfo (
	id int identity(1,1) primary key,
	Name nvarchar(128),
	[Desc] nvarchar(1024),
	Deadline smalldatetime
);
create table StaffTask (
	id int foreign key references TaskInfo(id),
	EmpID int foreign key references Employee(EmpID),
	Seen bit,
	Mark int
);
go
use HRManagement;

insert into Department(Name) values
('Administration/operations'),
('Marketing'),
('Customer service'),
('Designing'),
('Accounting');

insert into Position(Name) values
('Department Manager'),
('Manager''s Secretary'),
('Senior/Mentor'),
('Staff');

insert into Employee(FName, LName, BirthDate, DepartmentID, PositionID, Email, Number, [Password]) values
('Colby', 'Guerra', '1992-04-13', 2, 1, 'email1@company.com', '094875898', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Teegan', 'Lewis', '1998-11-22', 1, 3, 'email2@company.com', '084928495', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Toby', 'Sutton', '2000-09-03', 3, 2, 'email3@company.com', '064356336', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Ashley', 'Trang', '1995-05-06', 2, 2, 'email4@company.com', '059695043', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Evangeline', 'Connor', '1998-06-17', 1, 1, 'email5@company.com', '088734953', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Wade', 'Malone', '2000-06-01', 4, 2, 'email6@company.com', '093568356', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Nguyen', 'Minh', '2002-07-13', 4, 4, 'minh@company.com', '0965381566', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe'),
('Hoang', 'Quang', '1999-04-13', 4, 1, 'email7@company.com', '053589531', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe');

insert into Employee(Email, [Password], isAdmin) values
('admin@gmail.com', '$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe',1);
insert into EmployeeStatus (EmpID, Attendance, LastAttend, Strikes) values
(8, 8, '2022-03-08', 0);
insert into TaskInfo (Name, [Desc], Deadline) values
('test\n2line', 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', '2020-04-03 00:00:00'),
('The very first Task', 'First do this.\nThen do this\nFinish it', '2020-07-13 00:00:00'),
('The Second but longgggggggg Task', 'First do this.123444\nThen do this 568937.\n Finish it', '2022-04-01 18:00:00');
insert into StaffTask (id, EmpID, Seen, Mark) values
(1, 6, 1, 60),
(3, 6, 0, 0),
(3, 8, 0, 0),
(1, 8, 1, 70),
(2, 8, 0, 0);
insert into Fine (empid, fine, [desc]) values
(1, 50000, 'late for work'),
(8, 100000, 'late for assignment');

insert into EmployeeStatus (EmpID, Attendance, LastAttend, Strikes) values
(1, 8, '2022-03-08', 0),
(2, 7, '2022-03-08', 1),
(3, 8, '2022-03-08', 0),
(4, 6, '2022-03-08', 2),
(5, 6, '2022-03-08', 0),
(6, 7, '2022-03-08', 1),
(7, 8, '2022-03-08', 0);

insert into Salary (EmpID,BaseSal,Extra) values
(8, 2000000, 50000),
(1, 2500000, 100000),
(2, 1000000, 0),
(3, 1800000, 50000),
(4, 1800000, 0),
(5, 2500000, 0),
(6, 1800000, 80000),
(7, 2500000, 0);