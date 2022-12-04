using System.Data;

namespace DBMS.Api.Entities
{
    public class Client : BaseEntity
    {
        [EntityPropertyDesc("client_secondname")]
        public string? SecondName { get; set; }

        [EntityPropertyDesc("client_firstname")]
        public string? FirstName { get; set; }

        [EntityPropertyDesc("client_thirdname")]
        public string? ThirdName { get; set; }

        [EntityPropertyDesc("client_number")]
        public string? Number { get; set; }

        [EntityPropertyDesc("client_email")]
        public string? Email { get; set; }

        public Client(DataRow row) : base(row)
        {
            SecondName = row["client_secondname"].ToString();
            FirstName = row["client_firstname"].ToString();
            ThirdName = row["client_thirdname"].ToString();
            Number = row["client_number"].ToString();
            Email = row["client_email"].ToString();
        }

        public Client() { }
    }
}
