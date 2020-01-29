using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RRHHContextInitializer: CreateDatabaseIfNotExists<RRHHContext>
    {
        protected override void Seed(RRHHContext context)
        {
            base.Seed(context);
        }
    }
}
