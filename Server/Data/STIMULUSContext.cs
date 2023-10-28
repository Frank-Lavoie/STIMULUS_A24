using Microsoft.EntityFrameworkCore;

namespace STIMULUS_V2.Server.Data
{
    public class STIMULUSContext : DbContext
    {
        public STIMULUSContext(DbContextOptions<STIMULUSContext> options) : base(options)
        {

        }
    }
}
