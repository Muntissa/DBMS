using System.Data;

namespace DBMS.Api.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Service(DataRow row) : base(row) 
        {
            Name = row["service_name"].ToString();
            Description = row["service_description"].ToString();
            Price = Convert.ToInt32(row["service_price"]);
        }
    }
}
