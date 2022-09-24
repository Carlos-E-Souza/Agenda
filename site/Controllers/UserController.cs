using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace site.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserModel> Listar()
        {
            var ctx = new ContextoAgenda();
            return ctx.Users.Select(user => user.toModel());
        }

        [HttpPost]
        public CreateUserRes save(CreateUserReq model)
        {
            var ctx = new ContextoAgenda();
            var user = new UserBL { Name = model.Name, Email = model.Email, Password = model.Password };
            ctx.Users.Add(user);
            ctx.SaveChanges();
            return new CreateUserRes { };
        }
        
    }

    public class CreateUserReq {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class CreateUserRes { }
}
