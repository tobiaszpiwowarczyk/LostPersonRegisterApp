use LostRegisterApp;
go

set IDENTITY_INSERT dbo.account_role ON
insert into account_role(id, name) values (1, 'Użytkownik');
insert into account_role(id, name) values (2, 'Administrator');
set IDENTITY_INSERT dbo.account_role OFF
go



SET IDENTITY_INSERT dbo.account ON 

INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (1, N'jkowalski', N'hasl0123', N'Jan', N'Kowalski', N'jkowalski@gmail.com', CAST(N'2013-06-21' AS Date), CAST(N'2021-03-30T00:26:00' AS SmallDateTime), 2)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (2, N'mstephens', N'hasl0123', N'Madeson', N'Stephens', N'mstephens@gmail.com', CAST(N'1996-05-12' AS Date), CAST(N'2020-06-25T16:07:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (3, N'lallison', N'hasl0123', N'Logan', N'Allison', N'lallison@gmail.com', CAST(N'1982-03-26' AS Date), CAST(N'2022-03-18T09:04:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (4, N'ycantrell', N'hasl0123', N'Yoshi', N'Cantrell', N'ycantrell@gmail.com', CAST(N'1977-06-09' AS Date), CAST(N'2019-05-03T16:05:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (5, N'ksmall', N'hasl0123', N'Kyla', N'Small', N'ksmall@gmail.com', CAST(N'0001-01-01' AS Date), CAST(N'2021-04-15T23:38:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (6, N'mjoyce', N'hasl0123', N'Magee', N'Joyce', N'mjoyce@gmail.com', CAST(N'1988-09-06' AS Date), CAST(N'2019-12-24T15:12:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (7, N'xshepherd', N'hasl0123', N'Xaviera', N'Shepherd', N'xshepherd@gmail.com', CAST(N'1996-01-17' AS Date), CAST(N'2020-09-18T21:10:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (8, N'jfarley', N'hasl0123', N'Justin', N'Farley', N'jfarley@gmail.com', CAST(N'1993-12-27' AS Date), CAST(N'2020-05-27T12:06:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (9, N'ehester', N'hasl0123', N'Erasmus', N'Hester', N'ehester@gmail.com', CAST(N'1999-09-24' AS Date), CAST(N'2019-10-23T23:10:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (10, N'areid', N'hasl0123', N'Aileen', N'Reid', N'areid@gmail.com', CAST(N'1987-10-07' AS Date), CAST(N'2019-05-24T13:06:00' AS SmallDateTime), 1)
INSERT dbo.account (id, username, password, first_name, last_name, email_address, birth_date, created_date, account_role_id) VALUES (11, N'kleonard', N'hasl0123', N'Kaye', N'Leonard', N'kleonard@gmail.com', CAST(N'1978-05-07' AS Date), CAST(N'2021-12-12T20:13:00' AS SmallDateTime), 1)
SET IDENTITY_INSERT dbo.account OFF
GO
SET IDENTITY_INSERT dbo.lost_person_status ON 

INSERT dbo.lost_person_status (id, name) VALUES (1, N'Nieodnaleziony')
INSERT dbo.lost_person_status (id, name) VALUES (2, N'Odnaleziony')
SET IDENTITY_INSERT dbo.lost_person_status OFF
GO
SET IDENTITY_INSERT dbo.lost_person ON 

INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (1, 1, N'Anna', N'Nowak', CAST(N'2020-05-20T00:00:00' AS SmallDateTime), N'Radom', 123, CAST(N'2021-04-14T02:04:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (2, 1, N'Andrzej', N'Kozłowski', CAST(N'2020-06-15T00:00:00' AS SmallDateTime), N'Warszawa', 182, CAST(N'2021-04-15T15:38:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (3, 1, N'Antoni', N'Kowalewski', CAST(N'2019-06-07T00:00:00' AS SmallDateTime), N'Szczecin', 187, CAST(N'2021-04-15T17:28:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (4, 1, N'Anna', N'Kozłowska', CAST(N'2021-03-18T00:00:00' AS SmallDateTime), N'Warszawa', 175, CAST(N'2021-04-15T17:33:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (5, 2, N'Andrzej', N'Poniedzielski', CAST(N'2021-04-02T00:00:00' AS SmallDateTime), N'Kraków', 179, CAST(N'2021-04-15T20:40:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (6, 2, N'Joanna', N'Kowalska', CAST(N'2021-03-25T00:00:00' AS SmallDateTime), N'Radom', 175, CAST(N'2021-04-15T20:49:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (7, 3, N'Przemysław', N'Kowalski', CAST(N'2021-04-13T00:00:00' AS SmallDateTime), N'Warszawa', 191, CAST(N'2021-04-15T20:59:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (10, 3, N'Krzysztof', N'Adamczyk', CAST(N'2021-04-07T00:00:00' AS SmallDateTime), N'Łódź', 178, CAST(N'2021-04-15T21:20:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (11, 4, N'Małgorzata', N'Krzemińska', CAST(N'2021-03-03T00:00:00' AS SmallDateTime), N'Siedlce', 178, CAST(N'2021-04-15T21:30:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (12, 4, N'Krzysztof', N'Kozłowski', CAST(N'2021-03-13T00:00:00' AS SmallDateTime), N'Warszawa', 197, CAST(N'2021-04-15T21:43:00' AS SmallDateTime), 1)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (16, 5, N'Julia', N'Kowalewska', CAST(N'2021-02-18T00:00:00' AS SmallDateTime), N'Poznań', 172, CAST(N'2021-04-15T22:27:00' AS SmallDateTime), 2)
INSERT dbo.lost_person (id, created_account_id, first_name, last_name, lost_person_date, last_place_name, height, created_date, status_id) VALUES (17, 7, N'Kamil', N'Skowroński', CAST(N'2021-04-06T00:00:00' AS SmallDateTime), N'Olsztyn', 184, CAST(N'2021-04-15T22:32:00' AS SmallDateTime), 1)
SET IDENTITY_INSERT dbo.lost_person OFF
GO
SET IDENTITY_INSERT dbo.lost_person_additional_details ON 

INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (1, 1, N'Blizna', N'pod okiem')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (2, 2, N'kolor oczu', N'czarny')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (3, 2, N'sylwetka', N'szczupła')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (4, 4, N'kolor oczu', N'niebieskie')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (5, 4, N'sylwetka', N'szczupła')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (6, 4, N'wiek', N'65 lat')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (7, 6, N'sylwetka', N'szczupła')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (8, 6, N'piegi', N'na twarzy')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (13, 10, N'zarost', N'lekki')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (14, 10, N'kurtka', N'czerwona z kapturem')
INSERT dbo.lost_person_additional_details (id, lost_person_id, attribute, value) VALUES (15, 17, N'okulary', N'przeciwsłoneczne')
SET IDENTITY_INSERT dbo.lost_person_additional_details OFF
GO
SET IDENTITY_INSERT dbo.lost_person_address_city ON 

INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (1, 2, N'Pruszków', N'Świętokrzyska', 23, 12)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (2, 3, N'Szczecin', N'Kościela', 63, 42)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (3, 6, N'Radom', N'Żeromskiego', 2, 34)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (4, 7, N'Warszawa', N'Sienkiewicza', 23, 7)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (7, 10, N'Łódź', N'Krawiecka', 54, 12)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (8, 12, N'Warszawa', N'Siedlecka', 36, 12)
INSERT dbo.lost_person_address_city (id, lost_person_id, city, street, apartment_number, flat_number) VALUES (9, 17, N'Olsztyn', N'Młodzianowska', 44, 12)
SET IDENTITY_INSERT dbo.lost_person_address_city OFF
GO
SET IDENTITY_INSERT dbo.lost_person_address_village ON 

INSERT dbo.lost_person_address_village (id, lost_person_id, village, apartment_number) VALUES (1, 1, N'Grabowo', 10)
INSERT dbo.lost_person_address_village (id, lost_person_id, village, apartment_number) VALUES (2, 4, N'Moczydło', 12)
INSERT dbo.lost_person_address_village (id, lost_person_id, village, apartment_number) VALUES (3, 5, N'Krosno', 15)
INSERT dbo.lost_person_address_village (id, lost_person_id, village, apartment_number) VALUES (4, 11, N'Łazy', 13)
INSERT dbo.lost_person_address_village (id, lost_person_id, village, apartment_number) VALUES (8, 16, N'Stara Wieś', 34)
SET IDENTITY_INSERT dbo.lost_person_address_village OFF
GO
SET IDENTITY_INSERT dbo.lost_person_image ON 

INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (1, 1, N'rys_na_5.png')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (2, 2, N'portrait-1.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (3, 3, N'images.png')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (4, 5, N'360_F_222851624_jfoMGbJxwRi5AWGdPgXKSABMnzCQo9RN.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (7, 10, N'image.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (8, 11, N'image2.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (9, 12, N'profil.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (13, 16, N'julia.jpg')
INSERT dbo.lost_person_image (id, lost_person_id, image_name) VALUES (14, 17, N'images.jpg')
SET IDENTITY_INSERT dbo.lost_person_image OFF
GO
