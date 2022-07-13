use [master]

drop database if exists [Restaurant]
create database [Restaurant]
go
use [Restaurant]
go
create table [dbo].[feature](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[title] [nvarchar](255) NOT NULL,
	[icon] [nvarchar](255) NULL,
	status bit default 1
)
create table [dbo].[action](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[title] [nvarchar](255) NOT NULL,
	[featureId] int not null,
	status bit default 1,
	FOREIGN KEY ([featureId]) REFERENCES [feature]([Id])
)
CREATE TABLE [dbo].[permission](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] [nvarchar](200) NULL,
	status bit default 1
)
CREATE TABLE [dbo].[permission_action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[permissionId] [int] NULL,
	[actionId] [int] NULL,
	status [bit] default 1 NOT NULL,
	FOREIGN KEY ([permissionId]) REFERENCES [permission]([Id]),
	FOREIGN KEY ([actionId]) REFERENCES [action]([Id])
)
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](1000) NULL,
	[full_name] [nvarchar](255) NULL,
	[birthday] [date] NULL,
	[phone] [nvarchar](20) NULL,
	[gender] [bit]  default 1,
	[is_admin] [bit] default 0,
	[is_active] [bit] default 1,
	[address] [text] default null,
	[created_at] [datetime] default getDate(),
	[updated_at] [datetime] NULL,
	[avatar] [nvarchar](255) NULL
)
CREATE TABLE [dbo].[restaurant](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] [nvarchar](255) not NULL,
	[description] nvarchar(max) null,
	[ownerId] int NOT NULL,
	[phone] [nvarchar](20) NULL,
	[address] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NULL,
	[is_active] [bit] default 1,
	[created_at] [datetime] default getDate(),
	[updated_at] [datetime] NULL,
	[logo] [nvarchar](255) NULL,
	[bank] [nvarchar](255) NULL,
	[accountNumber] [nvarchar](255) NULL,
	FOREIGN KEY ([ownerId]) REFERENCES [user]([Id])
)
CREATE TABLE [dbo].[restaurant_user](
	[restaurantId] int NOT NULL,
	[userId] int NOT NULL,
	[permissionId] int NOT NULL,
	[status] bit default 1,
	FOREIGN KEY ([restaurantId]) REFERENCES [restaurant]([Id]),
	FOREIGN KEY ([userId]) REFERENCES [user]([Id]),
	FOREIGN KEY ([permissionId]) REFERENCES [permission]([Id])
)
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] [nvarchar](255) not NULL,
	[description] nvarchar(max) null,
	[image] nvarchar(255) null,
	[restaurantId] int NOT NULL,
	[status] bit default 1,
	FOREIGN KEY ([restaurantId]) REFERENCES [restaurant]([Id])
)
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] [nvarchar](255) not NULL,
	[description] nvarchar(max) null,
	[price] float not null,
	[categoryId] int NOT NULL,
	[created_at] [datetime] default getDate(),
	[updated_at] [datetime] null,
	[status] bit default 1,
	FOREIGN KEY ([categoryId]) REFERENCES [category]([Id])
)
CREATE TABLE [dbo].[product_image](
	[productId] int NOT NULL,
	[image] nvarchar(255) not null,
	FOREIGN KEY ([productId]) REFERENCES [product]([Id])
)
CREATE TABLE [dbo].[shipper](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[userId] int NOT NULL,
	[status] bit default 1,
	FOREIGN KEY ([userId]) REFERENCES [user]([Id])
)
CREATE TABLE [dbo].[bill_status](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] [nvarchar](200) NULL,
	status bit default 1
)
CREATE TABLE [dbo].[bill](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[servered_by] int null,
	[is_takeAway] bit default 0,
	[is_transfer] bit default 0,
	status int not null,
	[createdAt] datetime default getDate(),
	FOREIGN KEY ([servered_by]) REFERENCES [user]([Id]),
	FOREIGN KEY ([status]) REFERENCES [bill_status]([Id])
)
CREATE TABLE [dbo].[bill_takeAway](
	[billId] int NOT NULL,
	[customerId] int null,
	[fullName] nvarchar(255) not null,
	[address] nvarchar(255) not null,
	[phone] nvarchar(20) not null,
	[shipperId] int null,
	FOREIGN KEY ([shipperId]) REFERENCES [shipper]([Id]),
	FOREIGN KEY ([customerId]) REFERENCES [user]([Id]),
	FOREIGN KEY ([billId]) REFERENCES [bill]([Id])
)
CREATE TABLE [dbo].[bill_detail](
	[billId] int NOT NULL,
	[productId] int not null,
	[quantity] int not null,
	[price] float not null,
	FOREIGN KEY ([productId]) REFERENCES [product]([Id]),
	FOREIGN KEY ([billId]) REFERENCES [bill]([Id])
)
CREATE TABLE [dbo].[feedback](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[billId] int not null,
	[rate] int default 5,
	[comment] bit default 0,
	[anonymous] bit default 0,
	FOREIGN KEY ([billId]) REFERENCES [bill]([Id])
)
CREATE TABLE [dbo].[feedback_shipper](
	[feedbackId] int NOT NULL,
	[rate] int default 5,
	[comment] bit default 0,
	FOREIGN KEY ([feedbackId]) REFERENCES [feedback]([Id])
)
CREATE TABLE [dbo].[feedback_detail](
	[feedbackId] int NOT NULL,
	[productId] int not null,
	[rate] int default 5,
	[comment] bit default 0,
	FOREIGN KEY ([productId]) REFERENCES [product]([Id]),
	FOREIGN KEY ([feedbackId]) REFERENCES [feedback]([Id])
)
INSERT INTO [dbo].[permission]([name],[status])
     VALUES
           (N'Admin',1),
           (N'Owner',1),
           (N'Waiter',1),
           (N'Customer',1),
           (N'Shipper',1)
