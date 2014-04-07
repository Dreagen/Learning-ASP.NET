using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyTodo.Models {
    public class Todo {
        public int ID { get; set; }
        public bool Completed { get; set; }
        public string Message { get; set; }
    }

    public class TodoDbContext : DbContext {
        public DbSet<Todo> Todos { get; set; }
    }
}