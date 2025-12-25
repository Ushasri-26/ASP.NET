create database productdb
CREATE TABLE tblProducts
(
    Id INT IDENTITY PRIMARY KEY,
    PName NVARCHAR(50),
    ImagePath NVARCHAR(100),
    Price INT
);
INSERT INTO tblProducts (PName,ImagePath, Price)
VALUES
('Desktop', '~/Images/Desktop.jpg', 50000),
('Laptop','~/Images/Laptop.jpg', 45000),
('Phone', '~/Images/Phone.jpg', 70000),
('TV','~/Images/TV.jpg', 40000),
('Watch','~/Images/Watch.jpg', 55000);

CREATE PROC spGetProductByName
@Productname NVARCHAR(50)
AS
BEGIN
    IF(@Productname = 'All')
    BEGIN
        SELECT Id, PName, ImagePath, Price
        FROM tblProducts;
    END
    ELSE
    BEGIN
        SELECT Id, PName,ImagePath, Price
        FROM tblProducts
        WHERE PName = @Productname;
    END
END
select * from tblProducts