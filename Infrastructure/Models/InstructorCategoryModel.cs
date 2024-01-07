namespace Infrastructure.Models
    {
    public class InstructorCategoryModel 
    {       
        public int Id { get; set; } = 0;
        public int InstructorId { get; set; } = 0;
        public int CatAM { get; set; }
        public int CatA1 { get; set; }
        public int CatA2 { get; set; }
        public int CatA { get; set; }
        public int CatB { get; set; }
        public int CatB1 { get; set; }
        public int CatC { get; set; }
        public int CatC1 { get; set; }
        public int CatD1 { get; set; }
        public int CatD { get; set; }
        public int CatBE { get; set; }
        public int CatC1E { get; set; }
        public int CatCE { get; set; }
        public int CatDE { get; set; }
        public int CatD1E { get; set; }
        public int CatT { get; set; }
        public DateTime Created { get; set; }        
        public DateTime Modification { get; set; }
    }
}