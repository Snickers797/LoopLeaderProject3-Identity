using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopLeader.Domain.Concrete;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Tests
{
    [TestClass]
    public class ContentRepoTests
    {
        [TestMethod]
        public void TestAddContent()
        {
            //Arrange

            FakeContentRepo repo = new FakeContentRepo();
            Content testContent = new Content();
            testContent.ContentID = "Test";
            testContent.CurrentText = "This is a test statement.";
            //Act
            repo.AddContent(testContent);
            //Assert
            Content contentInRepo = repo.GetContent("Test");
            Assert.AreSame(contentInRepo.ContentID, testContent.ContentID);
            Assert.AreSame(contentInRepo.CurrentText, testContent.CurrentText);
        }

        
        [TestMethod]
        public void TestGetContent()
        {
            //Arrange
            FakeContentRepo repo = new FakeContentRepo();
            Content testContent = new Content();
            testContent.ContentID = "Test";
            testContent.CurrentText = "This is a test statement.";
            //Act
            repo.AddContent(testContent);
            //Arrange
            Assert.AreSame(testContent.ContentID, repo.GetContent(testContent.ContentID).ContentID);
            Assert.AreSame(testContent.CurrentText, repo.GetContent(testContent.ContentID).CurrentText);

        }
    }
}
