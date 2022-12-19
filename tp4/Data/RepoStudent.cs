using System.Linq.Expressions;
using tp4.Models;

namespace tp4.Data
{
    public interface IRepoStudent<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<string> GetCourses();

        IEnumerable<TEntity> GetStudentsPerCourse(string course);
    }
    public class RepoStudent : IRepoStudent<Student>
    {
        private readonly UniversityContext universityContext;
        public RepoStudent(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        public Student Get(int id)
        {
            try
            {
                return universityContext.Set<Student>().Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Student> GetAll()
        {
            try
            {
                return universityContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return universityContext.Set<Student>().Where(predicate);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Add(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Add(entity);
                universityContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool AddRange(IEnumerable<Student> entities)
        {
            try
            {
                universityContext.Set<Student>().AddRange(entities);
                universityContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Remove(Student entity)
        {
            try
            {
                universityContext.Set<Student>().Remove(entity);
                universityContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool RemoveRange(IEnumerable<Student> entities)
        {
            try
            {
                universityContext.Set<Student>().RemoveRange(entities);
                universityContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<string> GetCourses()
        {
            try
            {
                return universityContext.Student.Select(s => s.course).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Student> GetStudentsPerCourse(string course)
        {
            try
            {
                return universityContext.Student.Where(s => s.course.Trim().ToLower() == course.Trim().ToLower());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
