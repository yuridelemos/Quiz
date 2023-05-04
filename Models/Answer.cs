
using Dapper.Contrib.Extensions;

namespace Quiz.Models
{
    [Table("[Answer]")]
    public class Answer
    {
        [Key]
        public int QuestionId { get; set; }
        public int AnswerOrder { get; set; }
        public string Body { get; set; }
        public bool RightAnswer { get; set; }

        [Computed]
        public int Id => (QuestionId << 16) | AnswerOrder;
        /* usada representar uma chave composta. Combina as duas propriedades em um valor 
        inteiro único permitindo que ele seja usado como uma chave primária */
    }
}