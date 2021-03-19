using DockerAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ColourAPI.Models
{

public static class  PrepDB { 

public static void PrepPopulation(IApplicationBuilder app){
using (var serviceScope = app.ApplicationServices.CreateScope()){

SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());

}
}
public static void SeedData(ColourContext context)
{
    System.Console.WriteLine("Applying migrations");

    context.Database.Migrate();

    if(!context.ColourItems.Any())
    {
System.Console.WriteLine("Seeding...");
context.ColourItems.AddRange(
    new Colour() {ColourName="Red"},
    new Colour() {ColourName="Orange"},
    new Colour() {ColourName="Yellow"}
    );
context.SaveChanges();
    }else{

System.Console.WriteLine("Already data present -- not seeding");

    }
}
}


}