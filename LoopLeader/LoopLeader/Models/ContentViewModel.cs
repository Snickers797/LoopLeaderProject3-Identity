using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoopLeader.Models
{
    public class ContentViewModel
    {
        public string ContentID { get; set; }
        public List<LoopLeader.Domain.Entities.Content> ContentList { get; set; }
    }
}