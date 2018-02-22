using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

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
        /// A kártya eszközszáma:
        /// </summary>
        public string DeviceNumber { get; set; }

        /// <summary>
        /// A kártyához kapcsolódó szerződés Kelte
        /// </summary>
        public DateTime ContractDate { get; set; }

        /// <summary>
        /// Telefonszám
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Szerződés kategóriája pl(általános, internet, korlátozott adat) a lehetséges kategóriákat a hálózati csoport határozza meg
        /// </summary>
        [Required]
        public ContractCategory ContractCategory { get; set; }

        /// <summary>
        /// A SIM kártya IMEI száma
        /// </summary>
        public string CardIMEI { get; set; }

        /// <summary>
        /// A kártya PIN1 kódja
        /// </summary>
        public string PIN1 { get; set; }

        /// <summary>
        /// A kártya PIN2 kódja
        /// </summary>
        public string PIN2 { get; set; }
        
        /// <summary>
        /// A kártya PUK1 kódja
        /// </summary>
        public string PUK1 { get; set; }
        
        /// <summary>
        /// A kártya PUK2 kódja
        /// </summary>
        public string PUK2 { get; set; }

        /// <summary>
        /// A kártyához vagy szerződéshez fűződő megjegyzés
        /// </summary>
        public string Comment { get; set; }

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

        public SIMCard(string contractid, string phonenumber, ContractCategory contractcategory, DateTime contractdate)
        {
            ContractId = contractid;
            PhoneNumber = phonenumber;
            ContractCategory = contractcategory;
           ContractDate = contractdate;
        }
    }
}