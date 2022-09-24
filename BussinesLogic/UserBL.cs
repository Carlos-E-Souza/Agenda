using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace BusinessLogic
{
    public class UserBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Email: {Email}, Senha: {Password}";
        }

        public UserModel toModel()
        {
            return new UserModel
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Password = Password
            };
        }

        public static IEnumerable<UserModel> getUsers(ContextoAgenda context)
        {
            return context.Users.Select(user => user.toModel());
        }

        public static UserModel CreateOrUpdate(UserModel model)
        {
            var context = new ContextoAgenda();
            UserBL usuario;
            if (model.Id == null)
            {
                usuario = new UserBL();
                context.Users.Add(usuario);
            }
            else
            {
                usuario = context.Users.Find(model.Id.Value);
            }
            context.SaveChanges();
            return usuario.toModel();
        }

        public static void Delete(int id, ContextoAgenda context)
        {
            var isso = context.Users.Remove(context.Users.Find(id));
        }

    }

    public class ContextoAgenda : DbContext
    {
        public DbSet<UserBL> Users { get; set; }

        public ContextoAgenda() { }
        public ContextoAgenda(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Agenda;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}