using FormaUI.Controls;

namespace FormaUI.Demo.ControlSample;

public class MainViewModel
{
    public MainViewModel()
    {
        Users = new List<User>()
        {
            new User("Manuel Lozano", Gender.Male, 27, true),
            new User("Carmen González", Gender.Female, 31, false),
            new User("Luisa Márquez", Gender.Female, 22, true),
            new User("Juan Sánchez", Gender.Male, 19, false),
            new User("Andrea Ochoa", Gender.Female, 35, true),
            new User("Diego Rosales", Gender.Male, 40, false),
            new User("Marta Núñez", Gender.Female, 28, true),
            new User("Arturo Vázquez", Gender.Male, 30, false),
            new User("Raquel Soria", Gender.Female, 25, true),
            new User("Oscar Barrera", Gender.Male, 33, false),
            new User("Mireia Herrera", Gender.Female, 24, true),
            new User("Eloy Rubio", Gender.Male, 37, false),
            new User("Bianca Rodríguez", Gender.Female, 29, true),
            new User("Aitor Gómez", Gender.Male, 26, false),
            new User("Jazmín Álvarez", Gender.Female, 23, true),
            new User("Jorge Reyes", Gender.Male, 34, false),
            new User("Nuria Calvo", Gender.Female, 32, true),
            new User("Iván Sosa", Gender.Male, 21, false),
            new User("Rosa Torres", Gender.Female, 36, true),
            new User("Javier Vega", Gender.Male, 39, false)
        };

#if NET5_0_OR_GREATER
        Icons = Enum.GetValues<Symbol>()
#else
        Icons = Enum.GetValues(typeof(Symbol)).Cast<Symbol>()
#endif
            .Skip(1)
            .OrderBy(x => x.ToString())
            .ToList();
    }

    public List<User> Users { get; }
    public List<Symbol> Icons { get; }
}