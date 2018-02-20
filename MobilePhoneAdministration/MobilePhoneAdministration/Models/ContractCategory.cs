using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneAdministration.Models
{
    public class ContractCategory
    {
        /// <summary>
        /// Elsődleges kulcs
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Szerződéskategória megnevezése
        /// </summary>
        [Required]
        public string Name { get; set; }

        public ContractCategory()
        {

        }

        public ContractCategory(string name)
        {
            Name = name;
        }
    }
}