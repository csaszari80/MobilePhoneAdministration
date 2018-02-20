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
            //K�lts�ghelyek felt�lt�se
            context.CostPlaces.AddOrUpdate(x => x.CostCode,
                new CostPlace(costcode: "511A", costname: "K�lts�ghely 1", organizationcode: "11111", organizationname: "Szervezeti Egys�g 1",forwardedbill: false),
                new CostPlace(costcode: "444A", costname: "K�lts�ghely 2", organizationcode: "11111", organizationname: "Szervezeti Egys�g 2", forwardedbill: false)
            );
            context.SaveChanges();

            //felhaszn�l�k felt�lt�se:
            context.Users.AddOrUpdate(x => x.CPID,
                new User(cpid: 111, name: "P�lda P�ter", adlogin: "pelda1", active: true, editable: false, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "444A")),
                new User(cpid: 112, name: "Mondjuk M�rton", adlogin: "mondjuk1", active: true, editable: true, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "444A")),
                new User(cpid: 113, name: "Legyen Lenke", adlogin: "legyen1", active: false, editable: false, hidden: false, costplace: context.CostPlaces.Single(x => x.CostCode == "511A"))
            );
            context.SaveChanges();
        }
    }
}
