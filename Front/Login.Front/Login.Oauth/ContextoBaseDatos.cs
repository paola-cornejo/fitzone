using Login.Oauth.Areas.Socio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Login.Oauth
{
    public class ContextoBaseDatos : DbContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection DbConnection { get; }

        public DbSet<Socio> socio { get; set; }

        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options, IConfiguration configuration)
           : base(options)
        {
            this._configuration = configuration;
            DbConnection = new SqlConnection(this._configuration.GetConnectionString("FitZoneContextConnection"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection.ToString());
            }
        }


    }
}
