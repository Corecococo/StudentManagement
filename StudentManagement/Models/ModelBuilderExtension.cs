using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modebuilder)
        {
            modebuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Lion",
                    ClassName = ClassNameEnum.一年级,
                    Email = "1545982514.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "Yoke",
                    ClassName = ClassNameEnum.二年级,
                    Email = "2551300379.com"
                });
            
        }
    }
}
