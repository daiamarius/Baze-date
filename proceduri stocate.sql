use TripAdvisor
-- list restaurante
IF OBJECT_ID('getRestaurants','P') IS NOT NULL
	DROP PROCEDURE getRestaurants
go
CREATE PROCEDURE getRestaurants @Oras nvarchar(50)
AS
select	r.RestaurantID,r.Nume,Convert(varbinary(max),r.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.RestaurantID),0) as NrReviewuri
from Restaurante as r
inner join Orase as o
on o.OrasID = r.OrasID
left join RecenziiRestaurante as rep
on rep.RestaurantID = r.RestaurantID
WHERE o.Nume = @Oras
group by r.Nume,r.RestaurantID,Convert(varbinary(max),r.Poza)
order by NrReviewuri



--list hoteluri
IF OBJECT_ID('getHotels', 'P') IS NOT NULL
    DROP PROCEDURE getHotels 
go
CREATE PROCEDURE getHotels @Oras nvarchar(50)
AS
select h.CazareID,h.Nume,h.Adresa,Convert(varbinary(max),h.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.CazareID),0) as NrReviewuri
from Cazare as h
inner join Orase as o
on o.OrasID = h.OrasID
left join RecenziiHoteluri as rep
on rep.CazareID = h.CazareID
WHERE o.Nume = @Oras
group by h.Nume,h.Adresa,h.CazareID,Convert(varbinary(max),h.Poza)
order by NrReviewuri


--foto restaurante
IF (OBJECT_ID('getRestaurantPhotos','P') IS NOT NULL)
	DROP PROCEDURE getRestaurantPhotos
go
CREATE PROCEDURE getRestaurantPhotos @restaurantID int
AS
select u.Nume,u.Prenume,p.Poza,p.Data
from PozeRestaurante as p
inner join Utilizatori as u
on u.UserID=p.UserID
where p.RestaurantID=@restaurantID
order by p.Data desc

--foto hoteluri 
IF (OBJECT_ID('getHotelPhotos', 'P') IS NULL)
    DROP PROCEDURE getHotelPhotos
go 
CREATE PROCEDURE getHotelPhotos @cazareID int 
AS 
select u.Nume, u.Prenume, p.Poza, p.Data
from PozeHotel as p
inner join Utilizatori as u 
on u.UserID=p.UtilizatorID
where p.CazareID=@cazareID
order by p.Data desc 




--top3 restaurante by reviews
IF (OBJECT_ID('getTop3Restaurants','P') IS NOT NULL)
	DROP PROCEDURE getTop3Restaurants
go
CREATE PROCEDURE getTop3Restaurants @Oras nvarchar(50)
AS
select top 3 r.RestaurantID,r.Nume,Convert(varbinary(max),r.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.RestaurantID),0) as NrReviewuri
from Restaurante as r
inner join Orase as o
on o.OrasID = r.OrasID
left join RecenziiRestaurante as rep
on rep.RestaurantID = r.RestaurantID
WHERE o.Nume = @Oras
group by r.Nume,r.RestaurantID,Convert(varbinary(max),r.Poza)
order by UserReview desc

-- top 3 Hotels by reviews
IF (OBJECT_ID('getTop3Hotels', 'P') IS NOT NULL)
   DROP PROCEDURE getTop3Hotels
go
CREATE PROCEDURE getTop3Hotels @Oras nvarchar(50)
AS
select top 3 h.CazareID,h.Nume,Convert(varbinary(max),h.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.CazareID),0) as NrReviewuri
from Cazare as h
inner join Orase as o
on o.OrasID = h.OrasID
left join RecenziiHoteluri as rep
on rep.CazareID = h.CazareID
WHERE o.Nume = @Oras
group by h.Nume,h.Adresa,h.CazareID,Convert(varbinary(max),h.Poza)
order by UserReview desc

---restaurant reviews
IF (OBJECT_ID('getRestaurantReviews','P') IS NOT NULL)
	DROP PROCEDURE getRestaurantReviews
go
CREATE PROCEDURE getRestaurantReviews @restId int
AS
select u.Nume+' '+u.Prenume as Nume,rec.Stele,rec.Pret,rec.Comentarii,rec.Data,Convert(varbinary(max),u.Poza) as Poza
from Restaurante as r
inner join RecenziiRestaurante as rec
on rec.RestaurantID = r.RestaurantID
inner join Utilizatori as u
on u.UserID=rec.UserID
where r.RestaurantID=@restId
order by rec.Data desc

--hotels reviews 
IF (OBJECT_ID('getHotelReviews', 'P') IS NOT NULL)
    DROP PROCEDURE getHotelReviews
go
CREATE PROCEDURE getHotelReviews @cazareId int 
AS 
select u.Nume+' '+u.Prenume as Nume, rec.Stele, rec.Pret, rec.Comentarii, rec.Data, Convert(varbinary(max), h.Poza) as Poza
from Cazare as h
inner join RecenziiHoteluri as rec
on rec.CazareID=h.CazareID
inner join Utilizatori as u
on u.UserID=rec.UserID
where h.CazareID=@cazareId
order by rec.Data desc

