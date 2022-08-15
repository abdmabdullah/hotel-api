# Hotel Management Backend

This Web API is a collection of endpoints that support some basic functionalities of a Hotel Booking Service.

## Stack:
This backend is written in .NET 6 with PostgreSQL 14. For text based search, I used the full text based search feature that comes with NpgSQL (using indexing and search vectors). It is lightweight, dependable, fast and scalable.

## Endpoints
The following endpoints are implemented and can be consumed:
### Hotels
* SearchHotels
* GetHotel
* GetHotels
* AddHotel
* UpdateHotel
* Delete Hotel
### Bookings
* AddBooking

All above mentioned endpoints are implemented with validations, proper exception handling and appropriate response handling. A custom response Model is used. Moreover, everything is abstracted and loosely coupled, so any changes or increase in complexity can be implemented with none to minimal refactoring.
