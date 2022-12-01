using System.Data;

namespace DBMS.Api.Entities
{
    public class Tariff : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Tariff(DataRow row) : base(row)
        {
            Name = row["tariff_name"].ToString();
            Description = row["tariff_description"].ToString();
            Price = Convert.ToInt32(row["tariff_price"]);
        }
    }
}