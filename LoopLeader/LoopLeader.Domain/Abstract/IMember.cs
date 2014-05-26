using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Abstract
{
    public interface IMember
    {
        void AddMember(Member user);
        IQueryable<Member> GetMembers { get; }
        Member GetMemberbyLoginName(string loginName);
        void SaveMember(Member member);
        Member DeleteMember(int memberId);
        Member GetMemberbyLoginNameAndPassword(Member member);
    }
}
