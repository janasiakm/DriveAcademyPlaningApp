using Domain.Entities;
using Infrastructure.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace Infrastructure.Repositories
{
    public class InstructorRepositoryEF : IInstructorRepository
    {
        private readonly dbContext _context;       

        public InstructorRepositoryEF(dbContext context)
        {
            _context = context;           
        }

        public Instructor GetInstructorById(int id)
        {
            var result = _context.Instructors.FirstOrDefault(x => x.Id == id);
            return result;
        }
        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            var result = _context.Instructors.ToList<Instructor>();
            return result;
        }

        public async Task<Instructor> GetByIdAsync(int instructorId)
        {   
            var instructor = _context.Instructors.FirstOrDefault(x => x.Id == instructorId);
            var result = new Instructor{
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                IdNumber = instructor.IdNumber,
                Adress = instructor.Adress,
                PostCode = instructor.PostCode,
                City = instructor.City,
                Email = instructor.Email,
                PhoneNr = instructor.PhoneNr,
                Status = instructor.Status,              
                Modification = instructor.Modification,
                Created = instructor.Created
            };
            return result;
        }

        public async Task<int> AddAsync(Instructor instructor, CancellationToken cancellationToken)
        {
            await _context.Instructors.AddAsync(new Instructor
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                IdNumber = instructor.IdNumber,
                Adress = instructor.Adress,
                PostCode = instructor.PostCode,
                City = instructor.City,
                Email = instructor.Email,
                PhoneNr = instructor.PhoneNr,
                Status = "Locked",
                Created = DateTime.Now,
                Modification = DateTime.Now
            },
                 cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            var instructorId = _context.Instructors.Max(i => i.Id);
            
            return instructorId;
        }

        public async Task<int> UpdateAsync(Instructor body, CancellationToken cancellationToken)
        {
            var db = _context.Instructors.FirstOrDefault(x => x.Id == body.Id);
            if (db != null)
            {
                db.FirstName = body.FirstName;
                db.LastName = body.LastName;
                db.DateOfBirth = body.DateOfBirth;
                db.IdNumber = body.IdNumber;
                db.Adress = body.Adress;
                db.PostCode = body.PostCode;
                db.City = body.City;
                db.Email = body.Email;
                db.PhoneNr = body.PhoneNr;
                db.Status = "Locked";
                db.Modification = DateTime.Now;
                
                _context.Instructors.Update(db);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(int userId, CancellationToken cancellationToken)
        {
            var DeleteInstructor = _context.Instructors.FirstOrDefault(x => x.Id == userId);
            if (DeleteInstructor != null)
            {
                var DeleteCategory = _context.InstructorCategory.FirstOrDefault(x => x.InstructorId == DeleteInstructor.Id);
                _context.Instructors.RemoveRange(DeleteInstructor);
                _context.InstructorCategory.RemoveRange(DeleteCategory);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        //Category
        public async Task<int> AddCategoryInstructor(int instructorId, CancellationToken cancellationToken)
        {
            var instructorCategory = new InstructorCategoryModel
            {
                InstructorId = instructorId,
                Created = DateTime.Now,
                Modification = DateTime.Now
            };
            await _context.InstructorCategory.AddAsync(instructorCategory);
            return await _context.SaveChangesAsync(cancellationToken);
        }

            public InstructorWithCategory GetCategoryInstructorAsync(int instructorId)
        {
            var data = _context.InstructorCategory.FirstOrDefault(x => x.InstructorId == instructorId);
            if (data != null)
            {
                var result = new InstructorWithCategory
                {
                    InstructorId = data.InstructorId,
                    CatAM = (data.CatAM == 1 ? true : false),
                    CatA1 = (data.CatA1 == 1 ? true : false),
                    CatA2 = (data.CatA2 == 1 ? true : false),
                    CatA = (data.CatA == 1 ? true : false),
                    CatB1 = (data.CatB1 == 1 ? true : false),
                    CatB = (data.CatB == 1 ? true : false),
                    CatC1 = (data.CatC1 == 1 ? true : false),
                    CatC = (data.CatC == 1 ? true : false),
                    CatD1 = (data.CatD1 == 1 ? true : false),
                    CatD = (data.CatD == 1 ? true : false),
                    CatBE = (data.CatBE == 1 ? true : false),
                    CatC1E = (data.CatC1E == 1 ? true : false),
                    CatCE = (data.CatCE == 1 ? true : false),
                    CatD1E = (data.CatD1E == 1 ? true : false),
                    CatDE = (data.CatDE == 1 ? true : false),
                    CatT = (data.CatT == 1 ? true : false)
                };
                return result;
            }
            else
            {
                var result2 = new InstructorWithCategory();
                return result2;
            }

        }
        public async Task<IEnumerable<InstructorWithCategory>> GetAllCategoryInstructorAsync()
        {
            var instructors= await _context.Instructors.ToListAsync();
            var categories = await _context.InstructorCategory.ToListAsync();
            
            var result = from category in categories 
                         join instructor in instructors on category.InstructorId equals instructor.Id
                         select new InstructorWithCategory
                         {
                             InstructorId = instructor.Id,
                             FirstName = instructor.FirstName,
                             LastName = instructor.LastName,
                             CatAM = (category.CatAM == 1 ? true : false),
                             CatA1 = (category.CatA1 == 1 ? true : false),
                             CatA2 = (category.CatA2 == 1 ? true : false),
                             CatA = (category.CatA == 1 ? true : false),
                             CatB1 = (category.CatB1 == 1 ? true : false),
                             CatB = (category.CatB == 1 ? true : false),
                             CatC1 = (category.CatC1 == 1 ? true : false),
                             CatC = (category.CatC == 1 ? true : false),
                             CatD1 = (category.CatD1 == 1 ? true : false),
                             CatD = (category.CatD == 1 ? true : false),
                             CatBE = (category.CatBE == 1 ? true : false),
                             CatC1E = (category.CatC1E == 1 ? true : false),
                             CatCE = (category.CatCE == 1 ? true : false),
                             CatD1E = (category.CatD1E == 1 ? true : false),
                             CatDE = (category.CatDE == 1 ? true : false),
                             CatT = (category.CatT == 1 ? true : false)
                         };           

            return result;               
            }

            public async Task<int> UpdateCategoryAsync(InstructorWithCategory instructor, CancellationToken cancellationToken)
            {
                string query = @" UPDATE InstructorCategory  SET  CatAM = @CatAM, CatA1 = @CatA1, CatA2 = @CatA2, CatA = @CatA, CatB1 = @CatB1, CatB = @CatB, CatC1 = @CatC1,
                                            CatC = @CatC, CatD1 = @CatD1, CatD = @CatD, CatBE = @CatBE, CatC1E = @CatC1E, CatCE = @CatCE, CatD1E = @CatD1E,
                                            CatDE = @CatDE, CatT = @CatT, Modification = @Modification  WHERE InstructorId = @InstructorId"; 
                var parameters = new {
                    InstructorId = instructor.InstructorId,
                    CatAM = (instructor.CatAM ? 1 : 0),
                    CatA1 = (instructor.CatA1 ? 1 : 0),
                    CatA2 = (instructor.CatA2 ? 1 : 0),
                    CatA = (instructor.CatA ? 1 : 0),
                    CatB1 = (instructor.CatB1 ? 1 : 0),
                    CatB = (instructor.CatB ? 1 : 0),
                    CatC1 = (instructor.CatC1 ? 1 : 0),
                    CatC = (instructor.CatC ? 1 : 0),
                    CatD1 = (instructor.CatD1 ? 1 : 0),
                    CatD = (instructor.CatD ? 1 : 0),
                    CatBE = (instructor.CatBE ? 1 : 0),
                    CatC1E = (instructor.CatC1E ? 1 : 0),
                    CatCE = (instructor.CatCE ? 1 : 0),
                    CatD1E = (instructor.CatD1E ? 1 : 0),
                    CatDE = (instructor.CatDE ? 1 : 0),
                    CatT = (instructor.CatT ? 1 : 0),
                    Modification = DateTime.Now
                     };
                using var connection = _context.Database.GetDbConnection();
                connection.Open();
                connection.Execute(query, parameters);
                       
            return await _context.SaveChangesAsync(cancellationToken);
        }     

    } 
}
