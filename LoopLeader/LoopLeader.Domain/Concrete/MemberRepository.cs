using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Concrete
{
    public class MemberRepository : IMember
    {
        // Add new Member to database
        public void AddMember(Member member)
        {
            var db = new LLDbContext();
            db.Members.Add(member);
            db.SaveChanges();
        }

        // Generically returns all Members in database
        public IQueryable<Member> GetMembers
        {
            get
            {
                var db = new LLDbContext();
                return db.Members;
            }
        }

        // Returns a singe member by Login name
        public Member GetMemberbyLoginName(string loginName)
        {
            var db = new LLDbContext();
            return (db.Members.First(m => m.UserName == loginName));
        }

        // Saves member information to database
        public void SaveMember(Member member)
        {
            var db = new LLDbContext();
            if (member.Id == 0)
            {
                db.Members.Add(member);
            }
            else
            {
                // If member exists, it updates information
                Member dbEntry = db.Members.Find(member.Id);
                if (dbEntry != null)
                {
                    dbEntry.UserName = member.UserName;
                    dbEntry.PasswordHash = member.PasswordHash;
                    dbEntry.FirstName = member.FirstName;
                    dbEntry.LastName = member.LastName;
                    dbEntry.Email = member.Email;
                }
            }
            db.SaveChanges();
        }

        // Deletes member from database
        public Member DeleteMember(int memberId)
        {
            var db = new LLDbContext();
            Member dbEntry = db.Members.Find(memberId);
            if (dbEntry != null)
            {
                db.Members.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }

        public Member GetMemberbyLoginNameAndPassword(Member member)
        {
            var db = new LLDbContext();
            return db.Members.Where(m => m.UserName == member.UserName & m.PasswordHash == member.PasswordHash).FirstOrDefault();
        }
    }
}
