using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly dbContext _context;       

        public TimetableRepository(dbContext context)
        {
            _context = context;           
        }
        public async Task<IEnumerable<TimetableWithDescription>> GetAllAsync()
        {
            string query = @" Select t.Id as Id, t.Date as Date, t.NumbersOfHours as NumbersOfHours, t.Category, i.FirstName+' '+i.LastName as Instructor, s.FirstName+' '+s.LastName as Student,
                        c.Mark+' '+c.Model+' '+c.RejestractionNumber as Car
                        from Timetables t
                        join Students s on s.StudentId = t.StudentId
                        join Instructors i on i.Id = t.InstructorId
                        join Cars c on c.CarId = t.CarId
                        order by id";

            using (var connection = _context.Database.GetDbConnection())
            {
                 var result = await connection.QueryAsync<TimetableWithDescription>(query, commandType: CommandType.Text);
                 return result.ToList();
            }
        }   

        public async Task<int> AddAsync(Timetable body, CancellationToken cancellationToken)
        {
            var lastId = _context.Timetables.Max(x => x.Id);
            lastId = (lastId == null ? 0 : lastId+1);

            await _context.Timetables.AddAsync(new Timetable{               
                    Date = body.Date,
                    NumbersOfHours = body.NumbersOfHours,
                    Category = body.Category,
                    InstructorId = body.InstructorId,
                    StudentId = body.StudentId,
                    CarId = body.CarId,
                    Status = body.Status,
                    Created = DateTime.Now,
                    Modification = DateTime.Now},
                    cancellationToken) ;

            await _context.SaveChangesAsync(cancellationToken);
            var Id = _context.Timetables.Max(i => i.Id);
            
            return Id;
        }

        public async Task<int> DeleteAsync(int timetableId, CancellationToken cancellationToken)
        {
            var DeleteTimetable = _context.Timetables.FirstOrDefault(x => x.Id == timetableId);
            if (DeleteTimetable != null) _context.Timetables.RemoveRange(DeleteTimetable);

            return await _context.SaveChangesAsync(cancellationToken);
        }


    } 
}
