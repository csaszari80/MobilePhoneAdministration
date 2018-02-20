using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MobilePhoneAdministration.Models
{
    public class User
    {
        //Todo: Annotációkkal magyarítani a címkefeliratokat.

        /// <summary>
        /// PK az adatbázisbam
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// A felhasználó teljes neve
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// A felhsználó CPID-ja (dokszám)
        /// </summary>
        public int CPID { get; set; }

        /// <summary>
        /// A felhasználó login neve az AD-ban
        /// </summary>
        public string ADlogin { get; set; }

        /// <summary>
        /// A felhasználó Aktív -e még (Van-e élő munkaszerződése)
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// A felhasznóló adatai szerkeszthetők-e (A SAP HR-ből kapott adatokat felhasználva a felhasználók adatai adat automatikusan frissülnek a CPID alapján,
        /// ezeket nem érdemes szerkeszteni. Akik kézzel lettek felvéve az adatbázisba, azokat kézzel is kell karbantartani addig amíg nem érkezik adat a CPID-hoz onnantól automatikusan frissülnek.
        /// </summary>
        public bool Editable { get; set; } = true;

        /// <summary>
        /// A felhasználó telefonjai megjelenjenek -e az exportált listában
        /// </summary>
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// Egy felhasználó költséghelyének Id-je
        /// </summary>
        [NotMapped]
        public int CostPlaceId { get; set; }


        /// <summary>
        /// A választható költséghelyek listája
        /// </summary>
        [NotMapped]
        public SelectList AssignableCostPlaces { get; set; }

        /// <summary>
        /// A felhasználó költséghelye
        /// </summary>
        [Required]
        public CostPlace CostPlace { get; set; }

        public User()
        {

        }

        public User(int cpid, string name, string adlogin, bool active, bool editable, bool hidden, CostPlace costplace)
        {
            CPID = cpid;
            Name = name;
            ADlogin = adlogin;
            Active = active;
            Editable = editable;
            Hidden = hidden;
            CostPlace = costplace;
        }
        
        
    }
}