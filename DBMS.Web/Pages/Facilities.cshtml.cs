using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUBDCOURSE.Pages
{
    public class FacilitiesModel : PageModel
    {
        private readonly ILogger<FacilitiesModel> _logger;

        public FacilitiesModel(ILogger<FacilitiesModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Facility> Facilities = Context.LoadEntities<Facility>();

        public void OnGet()
        {
        }

        public void OnPostDelete(int id) 
        {
            Context.Delete<Facility>(id);
        }
        public void OnPostInsert(string name)
        {
            var facility = new Facility() { Name = name };
            Context.Insert(facility);
        }
    }
}
