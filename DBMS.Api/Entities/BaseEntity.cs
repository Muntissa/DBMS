using System.Data;

namespace DBMS.Api.Entities
{
    public class BaseEntity
    {
        [EntityPropertyDesc("Id", true)]
        public int Id { get; set; }
        
        public BaseEntity(DataRow row)
        {
            Id = Convert.ToInt32(row["id"]);
        }

        public BaseEntity()
		{

		}
    }
}