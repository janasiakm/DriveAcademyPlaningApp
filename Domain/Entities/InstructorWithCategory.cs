using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class InstructorWithCategory : Audity
    {

        [Key]
        public int Id { get; set; } = 0;
        public int InstructorId { get; set; } = 0;
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
    }
}