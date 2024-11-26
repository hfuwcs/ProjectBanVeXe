use DB_DoAnBanVeXe

-- Thêm dữ liệu cho bảng Roles
INSERT INTO Roles (RoleName)
VALUES 
(N'Quản lý'),
(N'Nhân viên');

-- Thêm dữ liệu cho bảng UserAccount
INSERT INTO UserAccount (FullName, Email, Password)
VALUES 
(N'Nguyen Van A', 'nguyenvana@example.com', 'password123'),
(N'Le Thi B', 'lethib@example.com', 'password456'),
(N'Tran Van C', 'tranvanc@example.com', 'password789'),
(N'Lưu Hoàng Phúc','admin','123')



-- Thêm dữ liệu cho bảng UserRoles
INSERT INTO UserRoles (UserID, RoleID)
VALUES 
(1, 1), -- User 1 là Quản lý
(2, 2), -- User 2 là Nhân viên
(3, 2), -- User 3 là Nhân viên
(4, 1) -- User 4 là Quản lý



-- Thêm dữ liệu cho bảng Passenger
INSERT INTO Passenger (FullName, PhoneNumber, Email)
VALUES 
(N'Nguyen Thi D', '0912345678', 'nguyenthid@example.com'),
(N'Pham Van E', '0987654321', 'phamvane@example.com'),
(N'Nguyen Thi F', '091234544', 'nguyenthif@example.com'),
(N'Lưu Hoàng Phúc','0776848611','luuphuc588@gmail.com')

-- Thêm dữ liệu cho bảng Bus
INSERT INTO Bus (BusNumber, TotalSeat, BusType)
VALUES 
('79A-12345', 44, N'Xe khách 45 chỗ'),
('43B-67890', 44, N'Xe khách 45 chỗ');

-- Thêm dữ liệu cho bảng Seat
-- Thêm dữ liệu ghế cho xe 1 và xe 2 (44 ghế mỗi xe, từ A1-A22 và B1-B22)
INSERT INTO Seat (BusID, SeatNumber)
VALUES 
(1, 'A01'), (1, 'A02'), (1, 'A03'), (1, 'A04'), (1, 'A05'), (1, 'A06'), (1, 'A07'), (1, 'A08'), (1, 'A09'), (1, 'A10'), (1, 'A11'), (1, 'A12'), (1, 'A13'), (1, 'A14'), (1, 'A15'), (1, 'A16'), (1, 'A17'), (1, 'A18'), (1, 'A19'), (1, 'A20'), (1, 'A21'), (1, 'A22'), -- Ghế xe 1 từ A1 đến A22
(1, 'B01'), (1, 'B02'), (1, 'B03'), (1, 'B04'), (1, 'B05'), (1, 'B06'), (1, 'B07'), (1, 'B08'), (1, 'B09'), (1, 'B10'), (1, 'B11'), (1, 'B12'), (1, 'B13'), (1, 'B14'), (1, 'B15'), (1, 'B16'), (1, 'B17'), (1, 'B18'), (1, 'B19'), (1, 'B20'), (1, 'B21'), (1, 'B22'), -- Ghế xe 1 từ B1 đến B22
(2, 'A01'), (2, 'A02'), (2, 'A03'), (2, 'A04'), (2, 'A05'), (2, 'A06'), (2, 'A07'), (2, 'A08'), (2, 'A09'), (2, 'A10'), (2, 'A11'), (2, 'A12'), (2, 'A13'), (2, 'A14'), (2, 'A15'), (2, 'A16'), (2, 'A17'), (2, 'A18'), (2, 'A19'), (2, 'A20'), (2, 'A21'), (2, 'A22'), -- Ghế xe 2 từ A1 đến A22
(2, 'B01'), (2, 'B02'), (2, 'B03'), (2, 'B04'), (2, 'B05'), (2, 'B06'), (2, 'B07'), (2, 'B08'), (2, 'B09'), (2, 'B10'), (2, 'B11'), (2, 'B12'), (2, 'B13'), (2, 'B14'), (2, 'B15'), (2, 'B16'), (2, 'B17'), (2, 'B18'), (2, 'B19'), (2, 'B20'), (2, 'B21'), (2, 'B22'); -- Ghế xe 2 từ B1 đến B22

-- Thêm dữ liệu cho bảng Driver
-- Thêm 5 tài xế vào bảng Driver
INSERT INTO Driver (FullName, LicenseNumber, PhoneNumber)
VALUES 
(N'Nguyen Van F', '123456789', '0911222333'),
(N'Tran Thi G', '987654321', '0944556677'),
(N'Le Thi H', '112233445', '0988776655'),
(N'Pham Minh K', '223344556', '0909112233'),
(N'Hoang Anh T', '334455667', '0912345678');



