using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly dbContext _context;       

        public StudentRepository(dbContext context)
        {
            _context = context;           
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var result = _context.Students.FirstOrDefault(x => x.StudentId == studentId);
            return result;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var result = _context.Students.ToList();
            return result;
        }
            

        public async Task<Student> GetByIdAsync(int studentId)
        {   
            var student = _context.Students.FirstOrDefault(x => x.StudentId == studentId);
            var result = new Student
            {
                StudentId = studentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PESEL = student.PESEL,
                DateOfBirth = student.DateOfBirth,
                Adress = student.Adress,
                PostCode = student.PostCode,
                City = student.City,
                Email = student.Email,
                PhoneNr = student.PhoneNr,
                Status = "Locked",
                Category=student.Category,
                Modification = student.Modification,
            };

            return result;
        }

        public async Task<int> AddAsync(Student student, CancellationToken cancellationToken)
        {
            await _context.Students.AddAsync(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PESEL = student.PESEL,
                DateOfBirth = student.DateOfBirth,
                Adress = student.Adress,
                PostCode = student.PostCode,
                City = student.City,
                Email = student.Email,
                PhoneNr = student.PhoneNr,
                Status = "Locked",
                Category = student.Category,
                Created = DateTime.Now,
                Modification = DateTime.Now
            },
                 cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            var studentId = _context.Students.Max(i => i.StudentId);
            
            return studentId;
        }

        public async Task<int> UpdateAsync(Student student, CancellationToken cancellationToken)
        {
            var db = _context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (db != null)
            {
                db.FirstName = student.FirstName;
                db.LastName = student.LastName;
                db.PESEL = student.PESEL;
                db.DateOfBirth = student.DateOfBirth;
                db.Adress = student.Adress;
                db.PostCode = student.PostCode;
                db.City = student.City;
                db.Email = student.Email;
                db.PhoneNr = student.PhoneNr;
                db.Status = "Locked";
                db.Category = student.Category;
                db.Modification = DateTime.Now;

                _context.Students.Update(db);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(int studentId, CancellationToken cancellationToken)
        {
            var DeleteStudent = _context.Students.FirstOrDefault(x => x.StudentId == studentId);
            if(DeleteStudent != null)
            _context.Students.RemoveRange(DeleteStudent);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    } 
}
