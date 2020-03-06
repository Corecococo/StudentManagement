using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 根据ID获取写生信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Student GetStudent(int Id);

        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudent();

        /// <summary>
        /// 添加一名学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Add(Student student);

        /// <summary>
        /// 更新一名学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Update(Student student);

        /// <summary>
        /// 删除一名学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Delete(int student);
    }
}
