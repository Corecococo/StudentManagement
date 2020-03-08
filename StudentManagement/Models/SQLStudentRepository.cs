using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLStudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Student Add(Student student)
        {
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _appDbContext.Students.Find(id);
            if(student != null)
            {
                _appDbContext.Students.Remove(student);
                _appDbContext.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _appDbContext.Students;
        }

        public Student GetStudent(int Id)
        {
            return _appDbContext.Students.Find(Id);
        }

        public Student Update(Student student)
        {
            var upStudent = _appDbContext.Students.Attach(student);
            upStudent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return student;
        }
    }
}
