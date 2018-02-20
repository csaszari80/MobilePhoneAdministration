using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MobilePhoneAdministration.Models
{
    public class SIMCard
    {
        /// <summary>
        /// Elsődleges kulcs
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Szerződésszám
        /// </summary>
        public string ContractId { get; set; }

        /// <summary>
        /// Telefonszám
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Szerződés kategóriája pl(általános, internet, korlátozott adat) a lehetséges kategóriákat a hálózati csoport határozza meg
        /// </summary>
        public ContractCategory ContractCategory { get; set; }

        /// <summary>
        /// Az adott Simkártya szerződéskategóriájának Id-je
        /// </summary>
        [NotMapped]
        public int ContractCategoryId { get; set; }

        /// <summary>
        /// Az adott Simkártya szerződéskategóriájának Neve
        /// </summary>
        [NotMapped]
        public string ContractCategoryName { get; set; }

        /// <summary>
        /// A választható kategóriák listája
        /// </summary>
        [NotMapped]
        public SelectList AssignableContractCategories { get; set; }


        public SIMCard()
        {

        }

        public SIMCard(string contractid, string phonenumber, ContractCategory ContractCategory)
        {
            ContractId = contractid;
            PhoneNumber = phonenumber;
            this.ContractCategory = ContractCategory;
        }
    }
}