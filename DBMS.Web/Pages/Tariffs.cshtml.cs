using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBMS.Api.Entities;
using DBMS.Api;

namespace SUBDCOURSE.Pages
{
    public class TariffsModel : PageModel
    {
        private readonly ILogger<TariffsModel> _logger;

        public TariffsModel(ILogger<TariffsModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Tariff> Tariffs = Context.LoadEntities<Tariff>();

        public void OnPostInsert(string name, string description, int price)
        {
            Context.Insert(new Tariff()
            {
                Name = name,
                Description = description,
                Price = price
            });
        }

        public void OnPostDelete(int id)
        {
            Context.Delete<Client>(id);
        }
    }
}
