using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class BuildVersion
    {
        [Key]
        public byte SystemInformationID { get; set; }
        public string Database_Version { get; set; }
        public System.DateTime VersionDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
