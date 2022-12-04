using System.Data;

namespace DBMS.Api.Entities
{
    public class Facility : BaseEntity
    {
        [EntityPropertyDesc("facilities_name")]
        public string? Name { get; set; }
        public Facility(DataRow row) : base(row) 
        {
            Name = row["facilities_name"].ToString();
        }

        public Facility() { }
    }
}
