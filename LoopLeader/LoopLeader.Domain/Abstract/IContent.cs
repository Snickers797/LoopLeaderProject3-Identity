using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Abstract
{
    public interface IContent
    {
        void AddContent(Content content);
        Content GetContent(string contentID);
        void SaveContent(Content content);
    }
}
