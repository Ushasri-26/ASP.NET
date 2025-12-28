create table ElectricityBill (
consumer_num varchar(20),
consumer_name varchar(50),
units_consumed int,
bill_amount float,
bill_date DATETIME DEFAULT GETDATE());
select * from ElectricityBill;
