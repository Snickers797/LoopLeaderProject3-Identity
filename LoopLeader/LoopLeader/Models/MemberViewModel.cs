using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoopLeader.Models
{
    public class MemberViewModel
    {
        public int MemberID { get; set; }
        public List<LoopLeader.Domain.Entities.Member> MemberList { get; set; }
    }
}