using LINQ;

var games = new List<Game>
{
    new Game{ Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", ReleaseYear = 2017, Rating = 4.9, Price = 60 },
    new Game{ Title = "Super Mario Odyssey", Genre = "Platformer", ReleaseYear = 2014, Rating = 4.8, Price = 60 },
    new Game{ Title = "Horizon Zero Dawn", Genre = "RPG", ReleaseYear = 2010, Rating = 4.7, Price = 50 },
    new Game{ Title = "Persona 5", Genre = "Role-playing", ReleaseYear = 2018, Rating = 4.6, Price = 60 },

};

var allGames = games.Select(game => game.Title);

var rpgGames = games.Where(game => game.Genre == "RPG");
Console.WriteLine("RPG games:\n");
foreach (var game in rpgGames)
{
   Console.WriteLine(game.Title);
}

var modernGames = games.Any(game => game.ReleaseYear >2015);
Console.WriteLine($"Are there any modern games? : {modernGames}\n");

var sortedByYear = games.OrderBy(g => g.ReleaseYear);

Console.WriteLine("Games sorted by year:\n");

foreach (var game in sortedByYear)
{
    Console.WriteLine(game.Title+" : "+game.ReleaseYear);
}
