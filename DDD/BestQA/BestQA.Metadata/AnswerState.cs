using System;

namespace BestQA.Domain.Answers
{
    [Serializable]
    public enum AnswerState
    {
        Best,        //最佳回答
        Accepted,    //已接受
        Recommended  //推荐回答
    }
}