using AutokConsole.Models;

Auto.LoadFromCSV("Data\\autok.csv");
List<Auto> autos = Auto.GetCars();

Console.WriteLine($"5. feladat: {autos.Count} autó található a listában");
Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {autos.Average(x => x.Sold)}");
Console.WriteLine($"7. feladat: Az elmúlt 5 évben gyártott autók:");
foreach (Auto auto in autos)
{
    if (auto.Year >= DateTime.Now.Year - 5)
    {
        Console.WriteLine($"\t{auto.Brand} {auto.Model}: {auto.Year}");
    }
}
Console.WriteLine($"8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
var brands = autos.GroupBy(x => x.Brand)
    .Select(g => new { Brand = g.Key, TotalSold = g.Sum(x => x.Sold) })
    .OrderByDescending(x => x.TotalSold)
    .ToList();
foreach (var brand in brands)
{
    Console.WriteLine($"\t{brand.Brand}: {brand.TotalSold} darab");
}