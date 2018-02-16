using Microsoft.EntityFrameworkCore;

namespace Lethia.Models
{
    public class MessageRequestContext : DbContext
    {
        public MessageRequestContext(DbContextOptions<MessageRequestContext> options)
            : base(options)
        {
        }

        public DbSet<MessageRequest> MessageRequests { get; set; }

    }
}