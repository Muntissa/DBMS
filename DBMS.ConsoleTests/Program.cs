using DBMS.Api;
using DBMS.Api.Entities;

var Services = Context.LoadEntities<Service>();
var serviceToCompare = "Просто уборка | Цена: 1300 руб.";

var service = Convert.ToInt32(Services.Where(service => service.Name.Trim() == serviceToCompare.Substring(0, serviceToCompare.IndexOf(" | "))).Select(service => service.Id).First());


Console.WriteLine(service);