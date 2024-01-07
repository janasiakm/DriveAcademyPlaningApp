using Application.Interfaces;
using Application.Command.Instructors;
using Domain.Entities;
using Domain.Interfaces;
using Application.DTO;
using System.Globalization;
using Application.DTO.Instructors;

namespace Application.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _repository;

        public InstructorService(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InstructorWithCategoryDTO>> GetAllInstructors()
        {
            var dataInstructor =  await _repository.GetAllAsync();
            var dataCategory = await _repository.GetAllCategoryInstructorAsync();
            List<InstructorWithCategoryDTO> result = new List<InstructorWithCategoryDTO>();

            foreach (var item in dataInstructor)
            {
                var category = dataCategory.FirstOrDefault(x => x.InstructorId == item.Id);
                result.Add(new InstructorWithCategoryDTO
                {
                    InstructorId = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    CatAM = category.CatAM,
                    CatA1 = category.CatA1,
                    CatA2 = category.CatA2,
                    CatA = category.CatA,
                    CatB1 = category.CatB1,
                    CatB = category.CatB,
                    CatC1 = category.CatC1,
                    CatC = category.CatC,
                    CatD1 = category.CatD1,
                    CatD = category.CatD,
                    CatBE = category.CatBE,
                    CatC1E = category.CatC1E,
                    CatCE = category.CatCE,
                    CatD1E = category.CatD1E,
                    CatDE = category.CatDE,
                    CatT = category.CatT                                   
                }) ;
            }
            return result;
        }

        public async Task<InstructorFullDTO> GetInstructorById(int instructorId)
        {
            var data = await _repository.GetByIdAsync(instructorId);
            var result = new InstructorFullDTO
            {   
                InstructorId = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = DateTime.ParseExact(data.DateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture),
                IdNumber = data.IdNumber,
                Adress = data.Adress,
                PostCode = data.PostCode,
                City = data.PostCode,
                Email = data.Email,
                PhoneNr = data.PhoneNr,
                Modyfication = data.Modification                
            };
            return result;
        }

        public async Task<int> AddInstructor(CreateInstructorCommand body, CancellationToken cancellationToken)
        {
            var instructor = new Instructor
            {
                FirstName = body.FirstName,
                LastName = body.LastName,
                DateOfBirth = body.DateOfBirth.ToString("yyyyMMdd"),
                IdNumber = body.IdNumber,
                Adress = body.Adress,
                PostCode = body.PostCode,
                City = body.PostCode,
                Email = body.Email,
                PhoneNr = body.PhoneNr
            };                       
            var instructorId =  await _repository.AddAsync(instructor, cancellationToken);
            return await _repository.AddCategoryInstructor(instructorId, cancellationToken);
            
        }

        public async Task<int> UpdateInstructor(UpdateInstructorCommand body, CancellationToken cancellationToken)
        {
            var instructor = new Instructor
            {
                Id = body.InstructorId,
                FirstName = body.FirstName,
                LastName = body.LastName,
                DateOfBirth = body.DateOfBirth.ToString("yyyyMMdd"),
                IdNumber = body.IdNumber,
                Adress = body.Adress,
                PostCode = body.PostCode,
                City = body.PostCode,
                Email = body.Email,
                PhoneNr = body.PhoneNr
            };
            return await _repository.UpdateAsync(instructor, cancellationToken);
        }

        public async Task<int> DeleteInstructor(DeleteInstructorCommand body, CancellationToken cancellationToken)
        {
            var userid = body.InstructorId;            
            return await _repository.DeleteAsync(userid, cancellationToken);
        }

        //Category
        public InstructorWithCategoryDTO GetCategoryInstructorById(int instructorId)
        {
            var instructor =  _repository.GetInstructorById(instructorId);
            var category =  _repository.GetCategoryInstructorAsync(instructorId);
            var result = new InstructorWithCategoryDTO
            {
                InstructorId = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,                
                CatAM = category.CatAM,
                CatA1 = category.CatA1,
                CatA2 = category.CatA2,
                CatA = category.CatA,
                CatB1 = category.CatB1,
                CatB = category.CatB,
                CatC1 = category.CatC1,
                CatC = category.CatC,
                CatD1 = category.CatD1,
                CatD = category.CatD,
                CatBE = category.CatBE,
                CatC1E = category.CatC1E,
                CatCE = category.CatCE,
                CatD1E = category.CatD1E,
                CatDE = category.CatDE,
                CatT = category.CatT
            };        
            return result;
        }

        public async Task<int> UpdateCategoryInstructor(UpdateCategoryInstructorCommand body, CancellationToken cancellationToken)
        {
            var instructorCategory = new InstructorWithCategory {
                InstructorId=body.InstructorId,
                CatAM = body.CatAM,
                CatA1 = body.CatA1,
                CatA2 = body.CatA2,
                CatA = body.CatA,
                CatB1 = body.CatB1,
                CatB = body.CatB,
                CatC1 = body.CatC1,
                CatC = body.CatC,
                CatD1 = body.CatD1,
                CatD = body.CatD,
                CatBE = body.CatBE,
                CatC1E = body.CatC1E,
                CatCE = body.CatCE,
                CatD1E = body.CatD1E,
                CatDE = body.CatDE,
                CatT = body.CatT
            };
            return await _repository.UpdateCategoryAsync(instructorCategory, cancellationToken);
        }
    }
}
