using Domain.Enums;

namespace Application.DTOs;

public class UserAuthDTO
{
    public string UserName { get; set; }
    public string HashPassword { get; set; }
    public ELevelUser LevelUser { get; set; }
}
