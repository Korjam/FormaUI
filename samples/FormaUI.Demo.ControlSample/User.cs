namespace FormaUI.Demo.ControlSample;

public record User(string Name, Gender Gender, int Age, bool Registered);

public enum Gender
{
    Female,
    Male,
}