---get preparate
IF (OBJECT_ID('getPreparate','P') IS NOT NULL)
	DROP PROCEDURE getPreparate
go
create procedure getPreparate @Oras nvarchar(50)
as
select Convert(varbinary(max),p.Poza) as Poza,
		p.Denumire,COUNT(*) as KindNumber,p.PreparatID
from Meniu as m
inner join dbo.Preparate as p
on p.PreparatID = m.PreparatID
inner join Restaurante as r
on r.RestaurantID = m.RestaurantID
inner join Orase as o
on o.OrasID = r.OrasID
where o.Nume=@Oras
group by p.Denumire,p.PreparatID,Convert(varbinary(max),p.Poza)


--get HotelRoomPhotos
IF OBJECT_ID('getHotelRoomPhotos', 'P') IS NOT NULL
    DROP PROCEDURE getHotelRoomPhotos 
go 
create procedure getHotelRoomPhotos @Oras as nvarchar(50)
as
select Convert(varbinary(max),c.Poza) as Poza,
      c.NumarPaturi, COUNT(*) as KindNumber
from Camere as c
inner join dbo.Cazare as caz
on c.CazareID=caz.CazareID
inner join Orase as o 
on o.OrasID=caz.OrasID
where o.Nume=@oras
group by c.NumarPaturi,  Convert(varbinary(max), c.Poza)




--get restaurant description
IF (OBJECT_ID('getRestaurantMenu','P') IS NOT NULL)
	DROP PROCEDURE getRestaurantMenu
go
create procedure getRestaurantMenu @restId int
as
select p.Denumire
from Restaurante as r
inner join Meniu as m
on m.RestaurantID = r.RestaurantID
inner join Preparate as p
on p.PreparatID = m.PreparatID
where r.RestaurantID=@restId

--get hotel rooms 
IF(OBJECT_ID('getHotelRooms', 'P') IS NOT NULL)
   DROP PROCEDURE getHotelRooms
go 
create procedure getHotelRooms @cazareId int 
as
select cam.NumarPaturi 
from Cazare as caz
inner join Camere as cam 
on cam.CazareID=caz.CazareID
where caz.CazareID=@cazareId




--get restaurant details
IF (OBJECT_ID('getRestaurantDetails','P') IS NOT NULL)
	DROP PROCEDURE getRestaurantDetails
go
create procedure getRestaurantDetails @restId int
as
select r.Nume,r.Adresa,r.Program,r.NumarTelefon,Convert(varbinary(max),r.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.RestaurantID),0) as NrReviewuri
from Restaurante as r
left join RecenziiRestaurante as rep
on rep.RestaurantID = r.RestaurantID
WHERE r.RestaurantID = @restId
group by r.Nume,r.Adresa,r.RestaurantID,r.NumarTelefon,r.Program,Convert(varbinary(max),r.Poza)

--get hotel details  
 IF (OBJECT_ID('getHotelDetails','P') IS NOT NULL)
	DROP PROCEDURE getHotelDetails
go
create procedure getHotelDetails @cazareId int
as
select h.Nume,h.Adresa,h.Email,h.NrTelefon,Convert(varbinary(max),h.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.CazareID),0) as NrReviewuri
from Cazare as h
left join RecenziiHoteluri as rep
on rep.CazareID = h.CazareID
WHERE h.CazareID = @cazareId
group by h.Nume,h.Adresa,h.CazareID,h.NrTelefon,h.Email,Convert(varbinary(max),h.Poza)


--get restaurants by food
IF OBJECT_ID('getRestaurantsByFood','P') IS NOT NULL
	DROP PROCEDURE getRestaurantsByFood
go
CREATE PROCEDURE getRestaurantsByFood @Oras nvarchar(50),@Foodtype int
AS
select	r.RestaurantID,r.Nume,Convert(varbinary(max),r.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.RestaurantID),0) as NrReviewuri
from Restaurante as r
inner join Orase as o
on o.OrasID = r.OrasID
left join RecenziiRestaurante as rep
on rep.RestaurantID = r.RestaurantID
inner join Meniu as m
on m.RestaurantID = r.RestaurantID
inner join Preparate as p
on p.PreparatID = m.PreparatID
WHERE o.Nume = @Oras and p.PreparatID=@Foodtype
group by r.Nume,r.RestaurantID,Convert(varbinary(max),r.Poza)
order by NrReviewuri

--get hotels by rooms 
IF OBJECT_ID('getHotelsByRooms','P') IS NOT NULL
	DROP PROCEDURE getHotelsByRooms
go
CREATE PROCEDURE getHotelsByRooms @Oras nvarchar(50),@NumarPaturi int
AS
select	h.CazareID,h.Nume,Convert(varbinary(max),h.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.CazareID),0) as NrReviewuri
from Cazare  as h
inner join Orase as o
on o.OrasID = h.OrasID
left join RecenziiHoteluri as rep
on rep.CazareID = h.CazareID
inner join Camere as cam
on h.CazareID = cam.CazareID
WHERE o.Nume = @Oras and cam.NumarPaturi=@NumarPaturi
group by h.Nume,h.CazareID,Convert(varbinary(max),h.Poza)
order by NrReviewuri

