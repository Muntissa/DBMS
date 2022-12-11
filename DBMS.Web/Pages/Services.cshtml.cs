using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBMS.Api.Entities;
using DBMS.Api;

namespace SUBDCOURSE.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly ILogger<ServicesModel> _logger;

        public ServicesModel(ILogger<ServicesModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Service> Services = Context.LoadEntities<Service>();

        public void OnPostUpdate(int id, string name, string description, int price) 
        {
            Context.Update<Service>(id, name, description, price);
        }

        public void OnPostDelete(int id)
        {
            Context.Delete<Service>(id);
        }
        public void OnPostInsert(string name, string description, int price)
        {
            Context.Insert(new Service()
            {
                Name = name,
                Description = description,
                Price = price
            });
        }
    }
}
