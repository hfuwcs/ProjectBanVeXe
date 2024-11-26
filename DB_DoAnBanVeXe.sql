-- Tạo cơ sở dữ liệu DB_DoAnBanVeXe
CREATE DATABASE DB_DoAnBanVeXe;
USE DB_DoAnBanVeXe;

-- Bảng Người dùng (UserAccount)
CREATE TABLE UserAccount (
    UserID INT PRIMARY KEY IDENTITY(1,1),  -- ID tự tăng
    FullName NVARCHAR(100),                -- Họ và tên
    Email VARCHAR(100) UNIQUE,             -- Email
    Password VARCHAR(100)                  -- Mật khẩu
);

-- Bảng Vai trò (Roles)
CREATE TABLE Roles (
    RolesID INT PRIMARY KEY IDENTITY(1,1),  -- ID tự tăng
    RoleName NVARCHAR(50) UNIQUE            -- Tên vai trò (Quản lý, Nhân viên)
);

-- Bảng Phân quyền (UserRoles)
CREATE TABLE UserRoles (
    UserRolesID INT PRIMARY KEY IDENTITY(1,1),  -- ID tự tăng
    UserID INT,                        -- Foreign Key liên kết với UserAccount
    RoleID INT,                        -- Foreign Key liên kết với Roles
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RolesID)
);

-- Bảng Hành khách (Passenger)
CREATE TABLE Passenger (
    PassengerID INT PRIMARY KEY IDENTITY(1,1),   -- ID tự tăng
    FullName NVARCHAR(255),                      -- Họ và tên hành khách
    PhoneNumber VARCHAR(20),                     -- Số điện thoại
    Email VARCHAR(255)                           -- Email
);

-- Bảng Xe (Bus)
CREATE TABLE Bus (
    BusID INT PRIMARY KEY IDENTITY(1,1),    -- ID tự tăng
    BusNumber VARCHAR(50),                  -- Số xe
    TotalSeat INT,                          -- Tổng số ghế
    BusType NVARCHAR(50)                    -- Loại xe
);

-- Bảng Ghế (Seat)
CREATE TABLE Seat (
    SeatID INT PRIMARY KEY IDENTITY(1,1),    -- ID tự tăng
    BusID INT,                               -- Mã xe mà ghế thuộc về
    SeatNumber VARCHAR(10),                  -- Số ghế (A1, A2,..., A44)
    FOREIGN KEY (BusID) REFERENCES Bus(BusID)
);

-- Bảng Tài xế (Driver)
CREATE TABLE Driver (
    DriverID INT PRIMARY KEY IDENTITY(1,1),   -- ID tự tăng
    FullName NVARCHAR(255),                    -- Tên tài xế
    LicenseNumber VARCHAR(50),                 -- Số giấy phép lái xe
    PhoneNumber VARCHAR(20)                    -- Số điện thoại
);

-- Bảng Tuyến (Route)
CREATE TABLE Route (
    RouteID INT PRIMARY KEY IDENTITY(1,1),    -- ID tự tăng
    RouteName NVARCHAR(255),                  -- Tên tuyến
    StartLocation NVARCHAR(255),              -- Điểm khởi hành
    EndLocation NVARCHAR(255),                -- Điểm đến
    Distance INT                              -- Khoảng cách
);

-- Bảng Chuyến xe (Trip)
CREATE TABLE Trip (
    TripID INT PRIMARY KEY IDENTITY(1,1),    -- ID tự tăng
    RouteID INT,                             -- Mã tuyến (liên kết với bảng Route)
    BusID INT,                               -- Mã xe (liên kết với bảng Bus)
    DriverID INT,                            -- Mã tài xế (liên kết với bảng Driver)
    DepartureLocation NVARCHAR(255),         -- Điểm khởi hành
    ArrivalLocation NVARCHAR(255),           -- Điểm đến
    DepartureTime DATETIME,                  -- Thời gian khởi hành
    ArrivalTime DATETIME,                    -- Thời gian đến
    FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    FOREIGN KEY (BusID) REFERENCES Bus(BusID),
    FOREIGN KEY (DriverID) REFERENCES Driver(DriverID)
);

-- Bảng Đơn đặt vé (OrderTicket)
CREATE TABLE OrderTicket (
    OrderTicketID INT PRIMARY KEY IDENTITY(1,1),  -- ID tự tăng
    PassengerID INT,                              -- Mã hành khách (liên kết với bảng Passenger)
    Total DECIMAL(18, 2),                         -- Tổng tiền (kiểu decimal thay cho money)
    OrderDate DATETIME,							  -- Ngày phát hành
	UserID INT									    --Mã của nhân viên 		
    FOREIGN KEY (PassengerID) REFERENCES Passenger(PassengerID)
);

-- Bảng Chi tiết vé (DetailsTicket)
CREATE TABLE DetailsTicket (
    DetailsTicketID INT PRIMARY KEY IDENTITY(1,1),  -- ID tự tăng
    OrderTicketID INT,                               -- Mã đơn đặt vé (liên kết với bảng OrderTicket)
    TripID INT,                                      -- Mã chuyến đi (liên kết với bảng Trip)
    SeatID INT,                                      -- Mã ghế đã chọn (liên kết với bảng Seat)
    IsBooked BIT,                                    -- Trạng thái ghế (0: Chưa đặt, 1: Đã đặt)
    Price DECIMAL(18, 2),                            -- Giá vé (kiểu decimal thay cho money)
    FOREIGN KEY (OrderTicketID) REFERENCES OrderTicket(OrderTicketID) ON DELETE CASCADE,
    FOREIGN KEY (TripID) REFERENCES Trip(TripID),
    FOREIGN KEY (SeatID) REFERENCES Seat(SeatID)
);

-- Bảng Thanh toán (Payment)
CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),        -- ID tự tăng
    OrderTicketID INT,                              -- Mã đơn đặt vé (liên kết với bảng OrderTicket)
    Amount DECIMAL(18, 2),                          -- Số tiền thanh toán (kiểu decimal thay cho money)
    PaymentMethod NVARCHAR(50),                     -- Phương thức thanh toán
    PaymentDate DATETIME,                           -- Ngày thanh toán
    PaymentStatus NVARCHAR(50),                     -- Trạng thái thanh toán
    FOREIGN KEY (OrderTicketID) REFERENCES OrderTicket(OrderTicketID)
);
