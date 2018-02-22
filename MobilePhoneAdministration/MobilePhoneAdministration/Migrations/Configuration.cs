namespace MobilePhoneAdministration.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobilePhoneAdministration.Models.MobilePhoneAdministrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MobilePhoneAdministration.Models.MobilePhoneAdministrationContext";
        }

        protected override void Seed(MobilePhoneAdministration.Models.MobilePhoneAdministrationContext context)
        {
            //Költséghelyek feltöltése
            context.CostPlaces.AddOrUpdate(x => x.CostCode,
                new CostPlace(costcode: "511A", costname: "Költséghely 1", organizationcode: "11111", organizationname: "Szervezeti Egység 1",forwardedbill: false),
                new CostPlace(costcode: "444A", costname: "Költséghely 2", organizationcode: "11111", organizationname: "Szervezeti Egység 2", forwardedbill: false)
            );
            context.SaveChanges();

            //felhasználók feltöltése:
            context.Users.AddOrUpdate(x => x.CPID,
                new User(cpid: 111, name: "Példa Péter", adlogin: "pelda1", active: true, editable: false, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "444A")),
                new User(cpid: 112, name: "Mondjuk Márton", adlogin: "mondjuk1", active: true, editable: true, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "444A")),
                new User(cpid: 113, name: "Legyen Lenke", adlogin: "legyen1", active: false, editable: false, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "511A"))
            );
            context.SaveChanges();

            //szerződéstípusok feltöltése
            context.ContractCategories.AddOrUpdate(x => x.Name,
                new ContractCategory(name: "telefon/internet"),
                new ContractCategory(name: "internet"),
                new ContractCategory(name: "korlátozott adat")
            );
            context.SaveChanges();

            //simkártyák feltöltése
            context.SIMCards.AddOrUpdate(x => x.PhoneNumber,
                new SIMCard(contractid: "1/2018", phonenumber: "+36304489999", contractcategory: context.ContractCategories.Single(x => x.Name == "telefon/internet"), contractdate: DateTime.Today),
                new SIMCard(contractid: "2/2018", phonenumber: "+36304489998", contractcategory: context.ContractCategories.Single(x => x.Name == "telefon/internet"), contractdate: DateTime.Today),
                new SIMCard(contractid: "3/2018", phonenumber: "+36304489997", contractcategory: context.ContractCategories.Single(x => x.Name == "telefon/internet"), contractdate: DateTime.Today)
            );
            context.SaveChanges();
        }
    }
}
