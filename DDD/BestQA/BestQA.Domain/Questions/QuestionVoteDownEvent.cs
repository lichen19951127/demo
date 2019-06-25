using System;
using ENode.Eventing;

namespace BestQA.Domain.Questions
{
    [Serializable]
    public class QuestionVoteDownEvent :DomainEvent<string>
    {
        public string PostId { get; set; }
        private QuestionVoteDownEvent() { }

        public QuestionVoteDownEvent(Question question, string postid)
            : base(question)
        {
            PostId = postid;
        }

    }
}
