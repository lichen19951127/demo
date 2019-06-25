using System;
using System.Runtime.Serialization;
using BestQA.QueryService.DTOs;
using BestQA.Repository;
using ECommon.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BestQA.UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void CreateQeustion()
        {
            var repository = new QuestionRepository();
            string id = ObjectId.GenerateNewStringId();
            QuestionDTO dto = new QuestionDTO
            {
                Title = "ddd",
                Content = "ddd content",
                CreatedTime = DateTime.Now,
                Id = id,
                UserId = "admin"
            };
            repository.CreateQuestion(dto);

            var query = new QuestionQuery();
            var newdto = query.Find(id);
            Assert.AreEqual(dto.Title, newdto.Title);
        }
    }
}
