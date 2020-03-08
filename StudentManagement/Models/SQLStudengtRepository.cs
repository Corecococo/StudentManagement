using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class SQLStudengtRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;
        public SQLStudengtRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public Student Add(Student student)
        {
            appDbContext.Students.Add(student);
            appDbContext.SaveChanges();
            return student;
        }

        public Student Delete(int student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int Id)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
