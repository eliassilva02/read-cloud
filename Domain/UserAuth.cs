namespace Domain;

public class UserAuth
{
    public string UserName { get; set; }
    public string HashPassword { get; set; }
    public ELevelUser LevelUser { get; set; }
}
