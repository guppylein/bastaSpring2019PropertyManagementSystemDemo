SELECT r.Id, r.HotelId, r.Number, h.Name, rt.Capacity
FROM Hotels h 
  INNER JOIN Rooms r ON h.Id = r.HotelId
  INNER JOIN RoomTypes rt ON r.RoomtypeId = rt.Id
  LEFT OUTER JOIN Reservations rv ON rv.RoomId = r.Id
WHERE r.State = 0 
  AND (rv.DateFrom IS NULL OR (rv.DateFrom >= '2019-02-27' AND rv.DateTo <= '2019-02-28'))
  AND rt.Capacity = 2