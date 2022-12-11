using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUBDCOURSE.Pages
{
    public class ClientsModel : PageModel
    {
        private readonly ILogger<ClientsModel> _logger;

        public ClientsModel(ILogger<ClientsModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Client> Clients = Context.LoadEntities<Client>();

        public void OnPostDelete(int client_id)
        {
            Context.Delete<Client>(client_id);
            Clients = Context.LoadEntities<Client>();
        }
        public void OnPostInsert(string secondname, string firstname, string thirdname, string number, string email)
        {
            Context.Insert(new Client()
            {
                SecondName = secondname,
                FirstName = firstname,
                ThirdName = thirdname,
                Number = number,
                Email = email
            });
            Clients = Context.LoadEntities<Client>();
        }
    }
}
