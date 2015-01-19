CREATE TABLE helpdesk.dbo.tblCustomers (
	custID uniqueidentifier NOT NULL,
	custName varchar(50) NOT NULL,
	PRIMARY KEY (custID)
)
GO
CREATE TABLE helpdesk.dbo.tblDepartments (
	deptID uniqueidentifier NOT NULL,
	deptDescription varchar(255) NOT NULL,
	PRIMARY KEY (deptID)
)
GO
CREATE TABLE helpdesk.dbo.tblEmployees (
	empSSN varchar(15) NOT NULL,
	empName varchar(50) NOT NULL,
	empDept varchar(50),
	PRIMARY KEY (empSSN)
)
GO
CREATE TABLE helpdesk.dbo.tblStatuses (
	statusID uniqueidentifier NOT NULL,
	statusName varchar(255) NOT NULL,
	statusDescription varchar(255),
	PRIMARY KEY (statusID)
)
GO
CREATE TABLE helpdesk.dbo.tblTickets (
	tixID uniqueidentifier NOT NULL,
	tixNotes varchar(max),
	tixDateCreated varchar(255) NOT NULL,
	tixAssignedTo varchar(50),
	tixDateCompleted varchar(50),
	tixLastContacted varchar(255) NOT NULL,
	custID uniqueidentifier NOT NULL,
	empSSN varchar(15),
	deptID uniqueidentifier NOT NULL,
	statusID uniqueidentifier,
	PRIMARY KEY (tixID)
)
GO
INSERT INTO helpdesk.dbo.tblCustomers(custID, custName) VALUES ('644586EB-8967-4BA7-AB7D-174EBAB44742', 'Tim Jeffries')
GO
INSERT INTO helpdesk.dbo.tblCustomers(custID, custName) VALUES ('7684D3CA-6B0F-4B6A-9FE5-9ECC1B7FE650', 'Rick Steven')
GO
INSERT INTO helpdesk.dbo.tblDepartments(deptID, deptDescription) VALUES ('556172F9-79F8-45BC-A376-373F649900E7', 'Networking')
GO
INSERT INTO helpdesk.dbo.tblDepartments(deptID, deptDescription) VALUES ('B1567510-21A2-4AF7-9375-428BABA877F0', 'Programming')
GO
INSERT INTO helpdesk.dbo.tblEmployees(empSSN, empName, empDept) VALUES ('555-32-1234', 'Aesop Fable', '556172f9-79f8-45bc-a376-373f649900e7')
GO
INSERT INTO helpdesk.dbo.tblEmployees(empSSN, empName, empDept) VALUES ('654-93-2345', 'Tom Jones', 'b1567510-21a2-4af7-9375-428baba877f0')
GO
INSERT INTO helpdesk.dbo.tblStatuses(statusID, statusName, statusDescription) VALUES ('B8F886D7-DFB6-4AE7-8003-2D5A4C9AF314', 'Done', 'This is done')
GO
INSERT INTO helpdesk.dbo.tblStatuses(statusID, statusName, statusDescription) VALUES ('2919E093-B9E5-4CB1-86F0-BEF1A1C95A87', 'Pending', 'This is waiting a response before completing')
GO
INSERT INTO helpdesk.dbo.tblTickets(tixID, tixNotes, tixDateCreated, tixAssignedTo, tixDateCompleted, tixLastContacted, custID, empSSN, deptID, statusID) VALUES ('4DCD4F3E-A2B8-4D99-8632-AD594A7F4AC1', 'This was even harder than the last ticket', '11/14/2014', 'Aesop Fable', '11/16/2014', '11/16/2014', '644586EB-8967-4BA7-AB7D-174EBAB44742', '555-32-1234', '556172F9-79F8-45BC-A376-373F649900E7', 'B8F886D7-DFB6-4AE7-8003-2D5A4C9AF314')
GO
INSERT INTO helpdesk.dbo.tblTickets(tixID, tixNotes, tixDateCreated, tixAssignedTo, tixDateCompleted, tixLastContacted, custID, empSSN, deptID, statusID) VALUES ('7C9DB5AD-E4C5-4584-B0CE-F4012C5C0D31', 'This was hard', '11/25/2014', 'Aesop Fable', '11/25/2014', '11/25/2014', '7684D3CA-6B0F-4B6A-9FE5-9ECC1B7FE650', '555-32-1234', '556172F9-79F8-45BC-A376-373F649900E7', null)
GO
ALTER TABLE helpdesk.dbo.tblTickets
	ADD FOREIGN KEY (custID) 
	REFERENCES tblCustomers (custID)
GO

ALTER TABLE helpdesk.dbo.tblTickets
	ADD FOREIGN KEY (deptID) 
	REFERENCES tblDepartments (deptID)
GO

ALTER TABLE helpdesk.dbo.tblTickets
	ADD FOREIGN KEY (empSSN) 
	REFERENCES tblEmployees (empSSN)
GO

ALTER TABLE helpdesk.dbo.tblTickets
	ADD FOREIGN KEY (statusID) 
	REFERENCES tblStatuses (statusID)
GO


