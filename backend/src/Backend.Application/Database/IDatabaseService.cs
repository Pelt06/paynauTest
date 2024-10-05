using Backend.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database
{
    public interface IDatabaseService
    {
        DbSet<PersonEntity> Person { get; set; }

        Task<bool> SaveAsync();
    }
}
