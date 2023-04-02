namespace FluentUI.Demo.ControlSample;

public class MainViewModel
{
    public MainViewModel()
    {
        Users = new List<User>()
        {
            new User { Name = "Manuel Lozano", Gender = Gender.Male, Age = 27, Registered = true },
            new User { Name = "Carmen González", Gender = Gender.Female, Age = 31, Registered = false },
            new User { Name = "Luisa Márquez", Gender = Gender.Female, Age = 22, Registered = true },
            new User { Name = "Juan Sánchez", Gender = Gender.Male, Age = 19, Registered = false },
            new User { Name = "Andrea Ochoa", Gender = Gender.Female, Age = 35, Registered = true },
            new User { Name = "Diego Rosales", Gender = Gender.Male, Age = 40, Registered = false },
            new User { Name = "Marta Núñez", Gender = Gender.Female, Age = 28, Registered = true },
            new User { Name = "Arturo Vázquez", Gender = Gender.Male, Age = 30, Registered = false },
            new User { Name = "Raquel Soria", Gender = Gender.Female, Age = 25, Registered = true },
            new User { Name = "Oscar Barrera", Gender = Gender.Male, Age = 33, Registered = false },
            new User { Name = "Mireia Herrera", Gender = Gender.Female, Age = 24, Registered = true },
            new User { Name = "Eloy Rubio", Gender = Gender.Male, Age = 37, Registered = false },
            new User { Name = "Bianca Rodríguez", Gender = Gender.Female, Age = 29, Registered = true },
            new User { Name = "Aitor Gómez", Gender = Gender.Male, Age = 26, Registered = false },
            new User { Name = "Jazmín Álvarez", Gender = Gender.Female, Age = 23, Registered = true },
            new User { Name = "Jorge Reyes", Gender = Gender.Male, Age = 34, Registered = false },
            new User { Name = "Nuria Calvo", Gender = Gender.Female, Age = 32, Registered = true },
            new User { Name = "Iván Sosa", Gender = Gender.Male, Age = 21, Registered = false },
            new User { Name = "Rosa Torres", Gender = Gender.Female, Age = 36, Registered = true },
            new User { Name = "Javier Vega", Gender = Gender.Male, Age = 39, Registered = false }
        };

    }

    public List<User> Users { get; }
}

public class User
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public bool Registered { get; set; }
}

public enum Gender
{
    Female,
    Male,
}