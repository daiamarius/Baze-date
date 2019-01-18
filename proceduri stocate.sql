use TripAdvisor
-- list restaurante
go
CREATE PROCEDURE getRestaurants @Oras nvarchar(50)
AS
select r.RestaurantID,r.Nume,r.Adresa,Convert(varbinary(max),r.Poza) as Poza,
		ISNULL(AVG(Cast(rep.Stele as Float)),0) as UserReview,
		ISNULL(AVG(Cast(rep.Pret as Float)),0) as UserPricing,
		ISNULL(COUNT(rep.RestaurantID),0) as NrReviewuri
from Restaurante as r
inner join Orase as o
on o.OrasID = r.OrasID
left join RecenziiRestaurante as rep
on rep.RestaurantID = r.RestaurantID
WHERE o.Nume = @Oras
group by r.Nume,r.Adresa,r.RestaurantID,Convert(varbinary(max),r.Poza)
order by NrReviewuri

--foto restaurante
go
CREATE PROCEDURE getRestaurantPhotos @restaurantID int
AS
select u.Nume,u.Prenume,p.Poza,p.Data
from PozeRestaurante as p
inner join Utilizatori as u
on u.UserID=p.UserID
where p.RestaurantID=@restaurantID
order by p.Data desc

--top3 restaurante by reviews
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
group by r.Nume,r.Adresa,r.RestaurantID,Convert(varbinary(max),r.Poza)
order by UserReview desc