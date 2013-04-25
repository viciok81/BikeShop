using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    [Table("vProductAndDescription", Schema = "SalesLT")]
    public partial class VProductAndDescription
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductModel { get; set; }
        public string Culture { get; set; }
        public string Description { get; set; }

    }

}
