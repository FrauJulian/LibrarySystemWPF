-- =========================
-- PERSONEN (10 Stück)
-- =========================
INSERT INTO Person (IdNumber, Firstname, Lastname, Address, Phone) VALUES
                                                                       ('P-1001','Anna','Müller','Wien, Mariahilfer Straße 10','+43660111111'),
                                                                       ('P-1002','Lukas','Gruber','Graz, Herrengasse 5','+43660111112'),
                                                                       ('P-1003','Sophie','Huber','Linz, Hauptplatz 2','+43660111113'),
                                                                       ('P-1004','David','Klein','Salzburg, Getreidegasse 8','+43660111114'),
                                                                       ('P-1005','Laura','Wagner','Innsbruck, Museumstraße 3','+43660111115'),
                                                                       ('P-1006','Jonas','Bauer','Klagenfurt, Neuer Platz 1','+43660111116'),
                                                                       ('P-1007','Marie','Fischer','St. Pölten, Rathausplatz 7','+43660111117'),
                                                                       ('P-1008','Tobias','Mayer','Wels, Ringstraße 9','+43660111118'),
                                                                       ('P-1009','Lea','Schmid','Villach, Postgasse 4','+43660111119'),
                                                                       ('P-1010','Paul','Hofer','Bregenz, Seestraße 12','+43660111120');

-- =========================
-- AUTOREN (10 Stück)
-- =========================
INSERT INTO Author (Firstname, Lastname) VALUES
                                             ('Franz','Kafka'),
                                             ('J.K.','Rowling'),
                                             ('George','Orwell'),
                                             ('Agatha','Christie'),
                                             ('Stephen','King'),
                                             ('Yuval','Harari'),
                                             ('Hermann','Hesse'),
                                             ('Frank','Herbert'),
                                             ('J.R.R.','Tolkien'),
                                             ('Jane','Austen');

-- =========================
-- VERLAGE (5 Stück)
-- =========================
INSERT INTO Publisher (Name, Location) VALUES
                                           ('Penguin Random House','Berlin'),
                                           ('Suhrkamp Verlag','Frankfurt'),
                                           ('Heyne Verlag','München'),
                                           ('Rowohlt Verlag','Hamburg'),
                                           ('dtv','München');

-- =========================
-- BÜCHER (20 Stück)
-- =========================
INSERT INTO Book (InternId, ISBN, Title, Subject, PublisherId, AuthorId, PublishDate) VALUES
                                                                                          ('B-001',100000001,'Der Prozess','Klassiker',2,1,'1925-01-01'),
                                                                                          ('B-002',100000002,'Harry Potter und der Stein der Weisen','Fantasy',1,2,'1997-06-26'),
                                                                                          ('B-003',100000003,'1984','ScienceFiction',1,3,'1949-06-08'),
                                                                                          ('B-004',100000004,'Mord im Orientexpress','Krimi',4,4,'1934-01-01'),
                                                                                          ('B-005',100000005,'Es','Horror',3,5,'1986-09-15'),
                                                                                          ('B-006',100000006,'Eine kurze Geschichte der Menschheit','Geschichte',2,6,'2011-01-01'),
                                                                                          ('B-007',100000007,'Der Steppenwolf','Roman',2,7,'1927-01-01'),
                                                                                          ('B-008',100000008,'Dune','ScienceFiction',3,8,'1965-08-01'),
                                                                                          ('B-009',100000009,'Der Herr der Ringe','Fantasy',1,9,'1954-07-29'),
                                                                                          ('B-010',100000010,'Stolz und Vorurteil','Roman',4,10,'1813-01-28'),
                                                                                          ('B-011',100000011,'Animal Farm','Politik',1,3,'1945-08-17'),
                                                                                          ('B-012',100000012,'Der Hobbit','Fantasy',1,9,'1937-09-21'),
                                                                                          ('B-013',100000013,'Tod auf dem Nil','Krimi',4,4,'1937-11-01'),
                                                                                          ('B-014',100000014,'Der Outsider','Horror',3,5,'2018-05-22'),
                                                                                          ('B-015',100000015,'Homo Deus','Philosophie',2,6,'2015-09-08'),
                                                                                          ('B-016',100000016,'Siddhartha','Philosophie',2,7,'1922-01-01'),
                                                                                          ('B-017',100000017,'Kinder des Dschinn','Fantasy',3,8,'2005-01-01'),
                                                                                          ('B-018',100000018,'Emma','Roman',4,10,'1815-12-23'),
                                                                                          ('B-019',100000019,'Carrie','Horror',3,5,'1974-04-05'),
                                                                                          ('B-020',100000020,'Der Prozess (Neuauflage)','Klassiker',2,1,'2020-01-01');

-- =========================
-- AUSLEIHEN (20 Stück)
-- =========================
INSERT INTO Borrow (PersonId, BookId, BorrowDate, ReturnDate, LatestReturnDate) VALUES
                                                                                    (1,1,'2024-01-10','2024-01-20','2024-01-25'),
                                                                                    (2,2,'2024-01-11',NULL,'2024-02-01'),
                                                                                    (3,3,'2024-01-12','2024-01-25','2024-01-30'),
                                                                                    (4,4,'2024-01-13',NULL,'2024-02-05'),
                                                                                    (5,5,'2024-01-14','2024-01-28','2024-02-01'),
                                                                                    (6,6,'2024-01-15',NULL,'2024-02-10'),
                                                                                    (7,7,'2024-01-16','2024-01-29','2024-02-02'),
                                                                                    (8,8,'2024-01-17',NULL,'2024-02-03'),
                                                                                    (9,9,'2024-01-18','2024-01-30','2024-02-04'),
                                                                                    (10,10,'2024-01-19',NULL,'2024-02-05'),
                                                                                    (1,11,'2024-02-01',NULL,'2024-02-15'),
                                                                                    (2,12,'2024-02-02',NULL,'2024-02-16'),
                                                                                    (3,13,'2024-02-03',NULL,'2024-02-17'),
                                                                                    (4,14,'2024-02-04',NULL,'2024-02-18'),
                                                                                    (5,15,'2024-02-05',NULL,'2024-02-19'),
                                                                                    (6,16,'2024-02-06',NULL,'2024-02-20'),
                                                                                    (7,17,'2024-02-07',NULL,'2024-02-21'),
                                                                                    (8,18,'2024-02-08',NULL,'2024-02-22'),
                                                                                    (9,19,'2024-02-09',NULL,'2024-02-23'),
                                                                                    (10,20,'2024-02-10',NULL,'2024-02-24');
