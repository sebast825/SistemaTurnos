using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatronRepositorio_UnitOfWork.Dal.Entities
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
