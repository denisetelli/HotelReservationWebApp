using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commom.Enums
{
    public enum ReservationStatusEnum
    {
        [Display(Name = "Confirmada")]
        Reserved = 1,

        [Display(Name = "Cancelada")]
        Cancelled = 2,

        [Display(Name = "Hóspede na casa")]
        InHouse = 3,

        [Display(Name = "Check out")]
        CheckedOut = 4
    }
}