GO
INSERT INTO [dbo].[feature]
           ([title],[icon])
     VALUES
           (N'Dashboard',N'home'),
           (N'Action',N'sliders'),
           (N'User',N'users'),
           (N'Shippers',N'truck'),
           (N'Permission',N'settings'),
           (N'Restaurant',N'shopping-bag'),
           (N'Category',N'box'),
           (N'Product',N'coffee'),
           (N'Bill',N'credit-card'),
           (N'Bill Status',N'check-square'),
           (N'Feedback',N'message-square'),
           (N'Feature',N'feather')
GO
INSERT INTO [dbo].[action] ([title],[status],[featureId])
     VALUES
           (N'Xem danh sách nhà hàng',1,6),
           (N'Đăng ký hoạt động nhà hàng',1,6),
           (N'Xem thông tin nhà hàng',1,6),
           (N'Sửa thông tin nhà hàng',1,6),
           (N'Dừng hoạt động nhà hàng',1,6),
           (N'Xem danh sách nhóm sản phẩm',1,7),
           (N'Thêm thông tin nhóm sản phẩm',1,7),
           (N'Xem thông tin nhóm sản phẩm',1,7),
           (N'Sửa thông tin nhóm sản phẩm',1,7),
           (N'Dừng hoạt động nhóm sản phẩm',1,7),
           (N'Xem danh sách sản phẩm',1,8),
           (N'Thêm thông tin sản phẩm',1,8),
           (N'Xem thông tin sản phẩm',1,8),
           (N'Sửa thông tin sản phẩm',1,8),
           (N'Dừng hoạt động sản phẩm',1,8),
           (N'Xem danh sách chức năng',1,5),
           (N'Thêm thông tin chức năng',1,5),
           (N'Xem thông tin chức năng',1,5),
           (N'Sửa thông tin chức năng',1,5),
           (N'Dừng hoạt động chức năng',1,5),
           (N'Xem danh sách nhân viên nhà hàng',1,3),
           (N'Thêm thông tin nhân viên nhà hàng',1,3),
           (N'Xem thông tin nhân viên nhà hàng',1,3),
           (N'Dừng hoạt động nhân viên nhà hàng',1,3),
           (N'Xem danh sách hoạt động',1,2),
           (N'Thêm thông tin hoạt động',1,2),
           (N'Xem thông tin hoạt động',1,2),
           (N'Sửa thông tin hoạt động',1,2),
           (N'Dừng hoạt động hoạt động',1,2),
           (N'Xem danh sách các hoạt động chức năng dùng',1,12),
           (N'Thêm thông tin các hoạt động chức năng dùng',1,12),
           (N'Xem thông tin các hoạt động chức năng dùng',1,12),
           (N'Sửa thông tin các hoạt động chức năng dùng',1,12),
           (N'Dừng hoạt động các hoạt động chức năng dùng',1,12),
           (N'Xem danh sách người dùng',1,3),
           (N'Thêm thông tin người dùng',1,3),
           (N'Xem thông tin người dùng',1,3),
           (N'Sửa thông tin người dùng',1,3),
           (N'Dừng hoạt động người dùng',1,3),
           (N'Xem danh sách hóa đơn',1,9),
           (N'Thêm thông tin hóa đơn',1,9),
           (N'Xem thông tin hóa đơn',1,9),
           (N'Sửa thông tin hóa đơn',1,9),
           (N'Dừng hoạt động hóa đơn',1,9),
           (N'Xem danh sách shipper',1,4),
           (N'Đăng ký hoạt động shipper',1,4),
           (N'Xem thông tin shipper',1,4),
           (N'Dừng hoạt động shipper',1,4)
