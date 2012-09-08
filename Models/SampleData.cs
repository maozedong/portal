using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Portal.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<PortalEntities>
    {
        protected override void Seed(PortalEntities context)
        {
            var images = new List<Image>
            {
                new Image { Name="sample1", ImgUrl="/Content/Images/AirDragon-DayLight.jpg" },
                new Image { Name="sample2", ImgUrl="/Content/Images/conteiner_white_img-1.png" }
            };

            new List<Service>
            {
                new Service { Name = "Handmade", Description="Арт-декор, малюнок на футболках, малюнок неоновими фарбами", Images = images, ImgUrl="/Content/Images/AirDragon-DayLight.jpg" }
            }.ForEach(a => context.Services.Add(a));
        }
    }
}