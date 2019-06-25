using System;
using System.Collections.Generic;
using BestQA.Metadata;

namespace BestQA.QueryService.DTOs
{
    public partial class QuestionDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the support count.
        /// </summary>
        public int SupportCnt { get; set; }
        /// <summary>
        /// Gets or sets the oppose count.
        /// </summary>
        public int OpposeCnt { get; set; }
        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        public int Reward { get; set; }
        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public QuestionState  State { get; set; }
        /// <summary>
        /// Gets or sets the user unique identifier.
        /// </summary>
        public string UserId { get; set; }

        public IEnumerable<AnswerDTO> Answers { get; set; } 

        public string GetStateText()
        {
            return State.ToString();
        }
    }

}
