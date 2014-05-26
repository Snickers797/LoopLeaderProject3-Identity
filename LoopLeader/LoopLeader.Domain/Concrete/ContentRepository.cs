using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Concrete
{
    public class ContentRepository : IContent
    {
        public IQueryable<Content> Content
        {
            get
            {
                LLDbContext contentDB = new LLDbContext();
                return contentDB.Content;
            }
        }

        //Method to add content to the database.
        public void AddContent(Content contentToBeAdded)
        {
            LLDbContext contentDB = new LLDbContext();
            contentDB.Content.Add(contentToBeAdded);
            contentDB.SaveChanges();
        }

        //Method to retrieve a specific section of content via its ContentID.  ContentID may be switched from string to integer later.
        public Content GetContent(string contentID)
        {
            LLDbContext contentDB = new LLDbContext();

            Content selectedContent = (from content in contentDB.Content
                                       where contentID == content.ContentID
                                       select content).FirstOrDefault<Content>();
            return selectedContent;
        }


        //To be used in conjunction with the UpdateSection method of the Content class.
        //This will take the content object passed in, attempt to find it in the database, and then update the information in the database.
        public void SaveContent(Content content)
        {
            LLDbContext contentDB = new LLDbContext();

            //Find the content in the DB:
            Content contentToUpdate = contentDB.Content.Find(content.ContentID);
            if (contentToUpdate != null)
            {
                //Edit its existing content to reflect the changes.
                //Take the entry in the database and make it have the new (updated) text from the object passed in as a parameter.
                contentToUpdate.CurrentText = content.NewText;
            }

            contentDB.SaveChanges();

        }

    }
}
