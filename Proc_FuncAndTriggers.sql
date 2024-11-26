USE DB_DoAnBanVeXe
GO

--NHẬP DỮ LIỆU TRƯỚC KHI CHẠY STORED PROCEDURE, FUNCTION VÀ TRIGGER!!!



--START: TRIGGER Insert VE XE

--TRIGGER 1: WHEN UPDATE DETAILSTICKET, INSERT INTO ORDERTICKET
GO
 CREATE TRIGGER UPDATETOTAL ON DETAILSTICKET
 FOR INSERT
 AS
	UPDATE OrderTicket 
	SET Total += (SELECT PRICE FROM inserted)
	FROM inserted
	WHERE OrderTicket.OrderTicketID = inserted.OrderTicketID


--trigger 3:....

--TRA CỨU VÉ
CREATE FUNCTION TRACUUVE(@SDT NVARCHAR(20), @DPT NVARCHAR(50))
RETURNS @BANGTRACUU TABLE(DetailsTicketID INT, FullName NVARCHAR(50), PhoneNumber NVARCHAR(50) , DepartureLocation NVARCHAR(50), ArrivalLocation NVARCHAR(50), DepartureTime DATETIME, SeatNumber Char(10),  Price decimal(18, 2) )
AS
BEGIN
	INSERT INTO @BANGTRACUU
		SELECT DT.DetailsTicketID, P.FullName, P.PhoneNumber, T.DepartureLocation,T.ArrivalLocation, T.DepartureTime, S.SeatNumber,  DT.Price
		FROM Passenger P
			inner JOIN OrderTicket OT
			ON P.PassengerID=OT.PassengerID
				INNER JOIN DetailsTicket DT 
				ON OT.OrderTicketID=DT.OrderTicketID
					INNER JOIN TRIP T
					ON T.TripID=DT.TripID
						INNER JOIN SEAT S
						ON S.SeatID=DT.SeatID
		WHERE P.PhoneNumber=@SDT AND DATEDIFF(DAY,T.DepartureTime,@DPT)=0
	RETURN
END
--STORED PROCEDURE

--GET USER
CREATE PROC GetUserByUsername @username nvarchar(100)
as
BEGIN
	SELECT * from UserAccount
	WHERE Email = @username
END

--LẤY TÀI KHOẢN BẰNG ID
CREATE PROC GetUserByUserID @userid int
as
BEGIN
	SELECT * from UserAccount
	WHERE UserID = @userid
END

--IsLogin - Kiểm tra đã đăng nhập chưa
CREATE PROC IsLogin @USERNAME NVARCHAR(100), @PASSWORD NVARCHAR(100)
AS
BEGIN
	SELECT Email, Password
	from UserAccount
	where Email=@USERNAME and Password = @PASSWORD
END

--IsAdmin
CREATE PROC IsAdmin @USERNAME NVARCHAR(100), @PASSWORD NVARCHAR(100)
AS
BEGIN
	SELECT Email, Password, UR.RoleID
	from UserAccount UA
	JOIN UserRoles UR
	ON UA.UserID=UR.UserID
	where Email=@USERNAME and Password = @PASSWORD AND  UR.RoleID = 1
END 

--Lấy Cấp bậc
CREATE PROC GetRoleName @USERID INT
AS
BEGIN
	SELECT RoleName from Roles R INNER JOIN UserRoles UR ON R.RolesID = UR.RoleID 
	INNER JOIN UserAccount UA ON UR.UserID = UA.UserID 
	WHERE UA.UserID = @USERID
END



--ĐỔI MẬT KHẨU
GO
CREATE PROC DOIMATKHAU @NEWPASS NVARCHAR(100), @USERID INT
AS
  UPDATE UserAccount
  SET Password = @NEWPASS
  WHERE UserID = @USERID

--Tìm chuyến xe
CREATE PROC TIMCHUYENXE 
@DEPLOC NVARCHAR(100), @ARRLOC NVARCHAR(100), @SECLECTEDDAY NVARCHAR(100)
AS
BEGIN
  select B.BusID, BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime 
  from  Bus B Inner join Trip T on b.BusID=t.BusID 
  WHERE DepartureLocation = @DEPLOC AND ArrivalLocation= @ARRLOC AND DATEDIFF(HOUR, T.DepartureTime , @SECLECTEDDAY)=0
