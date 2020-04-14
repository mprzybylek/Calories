using System.ComponentModel.DataAnnotations.Schema;

namespace CaloriesPage.Database.Entities
{
    public class Meal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}