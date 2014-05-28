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
        public IEnumerable<ApplicationUser> Members { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}