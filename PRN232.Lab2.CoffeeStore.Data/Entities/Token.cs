using System;
using System.Collections.Generic;

namespace PRN232.Lab2.CoffeeStore.Data.Entities;

public partial class Token
{
    public int Id { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenExpiryTime { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AccessToken { get; set; }

    public virtual User User { get; set; } = null!;
}
