using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyTodo.Models {

    public class TodoDbContext : DbContext {
        public DbSet<Todo> Todos { get; set; }
    }
}