GO
INSERT INTO [dbo].[permission_action]
           ([permissionId],[actionId])
     VALUES
           (1,1),(2,1),(3,1),(4,1),(2,2),(3,2),(4,2),(1,3),(2,3),(3,3),(4,3),(1,4),(2,4),(3,4),(1,5),(2,5),
           (1,6),(2,6),(3,6),(4,6),(2,7),(3,7),(1,8),(2,8),(4,8),(2,9),(3,9),(2,10),(1,11),(2,11),(3,11),(4,11),
           (2,12),(3,12),(1,13),(2,13),(3,13),(4,13),(2,14),(3,14),(2,15),(3,15),(1,16),(1,17),(1,18),(1,19),
           (1,20),(1,22),(2,22),(3,22),(2,22),(2,23),(3,23),(2,24),(1,25),(1,26),(1,27),(1,28),(1,29),(1,30),
           (1,31),(1,32),(1,33),(1,34),(1,35),(1,36),(1,37),(1,38),(1,39),(1,40),(2,40),(3,40),(4,40),(2,41),
           (3,41),(4,41),(1,42),(2,42),(3,42),(4,42),(2,43),(3,43),(4,43),(2,44),(3,44),(4,44),(1,45),(2,45),
		   (3,45),(2,46),(3,46),(4,46),(1,47),(1,48)                
GO
INSERT INTO [dbo].[user]([email],[password],[full_name],[is_admin])
     VALUES
           ('admin@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Admin',1)
INSERT INTO [dbo].[user]([email],[password],[full_name])
     VALUES
           ('owner1@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 1'),
           ('owner2@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 2'),
           ('owner3@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 3'),
           ('owner4@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 4'),
           ('owner5@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 5'),
           ('owner6@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 6'),
           ('owner7@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','Owner 7'),
           ('customer1@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 1'),
           ('customer2@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 2'),
           ('customer3@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 3'),
           ('customer4@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 4'),
           ('customer5@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 5'),
           ('customer6@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 6'),
           ('customer7@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','customer 7'),
           ('shipper1@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 1'),
           ('shipper2@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 2'),
           ('shipper3@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 3'),
           ('shipper4@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 4'),
           ('shipper5@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 5'),
           ('shipper6@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 6'),
           ('shipper7@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','shipper 7'),
           ('waiter1@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 1'),
           ('waiter2@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 2'),
           ('waiter3@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 3'),
           ('waiter4@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 4'),
           ('waiter5@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 5'),
           ('waiter6@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 6'),
           ('waiter7@gmail.com','$2a$11$cuQ2l7tazFEyL5jvBnssPuU5gE51fEMCV0225Tj1jzk2RX1xecQfe','waiter 7')
GO
INSERT INTO [dbo].[restaurant]
           ([name],[ownerId],[address],[is_active])
     VALUES
           (N'Tiệm vịt 88',2,'Thạch Hòa, Thạch Thất',1),
           (N'Gà ri Phú Bình 1',3,'Thạch Hòa, Thạch Thất',1),
           (N'Tocotoco',4,'Tân Xã, Thạch Thất',1),
           (N'Mixue',5,'Tân, Thạch Thất',1),
           (N'Cơm Quỳnh Linh',6,'Thạch Hòa, Thạch Thất',0),
           (N'Hola Coffee',7,'Thạch Hòa, Thạch Thất',0),
           (N'Cơm rang Việt Nguyễn',8,'Thạch Hòa, Thạch Thất',0),
           (N'Nem nướng Nha Trang',2,'Thạch Hòa, Thạch Thất',1),
           (N'Tako Chan',2,'Thạch Hòa, Thạch Thất',1),
           (N'Gà ri Phú Bình 2',3,'Xuân Mai, Thạch Thất',1)
