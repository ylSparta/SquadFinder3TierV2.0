﻿--CREATE TABLE Members(
--Member_ID VARCHAR(5) NOT NULL PRIMARY KEY,
--First_Name VARCHAR(MAX) NOT NULL,
--Last_Name VARCHAR(MAX) NOT NULL
--)

--CREATE TABLE Squad(
--Squad_ID VARCHAR(7) NOT NULL PRIMARY KEY,
--Squad_Leader VARCHAR(MAX),
--No_Of_Squad_Members INT,
--Sport VARCHAR(MAX)
--)

--CREATE TABLE SquadMembers(
--Squad_Member_ID VARCHAR(13) NOT NULL PRIMARY KEY,
--Squad_ID VARCHAR(7) NOT NULL FOREIGN KEY REFERENCES Squad(Squad_ID),
--Member_ID VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES Members(Member_ID),
--)

--INSERT INTO SquadMembers(Squad_Member_ID, Squad_ID, Member_ID)
--VALUES('00989-9282731', '9282731', '00989'),
--('15243-9282731', '9282731', '15243'), 
--('15352-9282731', '9282731', '15352'), 
--('16253-9282731', '9282731', '16253'), 
--('30209-9282731', '9282731', '30209'), 
--('49392-9383842', '9383842', '49392'), 
--('74758-9383842', '9383842', '74758'), 
--('76255-9383842', '9383842', '76255'), 
--('78968-9383842', '9383842', '78968'), 
--('90866-9383842', '9383842', '90866')
