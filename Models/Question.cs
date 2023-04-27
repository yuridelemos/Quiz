
using Dapper.Contrib.Extensions;

namespace Quiz.Models
{
    [Table("[Question]")]
    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Body { get; set; }

    }
}