SELECT con.name       AS ConstraintName,
       con.definition AS Definition
FROM sys.check_constraints con
         JOIN sys.tables t
              ON con.parent_object_id = t.object_id
         JOIN sys.columns c
              ON c.object_id = t.object_id
                  AND c.column_id = con.parent_column_id
WHERE t.name = 'Book'
  AND c.name = 'Subject';