-- Thêm dữ liệu cho bảng Route
INSERT INTO Route (RouteName, StartLocation, EndLocation, Distance)
VALUES 
(N'TP HCM - Da Nang', N'TP HCM', N'Da Nang', 800),
(N'TP HCM - Ha Noi', N'TP HCM', N'Ha Noi', 1700),
(N'TP HCM - Nha Trang', N'TP HCM', N'Nha Trang', 400),
(N'Ha Noi - Hai Phong', N'Ha Noi', N'Hai Phong', 1200);

-- Thêm dữ liệu cho bảng Trip
INSERT INTO Trip (RouteID, BusID, DriverID, DepartureLocation, ArrivalLocation, DepartureTime, ArrivalTime)
VALUES 
(1, 1, 1, N'TP HCM', N'Da Nang', '2024-10-11 08:00', '2024-10-11 20:00'),
(2, 2, 2, N'TP HCM', N'Ha Noi', '2024-10-12 09:00', '2024-10-13 09:00');

-- Thêm dữ liệu cho bảng OrderTicket
INSERT INTO OrderTicket (PassengerID, Total, OrderDate,UserID)
VALUES 
(1, 300000.00, '2024-10-10',2),
(2, 500000.00, '2024-10-09',3);

-- Thêm dữ liệu cho bảng DetailsTicket
INSERT INTO DetailsTicket (OrderTicketID, TripID, SeatID, IsBooked, Price)
VALUES 
(1, 1, 1, 1, 300000.00), -- Hành khách 1 đặt vé ghế A1
(2, 2, 5, 1, 500000.00); -- Hành khách 2 đặt vé ghế B1

-- Thêm dữ liệu cho bảng Payment
INSERT INTO Payment (OrderTicketID, Amount, PaymentMethod, PaymentDate, PaymentStatus)
VALUES 
(1, 300000.00, N'Tiền mặt', '2024-10-10', N'Đã thanh toán'),
(2, 500000.00, N'Chuyển khoản', '2024-10-09', N'Đã thanh toán');



--Thêm nếu cần thiết-

-- Thêm dữ liệu cho bảng UserAccount
INSERT INTO UserAccount (FullName, Email, Password)
VALUES 
(N'Tran Thi M', 'tranthim@example.com', 'password987'),
(N'Hoang Van N', 'hoangvann@example.com', 'password654'),
(N'Le Van O', 'levano@example.com', 'password321'),
(N'Nguyen Thi P', 'nguyenthid@example.com', 'password741'),
(N'Pham Van Q', 'phamvanq@example.com', 'password852');

-- Thêm dữ liệu cho bảng Roles (nếu cần thêm vai trò mới)
-- INSERT INTO Roles (RoleName)
-- VALUES 
-- (N'Giám đốc'),
-- (N'Khách hàng');

-- Thêm dữ liệu cho bảng UserRoles
INSERT INTO UserRoles (UserID, RoleID)
VALUES 
(5, 2), -- User 5 là Nhân viên
(6, 2), -- User 6 là Nhân viên
(7, 1), -- User 7 là Quản lý
(8, 1), -- User 8 là Quản lý
(9, 2); -- User 9 là Nhân viên

-- Thêm dữ liệu cho bảng Passenger
INSERT INTO Passenger (FullName, PhoneNumber, Email)
VALUES 
(N'Nguyen Thi G', '0911223344', 'nguyenthig@example.com'),
(N'Tran Van H', '0912233445', 'tranvanh@example.com'),
(N'Le Thi I', '0923344556', 'lethii@example.com'),
(N'Pham Thi J', '0934455667', 'phamthij@example.com'),
(N'Tran Minh K', '0945566778', 'tranminhk@example.com');

-- Thêm dữ liệu cho bảng Bus
INSERT INTO Bus (BusNumber, TotalSeat, BusType)
VALUES 
('34C-12346', 44, N'Xe khách 45 chỗ'),
('89D-98765', 44, N'Xe khách 45 chỗ')
('21C-34846', 44, N'Xe khách 45 chỗ'),
('36D-58765', 44, N'Xe khách 45 chỗ'),
('59D-49165', 44, N'Xe khách 45 chỗ')