END


  -- TRUY VAN TIM DOANH THU 
CREATE PROC TIMDOANHTHU 
	@STARTDAY DATE, @ENDDAY DATE, @DEPLOC NVARCHAR(30), @ARRLOC NVARCHAR(30),
	@TOTALINCOME DECIMAL(18, 2) OUT
AS
SET @TOTALINCOME = (Select sum(Total) 
 from OrderTicket OT
 JOIN DetailsTicket DT ON OT.OrderTicketID=DT.OrderTicketID
	JOIN Trip T ON DT.TripID=T.TripID
 where 
	OrderDate >=@STARTDAY and OrderDate<=@ENDDAY
	AND
	T.DepartureLocation=@DEPLOC AND T.ArrivalLocation=@ARRLOC)
GO


--INSERT TRIP
CREATE PROC InsertTrip 
@RouteID int, @BusID int, @DriverID int, @DeppLoc nvarchar(100), @ArrLoc nvarchar(100), @DeppTime nvarchar(100), @ArrTime nvarchar(100)
AS
BEGIN
		INSERT INTO Trip ([RouteID]
		  ,[BusID]
		  ,[DriverID]
		  ,[DepartureLocation]
		  ,[ArrivalLocation]
		  ,[DepartureTime]
		  ,[ArrivalTime]
		  )
		VALUES (@RouteID , @BusID , @DriverID , @DeppLoc, @ArrLoc , @DeppTime , @ArrTime)
END

--=====
CREATE PROC GETREADYBUS @TODAY NVARCHAR(100) --done this one
AS
BEGIN
	SELECT BusID [Mã xe] , BusNumber [Biển số xe], TotalSeat [Tổng số ghế], BusType [Loại xe]
	FROM Bus B
	WHERE B.BusID NOT IN (SELECT BUSID FROM TRIP GROUP BY BUSID) 
	OR B.BusID IN (SELECT BUSID FROM TRIP WHERE DATEDIFF(HOUR,ArrivalTime, @TODAY)>0)
END


--======
CREATE PROC GETREADYDRIVER @TODAY NVARCHAR(100)
AS
BEGIN
	SELECT DRIVERID
	FROM DRIVER
	WHERE DRIVERID NOT IN (SELECT DRIVERID FROM TRIP GROUP BY DRIVERID) 
	OR DRIVERID IN (SELECT DRIVERID FROM TRIP WHERE DATEDIFF(HOUR,ArrivalTime, @TODAY)>0)
END





--ORDER TICKET

--as its name
CREATE PROC GetLatestOrderID @ORDERDATE nvarchar(100), @PassengerID int
AS
BEGIN
	select TOP 1 OrderTicketID from OrderTicket 
	where DATEDIFF(DAY,OrderDate,@ORDERDATE)=0 and PassengerID = @PassengerID
	order by OrderTicketID DESC
END

--Insert Order


CREATE PROC InsertOrderTicket @pID int, @ORDERDATE nvarchar(100), @userID int
AS
	Insert into OrderTicket([PassengerID], [Total], [OrderDate], [UserID]) 
	VALUES (@pID, 0 ,@ORDERDATE, @UserID)

--DETAILS TICKET 
CREATE PROC InsertDetailsTicket @OrderTicketID INT, @TripID INT, @SeatID INT, @IsBooked int, @PRICE int
AS
BEGIN
	INSERT INTO DetailsTicket(OrderTicketID, TripID , SeatID, IsBooked, Price) 
    VALUES(@OrderTicketID,  @TripID, @SeatID, @IsBooked, @Price)
END

--BUS

CREATE PROC GetSeatID @SeatNumber nvarchar(100), @BusID int
AS
BEGIN
SELECT * FROM SEAT WHERE SeatNumber = @SeatNumber AND BusID = @BusID
END