GO
update restaurant set logo = 'logo.png';
INSERT INTO [dbo].[shipper]
           ([userId])
     VALUES (16),(17),(18),(19),(20),(22),(22)
GO

INSERT INTO [dbo].[category]
           ([name],[restaurantId])
     VALUES
           (N'Món nổi bật',3),
           (N'Trà Sữa - Milk Tea',3),
           (N'Trà Trái Cây - Fresh Fruit Tea',3),
           (N'Macchiato Cream Cheese',3),
           (N'Sữa Chua Dẻo',3),
           (N'Icecream & Tea',4),
           (N'Trà hoa quả',4),
           (N'Trà sữa',4),
           (N'Theo Set',1),
           (N'Theo Món',1),
           (N'Vịt Om',1),
           (N'Khai Vị',1),
           (N'Nước Ngọt',1),
           (N'Bia',1),
           (N'Rượu',1),
           (N'Theo Set',8),
           (N'Thứ 2 Vui Vẻ',8),
           (N'Món Chính',8),
           (N'Món Phụ',8),
           (N'Đồ Uống',8),
           (N'Bánh Mì Que Hải Phòng',8),
           (N'Theo Combo',8),
           (N'Takoyaki',9),
           (N'Omurice',9),
           (N'Omusoba',9),
           (N'Đồ Ăn Vặt Kiểu Nhật',9),
           (N'Đồ Uống',9)
GO


INSERT INTO [dbo].[product]
           ([name],[description],[price],[categoryId])
     VALUES
