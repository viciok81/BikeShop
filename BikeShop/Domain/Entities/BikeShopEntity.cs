using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public abstract class BikeShopEntity
    {
        [HiddenInput(DisplayValue = false)]//, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid rowguid { get; set; }

        [HiddenInput(DisplayValue = false)]//, DatabaseGenerated(x=>DateTime.Now)]
        public DateTime ModifiedDate { get; set; }
    }
}
