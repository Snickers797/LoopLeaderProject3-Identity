using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Concrete
{
    public class FakeMemberRepository : IMember
    {
        List<Member> members = new List<Member>();
        public List<Member> Members { get { return members; } }

        public FakeMemberRepository() { }
        public FakeMemberRepository(List<Member> memberList)
        {
            this.members = memberList;
        }
        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public IQueryable<Member> GetMembers
        {
            get{return members.AsQueryable(); }
        }

        public Member GetMemberbyLoginName(string loginName)
        {
            return members.First(m => m.UserName ==  loginName);
        }

        public void SaveMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member DeleteMember(int memberId)
        {
            throw new NotImplementedException();
        }


        public Member GetMemberbyLoginNameAndPassword(Member member)
        {
            return members.Where(m => m.UserName == member.UserName & m.PasswordHash == member.PasswordHash).FirstOrDefault();
        }
    }
}
