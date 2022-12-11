using DBMS.Api;
using DBMS.Api.Entities;

var bs = new BookingServices { BookingId = 1, ServiceId = 1 };
var sql = Context.GetSqlInsertCommand(bs);
Console.Write(sql);
Console.ReadLine();