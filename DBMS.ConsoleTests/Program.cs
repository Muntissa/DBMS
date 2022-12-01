using DBMS.Api;
using DBMS.Api.Entities;

var a = new Apartament() { Id = 10, Area = 1, Number = 13, Price = 1231 };
var sql = Context.GetSqlInsertCommand(a);

Console.WriteLine(sql);
Console.ReadLine();