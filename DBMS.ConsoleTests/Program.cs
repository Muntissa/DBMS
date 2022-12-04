using DBMS.Api;
using DBMS.Api.Entities;

var a = new Booking() { ApartamentId = 1, ClientId = 1,FirstDate = Convert.ToDateTime("12.01.2022"), EndDate = Convert.ToDateTime("17.01.2022"), SumPrice = 0, Reservation = true };
var sql = Context.GetSqlInsertCommand(a);

Console.WriteLine(sql);
Console.ReadLine();