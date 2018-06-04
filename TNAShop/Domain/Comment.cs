using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class Comment {
        IGenericRepository<Comment> repos;
        public Comment() {
            AddedDate = DateTime.Now;
        }

        [Key]
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Email { set; get; }
        public string Content { set; get; }
        public DateTime AddedDate{set;get;}
        public Product Product { set; get; }
        
        public Comment(IGenericRepository<Comment> repos) {
            this.repos = repos;
        }

        public void AddComment(Comment cm) {
            repos.Insert(cm);
            repos.Save();
        }
    }
}