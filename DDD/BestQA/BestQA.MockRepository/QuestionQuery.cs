using System.Collections.Generic;
using System.Linq;
using BestQA.QueryService;
using BestQA.QueryService.DTOs;
using BestQA.Repository.Models;
using ECommon.Components;

namespace BestQA.Repository
{
    [Component]
    public class QuestionQuery : IQuestionQuery
    {
        public QuestionDTO Find(string id)
        {
            using (var context = new BestQAContext())
            {
                var question = context.Questions.FirstOrDefault(e => e.Id == id);
                if (question != null)
                {
                    question.Answers = context.Answers.Where(e => e.AnswerTo == id).ToList();
                }
                return question;
            }
        }

        public IEnumerable<QuestionDTO> FindAll()
        {
            using (var context = new BestQAContext())
            {
                return context.Questions.ToArray();
            }
        }
    }
}
