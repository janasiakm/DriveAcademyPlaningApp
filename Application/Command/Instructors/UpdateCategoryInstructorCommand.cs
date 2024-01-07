using Application.DTO;
using Application.DTO.Instructors;
using Domain.Entities;
using MediatR;

namespace Application.Command.Instructors
{
    public class UpdateCategoryInstructorCommand : IRequest<int>    
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public bool CatAM { get; set; }
        public bool CatA1 { get; set; }
        public bool CatA2 { get; set; }
        public bool CatA { get; set; }
        public bool CatB { get; set; }
        public bool CatB1 { get; set; }
        public bool CatC { get; set; }
        public bool CatC1 { get; set; }
        public bool CatD1 { get; set; }
        public bool CatD { get; set; }
        public bool CatBE { get; set; }
        public bool CatC1E { get; set; }
        public bool CatCE { get; set; }
        public bool CatDE { get; set; }
        public bool CatD1E { get; set; }
        public bool CatT { get; set; }
        public DateTime Modification { get; set; } = DateTime.Now;


        public UpdateCategoryInstructorCommand(InstructorWithCategoryDTO instructor)
        {
            InstructorId = instructor.InstructorId;
            FirstName = instructor.FirstName;
            LastName = instructor.LastName;
            CatAM = instructor.CatAM;
            CatA1 = instructor.CatA1;
            CatA2 = instructor.CatA2;
            CatA = instructor.CatA;
            CatB = instructor.CatB;
            CatB1 = instructor.CatB1;
            CatC = instructor.CatC;
            CatC1 = instructor.CatC1;
            CatD1 = instructor.CatD1;
            CatD = instructor.CatD;
            CatBE = instructor.CatBE;
            CatC1E = instructor.CatC1E;
            CatCE = instructor.CatCE;
            CatDE = instructor.CatDE;
            CatD1E = instructor.CatD1E;
            CatT = instructor.CatT;
        }
    }


}


