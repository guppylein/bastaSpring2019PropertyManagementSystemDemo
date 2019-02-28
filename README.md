# bastaSprint2019PropertyManagementSystemDemo

First steps with azure functions on basta2019 in Frankfurt.

Lab: "Hands-on mit .NET Core - Architekturen für den praktischen Einsatz" with Robin Sedlaczek.

The aim was to build a plattform-independent "Property management system" for hotels.

My team was responsible to build a service for the inventary (hotels, rooms, roomtypes, capacity of rooms and the status of the room).
We implemented the following two azure functions:
- GetHotels: returns a list of hotels (https://basta2019functions.azurewebsites.net/api/GetHotels)
- GetAvailableRooms: returns a list of room-viewmodels for all available rooms with the given capacity in the asked date-range (https://basta2019functions.azurewebsites.net/api/GetAvailableRooms/2019-02-27/2019-02-28/1)

This example is just a simple showcase how to use azure functions in conjunction with an azure sqlserver-database.
