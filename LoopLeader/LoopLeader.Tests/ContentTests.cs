using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopLeader.Domain.Concrete;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Tests
{
    [TestClass]
    public class ContentTests
    {
        [TestMethod]
        public void TestUpdateContent()
        {
            //Arrange
            FakeContentRepo repo = new FakeContentRepo();

            Content testContent1 = new Content();
            testContent1.ContentID = "Test1";
            testContent1.CurrentText = "This text was originally for TestContent1";

            Content testContent2 = new Content();
            testContent2.ContentID = "Test2";
            testContent2.CurrentText = "This text was originally for TestContent2";
            testContent2.NewText = testContent1.CurrentText;
            //Act
            repo.AddContent(testContent1);
            repo.AddContent(testContent2);
            testContent2.UpdateSection();
            //Assert
            Assert.AreSame(testContent1.CurrentText, testContent2.CurrentText);
        }
    }
}
