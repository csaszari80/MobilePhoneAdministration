using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobilePhoneAdministration.Models
{
    public class CostPlace
    {
        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Költséghely kódja
        /// </summary>
        [Required]
        public string CostCode { get; set; }

        /// <summary>
        /// Költséghely neve
        /// </summary>
        [Required]
        public string CostName { get; set; }

        /// <summary>
        /// Szervezeti egység kódja
        /// </summary>
        public string OrganizationCode { get; set; }

        /// <summary>
        /// Szervezeti egység neve
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// A szervezeti egység költségeit tovább számlázzuk-e.
        /// </summary>
        public bool ForwardedBill { get; set; } = false;

        /// <summary>
        /// A szervezeti egység kódja és neve egy stringben a lenyílókhoz
        /// </summary>
        [NotMapped]
        public string CostCodeAndName
        {
            get { return this.CostCode + " - " + this.CostName; }
        }

        /// <summary>
        /// paraméterek nélküli konstruktor
        /// </summary>
        public CostPlace()
        {

        }

        public CostPlace(string costcode, string costname, string organizationcode, string organizationname, bool forwardedbill)
        {
            CostCode = costcode;
            CostName = costname;
            OrganizationCode = organizationcode;
            OrganizationName = organizationname;
            ForwardedBill = forwardedbill;
        }
    
    }
}
