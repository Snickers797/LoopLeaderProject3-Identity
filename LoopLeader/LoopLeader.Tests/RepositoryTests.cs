using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;

namespace LoopLeader.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void AddMemberTest()
        {
            //Arrange
            var repo = new FakeMemberRepository();
            var member1 = new Member();
            var member2 = new Member();
            //ACT
            repo.AddMember(member1);
            repo.AddMember(member2);
            //Assert
            Assert.AreSame(member1, repo.Members[0]);
            Assert.AreSame(member2, repo.Members[1]);
            Assert.AreEqual(member1, repo.Members[0]);
            Assert.AreEqual(member2, repo.Members[1]);
            Assert.AreNotEqual(member1, repo.Members[1]);
            Assert.AreNotEqual(member2, repo.Members[0]);
        }
        [TestMethod]
        public void GetMemberByLoginTest()
        {
            //Arrange
            var repo = new FakeMemberRepository();
            var member1 = new Member() { UserName = "Spooky", PasswordHash = "password", FirstName = "Fox", LastName = "Mulder", Email = "fmulder@xfiles.com" };
            repo.AddMember(member1);
            var member2 = new Member() { UserName = "Superman", PasswordHash = "password", FirstName = "Clark", LastName = "Kent", Email = "ck@dailyplanet.com" };
            repo.AddMember(member2);
            //Act
            repo.GetMemberbyLoginName("Superman");
            repo.GetMemberbyLoginName("Spooky");
            //Assert
            Assert.AreSame(member1, repo.Members[0]);
            Assert.AreSame(member2, repo.Members[1]);
            Assert.AreEqual(member1, repo.Members[0]);
            Assert.AreEqual(member2, repo.Members[1]);
            Assert.AreNotEqual(member1, repo.Members[1]);
            Assert.AreNotEqual(member2, repo.Members[0]);
        }
    }
}
