using Backend.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence.Configuration
{
    public class PersonConfiguration
    {
        public PersonConfiguration(EntityTypeBuilder<PersonEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.firstName).IsRequired();
            entityBuilder.Property(x => x.lastName).IsRequired();
            entityBuilder.Property(x => x.userName).IsRequired();
            entityBuilder.Property(x => x.birthday).IsRequired();
            entityBuilder.Property(x => x.email).IsRequired();
            entityBuilder.Property(x => x.phoneNumber).IsRequired();

        }
    }
}
