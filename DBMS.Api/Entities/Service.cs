using System.Data;

namespace DBMS.Api.Entities
{
    public class Service : BaseEntity
    {
        [EntityPropertyDesc("service_name")]
        public string? Name { get; set; }

        [EntityPropertyDesc("service_description")]
        public string? Description { get; set; }

        [EntityPropertyDesc("service_price")]
        public int? Price { get; set; }

        public Service(DataRow row) : base(row) 
        {
            Name = row["service_name"].ToString();
            Description = row["service_description"].ToString();
            Price = Convert.ToInt32(row["service_price"]);
        }

        public Service() { }
    }
}
