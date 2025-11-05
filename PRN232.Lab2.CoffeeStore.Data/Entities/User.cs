using System;
using System.Collections.Generic;

namespace PRN232.Lab2.CoffeeStore.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
