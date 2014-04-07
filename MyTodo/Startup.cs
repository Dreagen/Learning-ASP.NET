using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTodo.Startup))]
namespace MyTodo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
