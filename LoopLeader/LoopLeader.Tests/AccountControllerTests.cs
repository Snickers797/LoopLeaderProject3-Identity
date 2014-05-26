using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;
using System.Collections.Generic;
using System.Linq;
using LoopLeader.Controllers;
using LoopLeader.Models;
using System.Web.Mvc;
using LoopLeader.HtmlHelpers;

namespace LoopLeader.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void AddNewMemberTest()
        {
        //    //Arrange
        //    var members = new List<Member> {
        //    new Member {MemberId = 1, LoginName = "user1"},
        //    new Member {MemberId = 2, LoginName = "user2"},
        //    new Member {MemberId = 3, LoginName = "user3"}
        //    };

        //    var fakeMemberRepo = new FakeMemberRepository(members);
        //    var target = new AccountController(fakeMemberRepo);

        //    //Action
        //    //var result = ((IEnumerable<Member>)target.Members().ViewData.Model).ToArray();
        //    //Assert
        //    Assert.AreEqual(result.Length, 3);
        //    Assert.AreEqual("user1", result[0].LoginName);
        //    Assert.AreEqual("user2", result[1].LoginName);
        //    Assert.AreEqual("user3", result[2].LoginName);
        }
    }
}
