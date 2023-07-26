using ipcsmembros.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ipcsmembros.Contexts
{
    public class MembroContext : DbContext
    {
        public DbSet<Membro> Membros => Set<Membro>();
    }
}