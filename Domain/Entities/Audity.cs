using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class Audity
    {
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Modification { get; set; }
    }
}