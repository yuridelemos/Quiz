
using Dapper.Contrib.Extensions;

namespace Quiz.Models
{
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Matter { get; set; }
    }
}