(N'Ô Long Xoài Kem Cà Phê','',49000,1),
(N'Trà Đào Bưởi Hồng Trân Châu Baby','',38000,1),
(N'Instant Milk Tea - Strawberry - Set 6 Ly','',155000,1),
(N'Instant Milk Tea - Original - Set 6 ly','',144000,1),
(N'Instant Milk Tea - Strawberry','',25000,1),
(N'Instant Milk Tea - Original','',23000,1),
(N'Trà Xoài Bưởi Hồng','',29000,1),
(N'Trà Xoài Bưởi Hồng Kem Phô Mai','',29000,1),
(N'Choco Ngũ Cốc Kem Cafe','',29000,1),
(N'Hồng Trà Ngũ Cốc Kem Cafe','',29000,1),
(N'Royal Pearl Milk Coffee','',29000,1),
(N'Grass Jelly Milk Coffee','',29000,1),
(N'Tiger Sugar','',29000,1),
(N'Trà Sữa Trân Châu Hoàng Gia','',29000,1),
(N'Trà Sữa Ba Anh Em','',29000,1),
(N'Trà Sữa Panda','',29000,1),
(N'Trà Sữa Kim Cương Đen Okinawa','',29000,1),
(N'Ô Long Kem Phô Mai','',29000,1),
(N'Trà dứa nhiệt đới','',29000,1),
(N'Trà Sữa Hạnh Phúc','',29000,1),
(N'Matcha Đậu Đỏ','',29000,2),
(N'Trà Xanh','',29000,2),
(N'Sữa Tươi Trân Châu Baby Kem Café','',29000,2),
(N'Oolong Trân châu Baby Kem Café','',29000,2),
(N'Trà Xanh Sữa Vị Nhài','',29000,2),
(N'Trà Sữa Matcha','',29000,2),
(N'Trà Sữa Ô Long','',29000,2),
(N'Ô Long Thái Cực','',29000,2),
(N'Hồng Trà','',29000,2),
(N'Matcha Đậu Đỏ','',29000,2),
(N'Trà Sữa Socola','',29000,2),
(N'Trà Sữa Bạc Hà','',29000,2),
(N'Trà sữa dâu tây','',29000,2),
(N'Trà sữa','',29000,2),
(N'Ô Long Xoài Kem Cà Phê','',49000,3),
(N'Trà Đào Bưởi Hồng Trân Châu Baby','',38000,3),
(N'Trà Xoài Bưởi Hồng','',29000,3),
(N'Probi Bưởi Trân Châu Sương Mai','',29000,3),
(N'Trà Xanh Xoài','',29000,3),
(N'Trà dâu tằm pha lê tuyết','',29000,3),
(N'Hồng Trà Bưởi Mật Ong','',29000,3),
(N'Trà Xoài Bưởi Hồng Kem Phô Mai','',29000,4),
(N'Choco Ngũ Cốc Kem Cafe','',29000,4),
(N'Hồng Trà Ngũ Cốc Kem Cafe','',29000,4),
(N'Dâu Tằm Kem Phô Mai','',29000,4),
(N'Hồng Trà Kem Phô Mai','',29000,4),
(N'Trà Xanh Kem Phô Mai','',29000,4),
(N'Matcha Kem Phô Mai','',29000,4),
(N'Sữa Chua Dâu Tằm Hoàng Kim','',29000,5),
(N'Sữa Chua Dâu Tằm Hạt Dẻ','',29000,5),
(N'Sữa Chua Trắng','',29000,5),
(N'Super Sundae Trân Châu Đường Đen',N'Gồm kem và trân châu đường đen',25000,6),
(N'SUPER SUNDAE XOÀI',N'Kem + Mứt xoài ',25000,6),
(N'SUPER SUNDAE DÂU TÂY ',N'Kem + Mứt dâu tây ',25000,6),
(N'SỮA KEM LẮC ĐÀO',N'Kem + Thạch đào + Đào Mật',25000,6),
(N'Sữa Kem Lắc Dâu Tây',N'Gồm kem, trà olong và mứt dâu tây. Các bạn lắc kỹ trước khi uống nhé.',25000,6),
(N'Hồng Trà Kem',N'Gồm hồng trà và kem',25000,6),
(N'TRÀ KEM BỐN MÙA',N'Trà ô long + Kem',25000,6),
(N'Super Sundae Lô Hội',N'',25000,6),
(N'Nước Chanh Tươi Lạnh',N'',20000,7),
(N'Trà Chanh Lô Hội',N' hồng trà + thạch dừa + lô hội',20000,7),
(N'TRÀ ĐÀO BỐN MÙA',N'Thạch Đào + Trà Ô Long + Đào Mật',25000,7),
(N'Dương Chi Cam Lộ',N'Sản phẩm đồ uống gồm các topping Xoài + Trân châu + Thạch dừa + Thạch Đào + Kem',35000,7),
(N'Hồng Trà Chanh',N'Gồm hồng trà và chanh tươi',22000,7),
(N'Trà Đào Big Size',N'thạch đào + mứt đào vàng và hồng trà bá tước ',25000,7),
(N'Hồng Trà Mật Ong',N'',20000,7),
(N'TRÀ Ô LONG BỐN MÙA',N'Trà ô long ',20000,7),
(N'Trà Đào Tứ Kỳ Xuân',N'Mứt đào vàng, thạch dừa cùng trà ô long 4 mùa',25000,7),
(N'Hồng Trà Vải ',N'Hồng trà + vải + topping thạch dừa',25000,7),
(N'Trà Sữa 3Q',N'Gồm Thạch đào + Trân Châu +Thạch Dừa',25000,8),
(N'Trà Sữa Trân Châu Đường Đen',N'',25000,8),
(N'Trà sữa bá vương',N'Gồm Thạch đào + Trân Châu +Thạch Dừa',30000,8),
(N'Trà Sữa Thạch Dừa',N'',25000,8),
(N'Trà Sữa 2J',N'Thạch Đào + Thạch Dừa',25000,8),
(N'Trà sữa Nướng',N'',25000,8),
(N'Combo Phở cuốn (Combo) ',N'',98700,10),
(N' Bún trộn vịt quay (Bát) ',N'',35000,10),
(N' Miến trộn vịt quay (Bát) ',N'',35000,10),
(N' Phở cuốn vịt quay (Đĩa) ',N'',35000,10),
(N' Vịt cháy tỏi (xuất) ',N'',99000,10),
(N' Vịt quay (Đĩa) ',N'',99000,10),
(N' Vịt luộc (Đĩa) ',N'',99000,10),
(N' Vịt rang riềng (Đĩa) ',N'',99000,10),
(N' Vịt rang muối (Đĩa) ',N'',89100,10),
(N' Vịt cháy tỏi (Đĩa) ',N'',99000,10),
(N' Vịt chiên cay (Đĩa) ',N'',99000,10),
(N' Lườn vịt hun khói (Đĩa) ',N'',79200,10),
(N' Lưỡi vịt chiên xù (Đĩa) ',N'',53100,10),
(N' Nộm chân vịt (Đĩa) ',N'',47200,10),
(N' Lòng mề xào dứa (Đĩa) ',N'',39200,10),
(N' Miến xào lòng mề (Đĩa) ',N'',35100,10),
(N' Miến xào vịt (Đĩa) ',N'',35100,10),
(N' Cháo vịt (Đĩa) ',N'',25000,10),
(N' Canh măng (Bát) ',N'',18000,10),
(N' Bún (Đĩa) ',N'',9000,10),
(N'99K/Người Ăn Đủ 10 Món (Áp dụng từ 2N trở lên) ',N'',99000,9),
(N'129K/Người Ăn Đủ 11 Món (Áp dụng từ 2N trở lên) ',N'',129000,9),
(N'Vịt om xấu nhỏ (Nồi) ',N'',150000,11),
(N'Vịt om xấu vừa (Nồi) ',N'',250000,11),
(N'Vịt om xấu lớn (Nồi) ',N'',350000,11),
(N'Ngô chiên (Đĩa) ',N'',35000,12),
(N'Khoai chiên (Đĩa) ',N'',35000,12),
(N'Khoai lang kén (Đĩa) ',N'',35000,12),
(N'Lạc cháy tỏt (Gói) ',N'',10000,12),
(N'Dưa chuột (Đĩa) ',N'',15000,12),
(N'Pesi (Lon) ',N'',15000,13),
(N'Cam ép (Lon) ',N'',15000,13),
(N'Sprite (Lon) ',N'',15000,13),
(N'Nước lọc (Chai) ',N'',10000,13),
(N'Bia chai Sài gòn (Chai) ',N'',18000,14),
(N'Bia lon Sài gòn (Lon) ',N'',18000,14),
(N'Bia chai Tiger bạc (Chai) ',N'',19900,14),
(N'Rượu nếp ngọt (Chai) ',N'',45000,15),
(N'Rượu ngâm hoa quả (Chai) ',N'',45000,15),
(N'Rượu Sochu (Chai) ',N'',80000,15),
(N'Mẹt 1 Người',N'Gồm 6,7 miếng nem + 7 giòn + 1 tệp lá bánh đa + 1 nước chấm + rau củ quả + ớt trưng
 ⛔️Trời mùa đông bánh đa dễ giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ bị vỡ ',45000,16),
(N'Mẹt 2 Người ',N'Tổng 2 Mẹt Gồm 12 - 13 miếng nem + 14 giòn giòn + 2 tệp lá bánh đa + phở + rau củ quả + 2 nước chấm + ớt trưng 
⛔Trời mùa đông bánh đa dễ giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ vỡ !',89000,16),
(N'Thịt Nem Nướng Nha Trang',N'5 miếng nhor',2000,16),
(N'Mẹt 4 Người ',N'Tổng 4 Mẹt Gồm 26 - 28 miếng nem + 28 giòn giòn + 4 tệp lá bánh đa + rau củ qua + 4 nước chấm + ớt trưng 
⛔Trời mùa đông bánh đã hay bị giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ bị vỡ !',177000,16),
(N'Mẹt 2 người + 01 Coca-Cola',N'',77000,16),
(N'Mẹt 1 Người + 1 Bánh đa thêm + 01 Pepsi (Hoặc nước khác)',N'Nước có thể chọn: Pepsi/Tea+/Sting/7Up/Mirinda ',58000,16),
(N'Mẹt 2 Người + 01 Pepsi (Hoặc nước khác)',N'Nước có thể chọn: Pepsi/Tea+/Sting/7Up/Mirinda ',116000,16),
(N'Mẹt 1 Người + 01 Pepsi (Hoặc nước khác)',N'Nước có thể chọn: Pepsi/Tea+/Sting/7Up/Mirinda ',58000,16),
(N' Thịt 1 Người',N'6,7 miếng nem',22000,17),
(N'Thịt 2 Người',N'12,13 miếng nem',44000,17),
(N'Mẹt Nhỏ Thử Nghiệm',N'Gồm 4 Miếng Nem + Rau, Củ Quả + 1 Tệp lá bánh đa + nước chấm + 6 ram',34900,17),
(N'Mẹt 1 Người',N'Gồm 6,7 miếng nem + 7 giòn + 1 tệp lá bánh đa + 1 nước chấm + rau củ quả + ớt trưng
 ⛔️Trời mùa đông bánh đa dễ giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ bị vỡ ',45000,18),
(N'Mẹt 2 Người ',N'Tổng 2 Mẹt Gồm 12 - 13 miếng nem + 14 giòn giòn + 2 tệp lá bánh đa + phở + rau củ quả + 2 nước chấm + ớt trưng 
⛔Trời mùa đông bánh đa dễ giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ vỡ !',89000,18),
(N'Thịt Nem Nướng Nha Trang',N'5 miếng nhor',2000,18),
(N'Mẹt 4 Người ',N'Tổng 4 Mẹt Gồm 26 - 28 miếng nem + 28 giòn giòn + 4 tệp lá bánh đa + rau củ qua + 4 nước chấm + ớt trưng 
⛔Trời mùa đông bánh đã hay bị giòn, quý khách vui lòng quấn hẳn 2 lá cho đỡ bị vỡ !',177000,18),
(N'Nem Kem Phô Mai',N'',20000,18),
(N'500ml Nước Cốt Chấm ',N'',35000,18),
(N'Mẹt 2 người + 01 Coca-Cola',N'',77000,18),
(N'1kg Thịt Nem Nướng',N'Quay lò vi sóng hoặc rán trước khi ăn ạ ',249000,18),
(N'0,5kg Thịt Nem Nướng',N'Quay lò vi sóng hoặc rán trước khi ăn aj',129000,18),
(N'3 bánh mì que pate cay',N'',19900,19),
(N'Nước chấm 1 cốc',N'140ml nước chấm ',6500,19),
(N'1 Bánh Mì Que Bơ Sữa HP',N'',6000,19),
(N'Lạp Sườn',N'',12000,19),
(N'Dồi sụn rán',N'',12000,19),
(N'Thêm Ram',N'15 giòn giòn',10000,19),
(N'Bò Viên Xiên Que',N'Một Xiên 4 viên',6500,19),
(N'Bánh đa nem 1 tệp',N'',4500,19),
(N'Thêm Phở',N'',6000,19),
(N'5 Nem Chua Rán ( thường )',N'',39000,19),
(N'Rau Sống',N'',10000,19),
(N'Xúc Xích Rán',N'',12000,19),
(N'10 Nem Chua Rán ( thường )',N'',69000,19),
(N'Cơm Cháy Thanh Hà siêu ngon',N'',35000,19),
(N'Xiên Mực Xoắn',N'1 Xiên 2 viên',12000,19),
(N'Xiên Tôm Surimi',N'1 Xiên 2 Con',9900,19),
(N'1 Bánh Gà',N'',9000,19),
(N'5 Bánh Bột Lọc Huế Cực Ngon',N'',39000,19),
(N'Nửa Con Gà Ủ Muối/Xông Khói',N'Khách ăn ủ muối hoa tiêu hay xông khói !
Ăn Nóng hay ăn lạnh vui lòng ghi rõ !',95000,19),
(N'Xiên Rau Củ Hải Sản',N'1 Xiên 4 Viên',6500,19),
(N'Dưa Chuột Chẻ ( kèm muối và sốt )',N'',15000,19),
(N'5 Bánh Gà',N'',45000,19),
(N'10 Bánh Bột Lọc Chuẩn Huế Cực Ngon',N'',69000,19),
(N'1 cái PhôMai Que',N'',9000,19),
(N'200gr  Hành Khô Phi Giòn Tan',N'',60000,19),
(N'5 phômai que',N'',45000,19),
(N'Lạc Húng Lìu ( gói )',N'',24000,19),
(N'Xiên Răng Mực',N'',9900,19),
(N'Xiên PhôMai Trứng Muối',N'',9900,19),
(N'Xiên Trứng Cá',N'',9900,19),
(N'Nem Chua Thanh Hoá',N'Chục cais',59000,19),
(N'Xoài Xanh + Muối Hảo Hảo',N'',25000,19),
(N'Trà Đào',N'Đồ uống k có miếng đào ! ',12000,20),
(N'Cocacola  ',N'',12000,20),
(N'Nước Sấu Ngâm',N'',18000,20),
(N'Nước Me Đá Đường',N'',15000,20),
(N'Combo 5 que pate + 1 trà/nước random',N'',45000,21),
(N'Combo 5 que bơ sữa + 1 trà/nước random',N'',39000,21),
(N'Combo 10 que pate + 1 trà/nước random',N'',70000,21),
(N'Combo 5 que pate + 5 que bơ sữa + 1 trà/nước random',N'',70000,21),
(N'Combo 10 que bơ sữa + 1 trà/nước random',N'',65000,21),
(N'Combo 10 que pate + 10 que bơ + 2 trà/nước random',N'',125000,21),
(N'2 Nem Nướng + 2 Trà/Nước Random',N'',127000,22),
(N'1 Nem Nướng + 1 Trà/Nước Random',N'',58000,22),
(N'1 Nem Nướng + 5 bánh mì que pate  + 1 trà/nước random',N'',88000,22),
(N'4 Nem Nướng + 4 Trà/Nước Random',N'',235000,22),
(N'1 Nem Nướng + 5 bmq bơ sữa + 1 trà /nước random',N'',83000,22),
(N'1 Mẹt  + Thịt Thêm 1 Người',N'',63000,22),
(N'2 Mẹt + Thịt Thêm 2 Người',N'',125000,22),
(N'4  Mẹt + 2 Thịt Thêm 2 Người',N'',248000,22),
(N'Truyền Thống L',N'',35000,23),
(N'Truyền Thống XL',N'',45000,23),
(N'Thịt Heo Chiên L',N'',45000,23),
(N'Thịt Heo Chiên XL',N'',55000,23),
(N'Thịt Gà Viên L',N'',45000,23),
(N'Thịt Gà Viên XL',N'',55000,23),
(N'Sốt Kem Hải Sản L',N'',50000,23),
(N'Sốt Kem Hải Sản XL',N'',60000,23),
(N'Truyền Thống L',N'',35000,24),
(N'Truyền Thống XL',N'',45000,24),
(N'Thịt Heo Chiên L',N'',45000,24),
(N'Thịt Heo Chiên XL',N'',55000,24),
(N'Thịt Gà Viên L',N'',45000,24),
(N'Thịt Gà Viên XL',N'',55000,24),
(N'Sốt Kem Hải Sản L',N'',50000,24),
(N'Sốt Kem Hải Sản XL',N'',60000,24),
(N'Truyền Thống L',N'',35000,25),
(N'Truyền Thống XL',N'',45000,25),
(N'Thịt Heo Chiên L',N'',45000,25),
(N'Thịt Heo Chiên XL',N'',55000,25),
(N'Thịt Gà Viên L',N'',45000,25),
(N'Thịt Gà Viên XL',N'',55000,25),
(N'Sốt Kem Hải Sản L',N'',50000,25),
(N'Sốt Kem Hải Sản XL',N'',60000,25),
(N'Okonomiyaki',N'Vị heo, gà, hải sản',50000,26),
(N'Gà Chiên Karaage',N'',45000,26),
(N'Nước Ngọt',N'Coca, Pesi, 7Up',15000,27),
(N'Trà Chanh',N'',10000,27),
(N'Trà Đào',N'',10000,27),
(N'Trà Quất Mật Ong',N'',20000,27)

GO

INSERT INTO [dbo].[bill_status]
           ([name],[status])
     VALUES
           (N'Pending',1),(N'Paying',1),(N'Checking',1),(N'Preparing',1),(N'Shipping',1),(N'Done',1)
GO

UPDATE [dbo].[restaurant] set bank=N'Ngân hàng Quân đội Nhân Dân Việt Nam - MB Bank', accountNumber='3300123456333' where Id=1
UPDATE [dbo].[restaurant] set bank=N'Ngân hàng Thương mại cổ phần Công Thương Việt Nam - Vietinbank', accountNumber='105873255144' where Id=3