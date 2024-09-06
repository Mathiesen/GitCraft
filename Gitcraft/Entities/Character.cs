namespace Gitcraft.Entities;

public class Character
{
    public Guid Id {get; set;}
    public string Name { get; set; }
    public string Class { get; set; }

    public string Race
    {
        get;
        set;
    }
}