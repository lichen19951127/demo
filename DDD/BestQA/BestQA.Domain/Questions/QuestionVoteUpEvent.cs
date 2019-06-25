using System;
using ENode.Eventing;

namespace BestQA.Domain.Questions
{
    [Serializable]
    public class QuestionVoteUpEvent :DomainEvent<string>
    {
        public string PostId { get; set; }
        private QuestionVoteUpEvent() { }

        public QuestionVoteUpEvent(Question question, string postid) :base(question)
        {
            PostId = postid;
        }

    }
}
