using Microsoft.EntityFrameworkCore;
using RpgGameApi.Models;

namespace RpgGameApi.Data
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> opt) : base(opt)
        {

        }

        public DbSet<Character> Characters { get; set; }
    }
}