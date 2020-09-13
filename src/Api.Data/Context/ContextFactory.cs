using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context {
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext> {
        public MyContext CreateDbContext (string[] args) {
            //Usado para Criar as Migrações
            var connectionString = "Server=localhost;Port=3306;DataBase=db_API;Uid=root;Pwd=klcw987";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionsBuilder.UseMySql (connectionString);
            return new MyContext (optionsBuilder.Options);
        }
    }
}