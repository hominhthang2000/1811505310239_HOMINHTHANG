create database HoMinhThangDB
CREATE TABLE UserAccount(
  ID CHAR(15) NOT NULL PRIMARY KEY ,
  UserName char(30) not NULL,
  Password char(200) not NULL,
  Status int NULL  DEFAULT(0)
) 
CREATE TABLE  loai_sp (
  ID CHAR(15) NOT NULL PRIMARY KEY,
  Name nvarchar(128)  NOT NULL,
  Description nvarchar(256) NULL 
)
CREATE TABLE san_pham (
  ID CHAR(15) NOT NULL PRIMARY KEY,
  ID_l char(15) NOT NULL foreign key references loai_sp(ID),
  Name nvarchar(100)  NOT NULL,
  UnitCost int NOT NULL,
  Quantity int NOT NULL,
  Description nvarchar(256) NULL ,
  Image nvarchar(100)  NOT NULL,
  Status int  NULL DEFAULT(0),
) 
INSERT INTO UserAccount(ID, UserName, Password,Status)
VALUES ('UA01', 'thang1', 'e154248e91ef8eae65159fa4083747e5',1),
('UA02', 'thang2', 'thang2',0),
('UA03', 'thang3', '94328c80e7137bba5973f7c3e92829a8',0),
('UA04', 'thang4', 'thang4',0),
('UA05', 'thang5', 'thang5',0),
('UA06', 'thang6', 'thang6',0);
INSERT INTO loai_sp(ID, Name)
VALUES ('IP', 'Iphone'),
('SS','SamSung'),
('No','Nokia'),
('XM','Xiaomi'),
('HW','Huawei');
INSERT INTO san_pham(ID, ID_l,Name,UnitCost,Quantity,Image)
VALUES
(N'IP4', N'IP', N'Iphone XR 64GB', 11000000, 11, 'images/ipxr.jpg'),
(N'IP5', N'IP', N'Iphone 12 Mini 128GB', 19000000, 21, 'Images/ip12mini.jpg'),
(N'IP6', N'IP', N'Iphone SE 64GB', 12000000, 15, 'images/ipse.jpg'),
(N'SS1', N'SS', N'Samsung Galaxy S21 5G ', 19000000, 20, 'images/sss21.jpg'),
(N'SS2', N'SS', N'Samsung Galaxy M51',8000000, 42, 'images/ssm51.jpg'),
(N'SS3', N'SS', N'Samsung Galaxy Note 20 Ultra 5G Trắng', 4250000, 60, 'images/ssn20.jpg'),
(N'No1', N'No', N'Nokia 5.4', 2000000, 33, N'images/n5.4.jpg'),
(N'No2', N'No', N'Nokia 2.4', 5000000, 43, N'images/n2.4.jpg'),
(N'No3', N'No', N'Nokia 3.4', 6000000, 33, N'Images/n3.4.jpg'),
(N'No4', N'No', N'Nokia 210', 450000, 54, N'images/n210.jpg'),
(N'XM1', N'XM', N'Xiaomi Redmi Note 10', 5000000, 41, N'images/xrn10.jpg'),
(N'XM2', N'XM', N'Xiaomi Mi 11 5G', 20000000, 54, N'images/xm11.jpg'),
(N'XM3', N'XM', N'Xiaomi Mi 10T Pro 5G', 15000, 22, N'images/xm10.jpg'),
(N'XM4', N'XM', N'Xiaomi POCO X3 NFC', 120000, 24, N'Images/xx3.jpg'),
 (N'XM5', N'XM', N'Xiaomi Redmi Note 9 Pro', 1160000, 14, N'images/xen9.jpg'),
 (N'XM6', N'XM', N'Xiaomi Redmi Note 8', 12000, 24, N'images/xrn8.jpg'),
 (N'No5', N'No', N'Nokia 6300 4G', 1350000, 33, N'Images/n6300.jpg'),
 (N'No6', N'No', N'Nokia C2', 1305000, 31, N'Images/nc2.jpg'),
 (N'HW1', N'HW', N'Huawei Y6p', 5600000, 25, N'images/hy6.jpg'),
 (N'HW2', N'HW', N'HUAWEI MATE 30 PRO', 1310000, 35, N'images/h30.jpg')
