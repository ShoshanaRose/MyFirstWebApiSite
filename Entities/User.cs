using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }
    [StringLength(15,ErrorMessage ="Your first name is too much long")]
    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    [EmailAddress]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
