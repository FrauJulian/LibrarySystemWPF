SELECT br.Id,
       br.BorrowDate,
       br.ReturnDate,
       br.LatestReturnDate,

       pe.Id         as PersonId,
       pe.IdNumber   as PersonIdNumber,
       pe.Firstname  as PersonFirstname,
       pe.Lastname   as PersonLastname,
       pe.Lastname   as PersonAddress,
       pe.Lastname   as PersonPhone,

       b.Id          as BookId,
       b.InternId    as BookInternId,
       b.ISBN        as BookISBN,
       b.Title       as BookTitle,
       b.Subject     as BookSubject,
       b.PublishDate as BookPublishDate,

       p.Id          as BookPublisherId,
       p.Name        as BookPublisherName,
       p.Location    as BookPublisherLocation,

       a.Id          as BookAuthorId,
       a.Firstname   as BookAuthorFirstname,
       a.Lastname    as BookAuthorLastname

FROM Borrow br
         LEFT JOIN Person pe ON pe.Id = br.PersonId
         LEFT JOIN Book b ON b.Id = br.BookId
         LEFT JOIN Publisher p ON p.Id = b.PublisherId
         LEFT JOIN Author a ON a.Id = b.AuthorId;
