using System.Reflection;

namespace PetStore.Model
{
    public class ProductEntity
    {


        public long id {  get; set; }
        public string Brand { get; set; }    
        public string Title {  get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; }= DateTime.Now;

    }
}
