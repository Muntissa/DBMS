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

        public void OnPostDelete(string facility_id)
        {
            Context.Delete<Facility>(Facilities.Where(facility => facility.Name.Trim() == facility_id).Select(facility => facility.Id).First());
            Facilities = Context.LoadEntities<Facility>();
        }

        public void OnPostInsert(string name)
        {
            Context.Insert(new Facility() { Name = name });
            Facilities = Context.LoadEntities<Facility>();
        }
    }
}
