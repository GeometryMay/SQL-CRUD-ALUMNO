CREATE TABLE tbalumnos(

nombres NVARCHAR(100) NOT NULL,
calificacion INT NOT NULL
)
GO

INSERT INTO tbalumnos(nombres, calificacion)VALUES(,'Karlita',95)
GO
select * from tbalumnos