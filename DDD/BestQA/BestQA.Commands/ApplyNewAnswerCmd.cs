using System;
using ENode.Commanding;

namespace BestQA.Commands
{
    [Serializable]
    public class ApplyNewAnswerCmd :Command<string>
    {
        public string AnswerId { get; set; }

        private ApplyNewAnswerCmd() { }

        public ApplyNewAnswerCmd(string aggregateRootId, string answerId):base(aggregateRootId)
        {
            AnswerId = answerId;
        }
    }
}
