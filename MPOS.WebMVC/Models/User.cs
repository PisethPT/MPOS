using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? UserTypeId { get; set; }

    public int? EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte Status { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual UserType? UserType { get; set; }
}
