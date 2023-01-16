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

        public void OnPostDelete(string client_id)
        {
            var clientSplit = client_id.Split(" ");
            Context.Delete<Client>(Convert.ToInt32(Clients.Where(client => client.SecondName.Trim() == clientSplit[0] && client.FirstName.Trim() == clientSplit[1] && client.ThirdName.Trim() == clientSplit[2]).Select(client => client.Id).First()));
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
