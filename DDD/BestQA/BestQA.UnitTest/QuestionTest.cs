using System;
using BestQA.Commands;
using ECommon.Utilities;
using ENode.Commanding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BestQA.UnitTest
{
    [TestClass]
    public class QuestionTest : TestBase
    {
        [TestMethod]
        public string CreateQuestionTest()
        {
            var newid = ObjectId.GenerateNewStringId();
            var result = ExecuteCommand(new CreateQuestionCmd("单元测试标题" + newid, "单元测试内容", 0, "unit", "admin") { AggregateRootId = newid });
            Assert.AreEqual(CommandStatus.Success, result.Status);
            return newid;
        }
        [TestMethod]
        public void VoteUp()
        {
            var newid = CreateQuestionTest();
            var result = ExecuteCommand(new QuestionVoteUpCmd(newid, "test"));
            Assert.IsTrue(result.Status == CommandStatus.Success);
            result = ExecuteCommand(new QuestionVoteUpCmd(newid, "admin"));
            Assert.IsTrue(result.Status == CommandStatus.Failed);
            Console.WriteLine(result.ErrorMessage);
        }

        [TestMethod]
        public void VoteDown()
        {
            var newid = CreateQuestionTest();
            var result = ExecuteCommand(new QuestionVoteDownCmd(newid, "test"));
            Assert.IsTrue(result.Status == CommandStatus.Success);
            result = ExecuteCommand(new QuestionVoteDownCmd(newid, "admin"));
            Assert.IsTrue(result.Status == CommandStatus.Failed);
            Console.WriteLine(result.ErrorMessage);
        }
    }
}
