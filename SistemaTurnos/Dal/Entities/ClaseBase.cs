using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTurnos.Dal.Entities
{
    public class ClaseBase
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public bool IsDeleted { get; set; }
        //public DateTime DeletedTime { get; set; }

    }
}
