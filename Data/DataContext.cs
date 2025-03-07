using System.Security.Cryptography.X509Certificates;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

/* ctor con todas las opciones*/
public class DataContext(DbContextOptions options) : DbContext(options) { 
    public DbSet<AppUser> Users {get;set;}
}