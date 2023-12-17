create database ehou_it15;

create table app_user (
	id int identity (1, 1),
	username varchar(50) not null,
	password_hash varchar(max) not null,
	full_name varchar(max) not null,
	email varchar(max) not null,
	phone varchar(max) not null
);