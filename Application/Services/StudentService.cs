using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Application.Command.Students;
using Application.DTO.Students;
using System.Globalization;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository repository)
        {
            _studentRepository = repository;
        }
        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var data =  _studentRepository.GetAllAsync();
            List<StudentDTO> result = new List<StudentDTO>();

            foreach (var item in data.Result)
            {
                result.Add(new StudentDTO
                {   
                    StudentId = item.StudentId,
                    FirstName = item.FirstName,
                    LastName = item.LastName                  
                 });
            }
            return result;
        }
        public async Task<StudentFullDTO> GetStudentById(int studentId)
        {
            var data = await _studentRepository.GetByIdAsync(studentId);
            var result = new StudentFullDTO
            {   
                StudentId = data.StudentId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = DateTime.ParseExact(data.DateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture),
                PESEL = data.PESEL.ToString(),
                Adress = data.Adress,
                PostCode = data.PostCode,
                City = data.PostCode,
                Email = data.Email,
                PhoneNr = data.PhoneNr,
                Category = data.Category,
                Status = data.Status,
                Modyfication = data.Modification
            };
            return result;
        }
        public async Task<int> AddStudent(CreateStudentCommand body, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = body.FirstName,
                LastName = body.LastName,
                DateOfBirth = body.DateOfBirth.ToString("yyyyMMdd"),
                PESEL = body.PESEL,
                Adress = body.Adress,
                PostCode = body.PostCode,
                City = body.PostCode,
                Email = body.Email,
                PhoneNr = body.PhoneNr,
                Category = body.Category,
                Status = body.Status
            };                       
           return  await _studentRepository.AddAsync(student, cancellationToken);         
            
        }
        public async Task<int> UpdateStudent(UpdateStudentCommand body, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                StudentId = body.StudentId,
                FirstName = body.FirstName,
                LastName = body.LastName,
                DateOfBirth = body.DateOfBirth.ToString("yyyyMMdd"),
                PESEL = body.PESEL,
                Adress = body.Adress,
                PostCode = body.PostCode,
                City = body.PostCode,
                Email = body.Email,
                PhoneNr = body.PhoneNr,
                Category = body.Category,
                Status = body.Status,
                Modification = DateTime.Now
            };
            return await _studentRepository.UpdateAsync(student, cancellationToken);
        }
        public async Task<int> DeleteStudent(DeleteStudentCommand body, CancellationToken cancellationToken)
        {
            var studentId = body.StudentId;            
            return await _studentRepository.DeleteAsync(studentId, cancellationToken);
        }
               
    }
}
