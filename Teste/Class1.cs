using BusinessLogic;

Console.WriteLine("Hello, World!");


var ctx = new ContextoAgenda();

/*foreach (var usuario in User.getUsers(ctx))
{
    usuario.Password = "999999";
    Usuario.CreateOrUpdate(usuario);
}*/
for(int i = 0; i < 10; i++)
{
    UserBL.CreateOrUpdate(new ViewModel.UserModel
    {
        Name = "NomeTeste"+i,
        Email = "EmailTeste"+i,
        Password = "Senha"+i,
    });
}

UserBL.Delete(1, ctx);