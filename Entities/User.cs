using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int Password { get; set; }

    public string? Email { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
