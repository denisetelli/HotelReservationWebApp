using System.ComponentModel.DataAnnotations;

namespace Commom.Enums
{
    public enum ClientTypeEnum
    {
        [Display(Name = "Pessoa Física")]
        Person,

        [Display(Name = "Pessoa Jurídica")]
        Organization
    }
}