INSERT INTO Seat (BusID, SeatNumber)
VALUES 
(3, 'A01'), (3, 'A02'), (3, 'A03'), (3, 'A04'), (3, 'A05'), (3, 'A06'), (3, 'A07'), (3, 'A08'), (3, 'A09'), (3, 'A10'), (3, 'A11'), (3, 'A12'), (3, 'A13'), (3, 'A14'), (3, 'A15'), (3, 'A16'), (3, 'A17'), (3, 'A18'), (3, 'A19'), (3, 'A20'), (3, 'A21'), (3, 'A22'), -- Ghế xe 3 từ A1 đến A22
(3, 'B01'), (3, 'B02'), (3, 'B03'), (3, 'B04'), (3, 'B05'), (3, 'B06'), (3, 'B07'), (3, 'B08'), (3, 'B09'), (3, 'B10'), (3, 'B11'), (3, 'B12'), (3, 'B13'), (3, 'B14'), (3, 'B15'), (3, 'B16'), (3, 'B17'), (3, 'B18'), (3, 'B19'), (3, 'B20'), (3, 'B21'), (3, 'B22'), -- Ghế xe 3 từ B1 đến B22
(4, 'A01'), (4, 'A02'), (4, 'A03'), (4, 'A04'), (4, 'A05'), (4, 'A06'), (4, 'A07'), (4, 'A08'), (4, 'A09'), (4, 'A10'), (4, 'A11'), (4, 'A12'), (4, 'A13'), (4, 'A14'), (4, 'A15'), (4, 'A16'), (4, 'A17'), (4, 'A18'), (4, 'A19'), (4, 'A20'), (4, 'A21'), (4, 'A22'), -- Ghế xe 4 từ A1 đến A22
(4, 'B01'), (4, 'B02'), (4, 'B03'), (4, 'B04'), (4, 'B05'), (4, 'B06'), (4, 'B07'), (4, 'B08'), (4, 'B09'), (4, 'B10'), (4, 'B11'), (4, 'B12'), (4, 'B13'), (4, 'B14'), (4, 'B15'), (4, 'B16'), (4, 'B17'), (4, 'B18'), (4, 'B19'), (4, 'B20'), (4, 'B21'), (4, 'B22'); -- Ghế xe 4 từ B1 đến B22


-- Thêm dữ liệu cho bảng Driver
INSERT INTO Driver (FullName, LicenseNumber, PhoneNumber)
VALUES 
(N'Nguyen Van L', '556677889', '0911122334'),
(N'Tran Thi M', '667788990', '0912233445'),
(N'Pham Van N', '778899001', '0913344556'),
(N'Le Thi O', '889900112', '0914455667'),
(N'Tran Minh P', '990011223', '0915566778');

-- Thêm dữ liệu cho bảng Route
INSERT INTO Route (RouteName, StartLocation, EndLocation, Distance)
VALUES 
(N'TP HCM - Hue', N'TP HCM', N'Hue', 700),
(N'TP HCM - Vinh', N'TP HCM', N'Vinh', 1300),
(N'Da Lat - Vung Tau', N'Đà Lạt', N'Vũng Tàu', 280),
(N'An Giang - TP HCM', N'An Giang', N'TP HCM', 230),
(N'Nha Trang - TP HCM', N'Nha Trang', N'TP HCM', 320);

-- Thêm dữ liệu cho bảng Trip
INSERT INTO Trip (RouteID, BusID, DriverID, DepartureLocation, ArrivalLocation, DepartureTime, ArrivalTime)
VALUES 
(3, 3, 3, N'TP HCM', N'Nha Trang', '2024-10-13 07:00', '2024-10-13 15:00'),
(4, 4, 4, N'TP HCM', N'Hue', '2024-10-14 06:00', '2024-10-14 18:00'),
(7, 5, 5, N'Đà Lạt', N'Vũng Tàu', '2024-10-15 08:00', '2024-10-15 11:00'),
(8, 3, 3, N'An Giang', N'TP HCM', '2024-10-16 09:00', '2024-10-16 22:00'),
(9, 2, 2, N'Nha Trang', N'TP HCM', '2024-10-17 08:00', '2024-10-17 12:00');

-- Thêm dữ liệu cho bảng OrderTicket
INSERT INTO OrderTicket (PassengerID, Total, OrderDate, UserID)
VALUES 
(3, 400000.00, '2024-10-11', 4),
(4, 250000.00, '2024-10-12', 5),
(5, 550000.00, '2024-10-13', 6),
(1, 350000.00, '2024-10-14', 2),
(2, 600000.00, '2024-10-15', 3);

-- Thêm dữ liệu cho bảng DetailsTicket
INSERT INTO DetailsTicket (OrderTicketID, TripID, SeatID, IsBooked, Price)
VALUES 
(3, 1, 10, 1, 400000.00), -- Hành khách 3 đặt vé ghế A10
(4, 2, 15, 1, 250000.00), -- Hành khách 4 đặt vé ghế A15
(5, 10, 20, 1, 550000.00), -- Hành khách 5 đặt vé ghế B20
(6, 11, 5, 1, 350000.00), -- Hành khách 1 đặt vé ghế A5
(7, 12, 9, 1, 600000.00); -- Hành khách 2 đặt vé ghế B9

-- Thêm dữ liệu cho bảng Payment
INSERT INTO Payment (OrderTicketID, Amount, PaymentMethod, PaymentDate, PaymentStatus)
VALUES 
(3, 400000.00, N'Tiền mặt', '2024-10-11', N'Đã thanh toán'),
(4, 250000.00, N'Chuyển khoản', '2024-10-12', N'Đã thanh toán'),
(5, 550000.00, N'Tiền mặt', '2024-10-13', N'Đã thanh toán'),
(6, 350000.00, N'Chuyển khoản', '2024-10-14', N'Đã thanh toán'),
(7, 600000.00, N'Tiền mặt', '2024-10-15', N'Đã thanh toán');
