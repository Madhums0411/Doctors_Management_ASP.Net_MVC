create database Doctors_DB
use Doctors_DB

create table Roll_table
(
Role_Id int primary key not null,
Role_Name varchar(255) not null
)
execute sp_rename 'Roll_table.Roll_Name','Role_Name','Column'
select * from Roll_table
execute sp_rename 'Roll_table','Role_table'
create table User_table
(
UserID int primary key identity(101,1),
Role_Id int foreign key references Role_table(Role_Id),
Name varchar(255),
Password varchar(255),
Email_id varchar(255)
)

select * from User_table


create table Patient_table
(
Patient_id int primary key identity(2501,1) not null,
UserID int foreign key references User_table(UserID),
Profile varchar(255),
Name varchar(255),
Date_of_birth date,
Gender varchar(255),
Blood_group varchar(255),
Medical_history varchar(255),
Phone_number varchar(255),
Address varchar(255),
Trash int
)
delete from Patient_table
where Patient_id=2501
create table Doctors_table
(
Doctor_id int primary key identity(5001,1),
UserID int foreign key references User_table(UserID),
Profile varchar(255),
Name varchar(255),
Age int,
Gender varchar(255),
Qualification varchar(255),
Job_specification varchar(255),
Experience_year int,
Contact_number bigint,
Doctor_fee int,
Trash int
)
select * from User_table
delete from Patient_table
where Patient_id =2506
select * from Doctors_table
select * from Patient_table

create or alter procedure SP_Doctor_AddDetails
(
@UserID int,
@Profile varchar(255),
@Name varchar(255),
@Age int,
@Gender varchar(255),
@Qualification varchar(255),
@Job_specification varchar(255),
@Experience_year int,
@Contact_number bigint,
@Doctor_fee int,
@Trash int
)
as begin
insert into Doctors_table(UserID,Profile,Name,Age,Gender,Qualification,Job_specification,Experience_year,Contact_number,Doctor_fee,Trash)
values(@UserID,@Profile,@Name,@Age,@Gender,@Qualification,@Job_specification,@Experience_year,@Contact_number,@Doctor_fee,@Trash)
end

select * from Doctors_table

create or alter procedure SP_Doctordetails_byId
(
@UserID int
)
as begin
select * from Doctors_table
where UserID=@UserID
end

create or alter procedure SP_Doctor_Edit
(
@UserID int,
@Profile varchar(255),
@Name varchar(255),
@Age int,
@Gender varchar(255),
@Qualification varchar(255),
@Job_specification varchar(255),
@Experience_year int,
@Contact_number bigint,
@Doctor_fee int
)
as begin
update Doctors_table
set Profile=@Profile,Name=@Name,Age=@Age,Gender=@Gender,Qualification=@Qualification,Job_specification=@Job_specification,
Experience_year=@Experience_year,Contact_number=@Contact_number,Doctor_fee=@Doctor_fee where UserID=@UserID
end

create or alter procedure SP_doctor_Delete
(
@UserID int
)
as begin
delete from Doctors_table
where UserID=@UserID
end

execute SP_Doctordetails_byId
113
create or alter procedure SP_Patientdetails_byId
(
@UserID int
)
as begin
select * from Patient_table
where UserID=@UserID
end
execute SP_Doctor_AddDetails
' ','Madhu',28,'Male','MBBS','Surgeon',2,9632355684,1000,0
create or alter procedure SP_Doctor_DoctorList
as begin
select * from Doctors_table
end
update Doctors_table
set UserID=113 where Doctor_id=5002


create or alter procedure SP_Patient_AddDetails
(
@UserID int,
@Profile varchar(255),
@Name varchar(255),
@Date_of_birth date,
@Gender varchar(255),
@Blood_group varchar(255),
@Medical_history varchar(255),
@Phone_number varchar(255),
@Address varchar(255),
@Trash int
)
as begin
insert into Patient_table(UserID,Profile,Name,Date_of_birth,Gender,Blood_group,Medical_history,Phone_number,Address,Trash)
values(@UserID,@Profile,@Name,@Date_of_birth,@Gender,@Blood_group,@Medical_history,@Phone_number,@Address,@Trash)
end



create or alter procedure SP_Patient_PatientList
as begin
select * from Patient_table
end

create or alter procedure SP_Patient_Edit
(
@UserID int,
@Profile varchar(255),
@Name varchar(255),
@Date_of_birth date,
@Gender varchar(255),
@Blood_group varchar(255),
@Medical_history varchar(255),
@Phone_number varchar(255),
@Address varchar(255)
)
as begin
update Patient_table
set Profile=@Profile,Name=@Name,Date_of_birth=@Date_of_birth,Gender=@Gender,Blood_group=@Blood_group,
Medical_history=@Medical_history,Phone_number=@Phone_number,Address=@Address where UserID=@UserID
end

select * from User_table
execute SP_Patient_Edit
@Profile='jpg',
@Name='Akash',
@Date_of_birth ='1996-04-04',
@Gender='Male',
@Blood_group ='A+',
@Medical_history ='BP',
@Phone_number ='9632355684',
@Address='Ramagiri',
@Patient_id=2503


