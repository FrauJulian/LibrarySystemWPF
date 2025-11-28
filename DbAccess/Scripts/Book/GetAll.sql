SELECT b.Id,
       b.InternId,
       b.ISBN,
       b.Title,
       b.Subject,
       b.PublishDate,

       p.Id        as PublisherId,
       p.Name      as PublisherName,
       p.Location  as PublisherLocation,

       a.Id        as AuthorId,
       a.Firstname as AuthorFirstname,
       a.Lastname  as AuthorLastname

FROM Book b
         LEFT JOIN Publisher p ON p.Id = b.PublisherId
         LEFT JOIN Author a ON a.Id = b.AuthorId;
