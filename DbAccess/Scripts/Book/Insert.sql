DECLARE
@PublisherId int;
DECLARE
@AuthorId int;
DECLARE
@BookId int;

SELECT @PublisherId = Id
FROM Publisher
WHERE Name = @PublisherName
  AND Location = @PublisherLocation;

IF
@PublisherId IS NULL
BEGIN
INSERT INTO Publisher (Name, Location)
VALUES (@PublisherName, @PublisherLocation);

SET
@PublisherId = SCOPE_IDENTITY();
END;

SELECT @AuthorId = Id
FROM Author
WHERE Firstname = @AuthorFirstname
  AND Lastname = @AuthorLastname;

IF
@AuthorId IS NULL
BEGIN
INSERT INTO Author (Firstname, Lastname)
VALUES (@AuthorFirstname, @AuthorLastname);

SET
@AuthorId = SCOPE_IDENTITY();
END;

INSERT INTO Book
    (InternId, ISBN, Title, Subject, PublisherId, AuthorId, PublishDate)
VALUES (@InternId, @ISBN, @Title, @Subject, @PublisherId, @AuthorId, @PublishDate);

SET
@BookId = SCOPE_IDENTITY();