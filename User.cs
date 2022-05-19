using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFCore2DBFirst
{
    [Index("Name", Name = "User_name_index", IsUnique = false)]
    public partial class User
    {
        public long Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [Required] //analog of modelBuilder.Entity<User>().Property(b => b.Age).IsRequired(); in fluent-API
        public long Age { get; set; }

        public string? Position { get; set; }   // Новое свойство - должность пользователя

        public bool IsMarried { get; set; }

        // навигационное свойство
        // it's possible to use [ForeignKey("CompanyId")] here to explicit set a foreign key
        // or in fluent API it can be 
        // modelBuilder.Entity<User>().HasOne(u => u.Company).WithMany(c => c.Users).OnDelete(DeleteBehavior.Cascade).HasForeignKey(u => u.CompanyId);
        public Company? Company { get; set; }

        //external key
        public int? CompanyId { get; set; }

        public string SomePrtyThatShouldBeIgnored { get; set; } //ignored via fluent API

        [NotMapped]
        public string SomePrtyThatShouldBeIgnored2 { get; set; } //ignored via annotation

        private string? lastName; //it's possible to use not only auto-properties

        public string? LastName
        {
	        get => lastName;
	        set => lastName = value;
        }
    }
}
