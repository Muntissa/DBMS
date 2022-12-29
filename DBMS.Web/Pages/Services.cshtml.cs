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

        public void OnPostUpdate(int service_id, string name, string description, int price) 
        {
            Context.Update<Service>(service_id, name, description, price);
            Services = Context.LoadEntities<Service>();
        }

        public void OnPostDelete(int service_id)
        {
            Context.Delete<Service>(service_id);
            Services = Context.LoadEntities<Service>();

        }
        public void OnPostInsert(string name, string description, int price)
        {
            Context.Insert(new Service()
            {
                Name = name,
                Description = description,
                Price = price
            });
            Services = Context.LoadEntities<Service>();
        }
    }
}
