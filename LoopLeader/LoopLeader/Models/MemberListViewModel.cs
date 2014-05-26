using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Models
{
    public class MemberListViewModel
    {
        public string Id { get; set; }
        public List<LoopLeader.Models.ApplicationUser> MemberList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}