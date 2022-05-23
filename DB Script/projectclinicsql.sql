create database Clinic

use Clinic
go
--table for Staff
create table Staff(
FirstName varchar(20),
LastName varchar(20),
UserName varchar(30),
Passwrd varchar(20)

)
select *from Staff

insert Staff  values('Lakshmi','B','LakshmiFL1','1234')
insert Staff  values('Nithya','S','NithyaFL2','4321')
insert Staff  values('Shanthi','D','ShanthiFL3','9876')
insert Staff  values('Anandhi','P','AnandhiFL4','6789')


--table for Doctor
create table Doctor(
DoctorId int identity(1,1),
Doctor_FirstName varchar(20),
Doctor_LastName varchar(20),
Doctor_Sex varchar(10),
Doctor_Specialisation varchar(30),
Doctor_VisitingHours varchar(30) 

constraint pk_doc Primary Key (DoctorId)
)

--table for patient
create table Patient(
PatientId int identity(1,1),
Patient_FirstName varchar(20),
Patient_LastName varchar(20),
Patient_Sex varchar(20),
Patient_Age int,
Patient_Date_Of_Birth varchar(20),

constraint pk_pat primary key (PatientId),
constraint ck_age check(Patient_Age<120)
)

--table for scheduleappointment
create table ScheduleAppointment(
PatientId int,
Specialisation varchar(30),
Doctor varchar(20),
Visit_Date varchar(20),
Appointment_Time varchar(20)

constraint fk_app foreign key (PatientId) references Patient (PatientId)
)




--procedure for Login
create proc ProcLogin
@User varchar(30),
@Pass varchar(20)
as
select * from Staff where UserName like @User and Passwrd like @Pass


select*from Staff



--procedure for Adddoctor
create proc ProcDoc
@docfn varchar(20),
@docln varchar(20),
@docsex varchar(10),
@docspec varchar(30),
@docvisit varchar(30)
as
insert into Doctor (Doctor_FirstName,Doctor_LastName,Doctor_Sex,Doctor_Specialisation,Doctor_VisitingHours) 
values(@docfn,@docln,@docsex,@docspec,@docvisit)

--select * from Doctor where Doctor_Specialisation like 'swe%'


--procedure for AddPatient


create proc ProcPat
@patfn varchar(20),
@patln varchar(20),
@patsex varchar(20),
@patdob varchar(20)
as
begin
declare @patage int
set @patage=(select DATEDIFF(year,@patdob,getdate()))
insert into Patient(Patient_FirstName,Patient_LastName,Patient_Sex,Patient_Age,Patient_Date_Of_Birth) 
values(@patfn,@patln,@patsex,@patage,@patdob) 
end


--exec ProcPat'veni','k','Female','2000-05-09'

select * from Patient


--procedure for FixAppointment
create proc ProcApp
@patid int,
@spec varchar(20),
@doc varchar(20),
@visit varchar(20),
@app varchar(20)
as
insert into ScheduleAppointment (PatientId,Specialisation,Doctor,Visit_Date,Appointment_Time) 
values(@patid,@spec,@doc,@visit,@app)



select *from ScheduleAppointment
select*from Doctor

--procedure for cancelappointment
create  proc CancelAppoint
@patientid varchar(20)
as
delete from ScheduleAppointment where PatientId=@patientid


--procedure  for schedule informaation
create proc SelectAll
as
select * from ScheduleAppointment

--procedure for doctor information
create proc SelectDoctor
as
select * from Doctor


--procedure for patient information
create proc SelectPatient
as
select * from Patient

select*from Doctor


