using System;

namespace BestQA.QueryService.DTOs
{
    public partial class AnswerDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Id { get; set; }
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
        /// Gets or sets the answer automatic.
        /// </summary>
        public string AnswerTo { get; set; }
        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets the user unique identifier.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public int State { get; set; }
    }
}
