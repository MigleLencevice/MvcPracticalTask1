using Microsoft.EntityFrameworkCore;
using MvcPracticalTask.Models;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// DATA SEED
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Films.Any())
    {
        context.Films.AddRange(
            new Film { FilmID = 1, Title = "Jurassic Park", DirectorID = 4, Review = "People clone dinosaurs. Dinosaurs promptly eat people. Horror ensues.", RunTimeMinutes = 126, BudgetDollars = 63000000, BoxOfficeDollars = 1029939903, OscarNominations = 3, OscarWins = 3 },
            new Film { FilmID = 2, Title = "Spider-Man", DirectorID = 11, Review = "High-school nerd Peter Parker becomes Spider-Man after a spider bite.", RunTimeMinutes = 121, BudgetDollars = 140000000, BoxOfficeDollars = 821708551, OscarNominations = 2, OscarWins = 0 },
            new Film { FilmID = 3, Title = "King Kong", DirectorID = 12, Review = "An adventure involving a giant ape.", RunTimeMinutes = 187, BudgetDollars = 207000000, BoxOfficeDollars = 550500000, OscarNominations = 4, OscarWins = 3 },
            new Film { FilmID = 5, Title = "Superman Returns", DirectorID = 14, Review = "Superman returns after a long absence.", RunTimeMinutes = 154, BudgetDollars = 204000000, BoxOfficeDollars = 391081192, OscarNominations = 1, OscarWins = 0 },
            new Film { FilmID = 6, Title = "Titanic", DirectorID = 15, Review = "A tragic love story aboard the Titanic.", RunTimeMinutes = 194, BudgetDollars = 200000000, BoxOfficeDollars = 2186772302, OscarNominations = 14, OscarWins = 11 },
            new Film { FilmID = 7, Title = "Evan Almighty", DirectorID = 16, Review = "Morgan Freeman is God. Steve Carell builds a giant wooden boat.", RunTimeMinutes = 96, BudgetDollars = 175000000, BoxOfficeDollars = 173418781, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 8, Title = "Waterworld", DirectorID = 17, Review = "A flooded post-apocalyptic world with Kevin Costner.", RunTimeMinutes = 135, BudgetDollars = 175000000, BoxOfficeDollars = 264218220, OscarNominations = 1, OscarWins = 0 },
            new Film { FilmID = 9, Title = "Pearl Harbor", DirectorID = 18, Review = "A war drama set around the attack on Pearl Harbor.", RunTimeMinutes = 183, BudgetDollars = 140000000, BoxOfficeDollars = 449220945, OscarNominations = 4, OscarWins = 1 },
            new Film { FilmID = 10, Title = "Transformers", DirectorID = 18, Review = "Autobots and Decepticons battle on Earth.", RunTimeMinutes = 144, BudgetDollars = 150000000, BoxOfficeDollars = 709709780, OscarNominations = 3, OscarWins = 0 },
            new Film { FilmID = 11, Title = "Harry Potter and the Order of the Phoenix", DirectorID = 19, Review = "Harry faces growing darkness at Hogwarts and beyond.", RunTimeMinutes = 138, BudgetDollars = 150000000, BoxOfficeDollars = 939885929, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 12, Title = "Beowulf", DirectorID = 20, Review = "A CGI adaptation of the Old English epic.", RunTimeMinutes = 115, BudgetDollars = 150000000, BoxOfficeDollars = 196393745, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 13, Title = "Bee Movie", DirectorID = 21, Review = "An animated comedy about a talking bee.", RunTimeMinutes = 91, BudgetDollars = 150000000, BoxOfficeDollars = 287594577, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 14, Title = "Pirates of the Caribbean: At World's End", DirectorID = 22, Review = "Pirates, curses and sea battles continue.", RunTimeMinutes = 168, BudgetDollars = 300000000, BoxOfficeDollars = 963420425, OscarNominations = 2, OscarWins = 0 },
            new Film { FilmID = 15, Title = "I Am Legend", DirectorID = 23, Review = "A survivor searches for a cure in a near-empty world.", RunTimeMinutes = 100, BudgetDollars = 150000000, BoxOfficeDollars = 585349010, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 16, Title = "Ratatouille", DirectorID = 24, Review = "A rat becomes an unlikely chef in Paris.", RunTimeMinutes = 111, BudgetDollars = 150000000, BoxOfficeDollars = 623722818, OscarNominations = 5, OscarWins = 1 },
            new Film { FilmID = 17, Title = "Troy", DirectorID = 25, Review = "An epic retelling of the Trojan War.", RunTimeMinutes = 162, BudgetDollars = 175000000, BoxOfficeDollars = 497409852, OscarNominations = 1, OscarWins = 0 },
            new Film { FilmID = 18, Title = "Harry Potter and the Goblet of Fire", DirectorID = 26, Review = "Harry is unwillingly entered into the Triwizard Tournament.", RunTimeMinutes = 156, BudgetDollars = 150000000, BoxOfficeDollars = 896911078, OscarNominations = 1, OscarWins = 0 },
            new Film { FilmID = 19, Title = "Batman Begins", DirectorID = 27, Review = "Bruce Wayne becomes Batman.", RunTimeMinutes = 141, BudgetDollars = 150000000, BoxOfficeDollars = 374218673, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 20, Title = "Charlie and the Chocolate Factory", DirectorID = 28, Review = "A fantasy adventure inside Willy Wonka's factory.", RunTimeMinutes = 115, BudgetDollars = 150000000, BoxOfficeDollars = 474968763, OscarNominations = 1, OscarWins = 0 },
            new Film { FilmID = 21, Title = "Pirates of the Caribbean: Dead Man's Chest", DirectorID = 22, Review = "Jack Sparrow faces Davy Jones.", RunTimeMinutes = 151, BudgetDollars = 225000000, BoxOfficeDollars = 1066179725, OscarNominations = 4, OscarWins = 1 },
            new Film { FilmID = 22, Title = "Die Another Day", DirectorID = 29, Review = "James Bond returns with gadgets, action and excess.", RunTimeMinutes = 133, BudgetDollars = 142000000, BoxOfficeDollars = 431971116, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 23, Title = "Lethal Weapon 4", DirectorID = 30, Review = "Riggs and Murtaugh return for another action-packed case.", RunTimeMinutes = 127, BudgetDollars = 100000000, BoxOfficeDollars = 285444603, OscarNominations = 0, OscarWins = 0 },
            new Film { FilmID = 24, Title = "Armageddon", DirectorID = 18, Review = "A team is sent to stop an asteroid from hitting Earth.", RunTimeMinutes = 151, BudgetDollars = 140000000, BoxOfficeDollars = 553709788, OscarNominations = 4, OscarWins = 0 },
            new Film { FilmID = 25, Title = "Men in Black II", DirectorID = 31, Review = "Agents J and K reunite to save Earth again.", RunTimeMinutes = 89, BudgetDollars = 140000000, BoxOfficeDollars = 441818803, OscarNominations = 0, OscarWins = 0 }
        );

        context.SaveChanges();
    }
}

app.Run();