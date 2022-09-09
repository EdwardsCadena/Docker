Create database Docker
use Docker

create table City(
CodeCity int primary key identity,
Description Varchar(50)
)
create table Seller(
CodeSeller int primary key identity,
NameSeller Varchar(50),
LastNameSeller Varchar(50),
DocumentSeller char (12),
CodeCitySeller int,
CONSTRAINT Fkcliente FOREIGN KEY(CodeCitySeller) REFERENCES City(CodeCity)
)
