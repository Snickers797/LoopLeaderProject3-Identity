using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;

namespace LoopLeader.Domain.Concrete
{
    public class FakeContentRepo : IContent
    {
        List<Content> Content = new List<Content>();

        public void AddContent(Content content)
        {
            Content.Add(content);
        }

        public Content GetContent(string contentID)
        {
            Content selectedContent = (from content in Content
                                       where contentID == content.ContentID
                                       select content).FirstOrDefault<Content>();
            return selectedContent;
        }


        public void SaveContent(Content content)
        {
            //Find the content at the specified index and then update it to have the new
            //value passed in the parameter above.
            int index = Content.IndexOf(content);
            Content[index].CurrentText = content.NewText;
        }

        public void SaveContent(Content content, FakeContentRepo repo)
        {
            Content = repo.Content;
            Content.Add(content);
            //int index = Content.IndexOf(content);

            //Find the content at the specified index and then update it to have the new
            //value passed in the parameter above.


            // JUST FOR TESTING.  INDEX IS HARD-CODED.
            Content[0].CurrentText = content.NewText;
        }
    }
}
