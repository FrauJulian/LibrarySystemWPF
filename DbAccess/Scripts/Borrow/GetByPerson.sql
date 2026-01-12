SELECT br.Id,
       br.BorrowDate,
       br.ReturnDate,
       br.LatestReturnDate,

       pe.Id         AS PersonId,
       pe.IdNumber   AS PersonIdNumber,
       pe.Firstname  AS PersonFirstname,
       pe.Lastname   AS PersonLastname,
       pe.Lastname   as PersonAddress,
       pe.Lastname   as PersonPhone,

       b.Id          AS BookId,
       b.InternId    AS BookInternId,
       b.ISBN        AS BookISBN,
       b.Title       AS BookTitle,
       b.Subject     AS BookSubject,
       b.PublishDate AS BookPublishDate,

       p.Id          AS BookPublisherId,
       p.Name        AS BookPublisherName,
       p.Location    AS BookPublisherLocation,

       a.Id          AS BookAuthorId,
       a.Firstname   AS BookAuthorFirstname,
       a.Lastname    AS BookAuthorLastname

FROM Borrow br
         LEFT JOIN Person pe ON pe.Id = br.PersonId
         LEFT JOIN Book b ON b.Id = br.BookId
         LEFT JOIN Publisher p ON p.Id = b.PublisherId
         LEFT JOIN Author a ON a.Id = b.AuthorId
WHERE br.PersonId = @PersonId;
