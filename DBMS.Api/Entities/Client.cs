using System.Data;

namespace DBMS.Api.Entities
{
    public class Client : BaseEntity
    {
        public string? SecondName { get; set; }
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }

        public Client(DataRow row) : base(row)
        {
            SecondName = row["client_secondname"].ToString();
            FirstName = row["client_firstname"].ToString();
            ThirdName = row["client_thirdname"].ToString();
            Number = row["client_number"].ToString();
            Email = row["client_email"].ToString();
        }
    }
}
