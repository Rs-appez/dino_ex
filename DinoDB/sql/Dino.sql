create table Dino (
    id int IDENTITY(1,1) PRIMARY KEY,
    espece nvarchar(255),
    length_meters Decimal(10,5) not null,
    weight_kg decimal(15,5) not null
);


