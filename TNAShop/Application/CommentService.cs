using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Infrastructure;

namespace TNAShop.Application {
    public class CommentService {
        public void AddComment(Comment cm) {
            new Comment(new GenericRepository<Comment>(new ApplicationDbContext())).AddComment(cm);
        }
    }
}