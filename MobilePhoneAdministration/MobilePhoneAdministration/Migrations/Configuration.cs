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
        }
    }
}
