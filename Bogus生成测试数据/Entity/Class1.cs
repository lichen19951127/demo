using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public List Tags { get; set; }

        public BlogPost()
        {
            Tags = new List();
        }
    }
}
