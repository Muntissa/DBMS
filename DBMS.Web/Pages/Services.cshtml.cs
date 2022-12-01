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

        public void OnGet()
        {
        }
    }
}