select * from Patient_table
delete from Patient_table
where Patient_id=2508
update Patient_table
set UserID=109 where Patient_id=2503
create table Appointment_table
(
Ap_id int primary key identity(701,1) not null,
Patient_id int foreign key references Patient_table(Patient_id)not null,
P_Name varchar(255),
Ap_Date datetime,
TimeSlotStart time,
TimeSlotEnd time,
Purpose varchar(255),
Doctor_id int foreign key references Doctors_table(Doctor_id) not null,
D_Name varchar(255)
)

select * from Patient_table


create or alter procedure SP_AP_create
(
@Patient_id int,
@P_Name varchar(255),
@Ap_Date datetime,
@TimeSlotStart time,
@TimeSlotEnd time,
@Purpose varchar(255),
@Doctor_id int ,
@D_Name varchar(255)
)
as begin
insert into Appointment_table
values(@Patient_id,@P_Name,@Ap_Date,@TimeSlotStart,@TimeSlotEnd,@Purpose,@Doctor_id,@D_Name)
end

execute SP_AP_create
2504,
'Varu',
'2023-06-17',
'General',
5013,
'Madhu'

create or alter procedure SP_AP_Getall
as begin
select * from Appointment_table
end
select * from Appointment_table

select * from Patient_table
select * from User_table

create or alter procedure SP_AP_GetAp_ByID
(
@Patient_id int
)
as 
begin
select * from Appointment_table
where Patient_id = @Patient_id
end

create or alter procedure SP_AP_Edit
(
@Patient_id int,
@P_Name varchar(255),
@Ap_Date datetime,
@TimeSlotStart time,
@TimeSlotEnd time,
@Purpose varchar(255),
@Doctor_id int ,
@D_Name varchar(255)
)
as begin
update Appointment_table
set P_Name=@P_Name,Ap_Date=@Ap_Date,TimeSlotStart=@TimeSlotStart,TimeSlotEnd=@TimeSlotEnd,Purpose=@Purpose,
Doctor_id=@Doctor_id,D_Name=@D_Name where Patient_id=@Patient_id
end




execute SP_AP_GetAp_ByID
2514


drop table Appointment_table
create or alter procedure SP_Role_insert
(
@Role_Id int,
@Role_Name varchar(255)
)
as
begin
begin try
if @Role_Id<4
begin
insert into Role_table
values(@Role_Id,@Role_Name)
end
else
begin
Print 'Role id should be in between 1 to 3'
end
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end

execute SP_Role_insert
4,'Patient'

create or alter procedure SP_Role_retrieve
as
begin
select * from Role_table
end

execute SP_Role_retrieve

create or alter procedure SP_user_insert
(
@Role_Id int,
@Name varchar(255),
@Password varchar(255),
@Email_id varchar(255)
)
as
begin
begin try
if @Role_Id<4
begin
insert into User_table
values(@Role_Id,@Name,@Password,@Email_id)
Print 'User detail updated successfully'
end
else
begin
Print 'Roleid should be match to the Role table'
end
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end

create or alter procedure SP_UserRetrive_byRoleid
(
@Role_Id int
)
as begin
begin try
Print 'Role Id is 2 for Doctor and 3 for Patient'
if @Role_Id in(2,3)
begin
select * from User_table
where @Role_Id=Role_Id
end
else
begin
Print 'Roleid is not matching'
end
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end


execute SP_user_Retrieve


create or alter procedure SP_userbyID
(
@UserID int
)
as begin
begin try
select * from User_table
where @UserID=UserID
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end

create or alter procedure SP_user_update
(
@UserID int,
@Role_Id int,
@Name varchar(255),
@Password varchar(255),
@Email_id varchar(255)
)
as begin
begin try
update User_table
set Role_Id=@Role_Id, Name=@Name, Password=@Password, Email_id=@Email_id
where @UserID=UserID
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end

execute SP_user_update
@Role_Id=1,
@Name='Nayan',
@Password=4512475224,
@Email_id='nayan@gmail.com',
@UserID=120


execute SP_userbyID
107


create or alter procedure SP_user_delete
(
@UserID int
)
as begin
delete from User_table
where UserID=@UserID
end
execute SP_user_delete
124
select * from User_table
create or alter procedure SP_user_login
(
@Email_id varchar(255),
@Password varchar(255)
)
as begin
begin try
select * from User_table
where Email_id=@Email_id and Password=@Password
end try
begin catch
select
ERROR_LINE() as Errorline,
ERROR_MESSAGE() as Errormessage,
ERROR_NUMBER() as Errornumber,
ERROR_PROCEDURE() as Errorprocedure,
ERROR_STATE() as Errorstate,
ERROR_SEVERITY() as Errorsererity
end catch
end

delete from User_table
where UserID between 104 and 106
execute SP_user_login
'manu@gmail.com','9632356'
execute SP_user_Retrieve



create or alter procedure SP_Patient_insert
(
@Image varchar(255),
@UserID int,
@Name varchar(255),
@Date_of_birth date,
@Gender varchar(255),
@Blood_group varchar(255),
@Medical_history varchar(255),
@Phone_number varchar(255),
@Patient_address varchar(255)
)
as begin
insert into Patient_table
values(@Image,@UserID,@Name,@Date_of_birth,@Gender,@Blood_group,@Medical_history,@Phone_number,@Patient_address)
end

create or alter procedure SP_Patient_retrieve
as begin
select * from Patient_table
end







