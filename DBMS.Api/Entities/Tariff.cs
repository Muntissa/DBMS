using System.Data;

namespace DBMS.Api.Entities
{
    public class Tariff : BaseEntity
    {
        [EntityPropertyDesc("tariff_name")]
        public string? Name { get; set; }

        [EntityPropertyDesc("tariff_description")]
        public string? Description { get; set; }

        [EntityPropertyDesc("tariff_price")]
        public int? Price { get; set; }

        public Tariff(DataRow row) : base(row)
        {
            Name = row["tariff_name"].ToString();
            Description = row["tariff_description"].ToString();
            Price = Convert.ToInt32(row["tariff_price"]);
        }

        public Tariff() { }
    }
}