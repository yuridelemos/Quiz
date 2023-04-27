
using Dapper.Contrib.Extensions;

namespace Quiz.Models
{
    [Table("[Answer]")]
    public class Answer
    {
        public int QuestionId { get; set; }
        public int AnswerOrder { get; set; }
        public string Body { get; set; }
        public bool RightAnswer { get; set; }
    }
}