﻿-- ======================================================
-- Skrypt SQL, który utworzy podstawową strukturę
-- bazy danych do naszej aplikacji
-- ======================================================
create database LostPeopleRegister;
go

use LostPeopleRegister;
go


create table account_role (
    id int not null primary key identity(1, 1),
    name nvarchar(100) not null unique
);
go


create table account
(
	  id int not null primary key identity(1, 1)
	, username varchar(20) not null unique
	, "password" varchar(50) not null
	, first_name nvarchar(20) not null
	, last_name nvarchar(30) not null
	, email_address varchar(40) not null unique
	, birth_date date
	, created_date smalldatetime default getdate()
    , account_role_id int not null foreign key references account_role(id) default 1
	, constraint birth_date_check check(birth_date < getdate())
);
go



create table lost_person_status
(
	  id int not null primary key identity(1, 1)
	, name varchar(100) not null unique
);

create table lost_person
(
	  id int not null primary key identity(1, 1)
	, created_account_id int not null foreign key references account(id)
	, first_name nvarchar(20) not null
	, last_name nvarchar(30) not null
	, lost_person_date smalldatetime not null
	, last_place_name nvarchar(100) not null
	, height int not null
	, created_date smalldatetime default getdate()
	, status_id int not null foreign key references lost_person_status(id)
);
go


create table lost_person_address_city
(
	  id int not null primary key identity(1, 1)
	, lost_person_id int not null unique foreign key references lost_person(id)
	, city nvarchar(100) not null
	, street nvarchar(100) not null
	, apartment_number int not null
	, flat_number int not null
	, constraint apartment_number_check check(apartment_number > 0)
	, constraint flat_number_check check(flat_number > 0)
);
go


create table lost_person_address_village
(
	  id int not null primary key identity(1, 1)
	, lost_person_id int not null unique foreign key references lost_person(id)
	, village nvarchar(100) not null
	, apartment_number int not null
	, constraint apartment_number check(apartment_number > 0)
);
go


create table lost_person_image
(
	  id int not null primary key identity(1, 1)
	, lost_person_id int not null foreign key references lost_person(id)
	, image_name nvarchar(100) not null
	, constraint lost_person_id__image_name__unique unique(lost_person_id, image_name)
);
go


create table lost_person_additional_details
(
	  id int not null primary key identity(1, 1)
	, lost_person_id int not null foreign key references lost_person(id)
	, attribute nvarchar(100) not null
	, "value" nvarchar(200) not null
	, constraint lost_person_id__attribute__unique unique(lost_person_id, attribute)
);
go