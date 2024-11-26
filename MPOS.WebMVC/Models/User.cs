using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPOS.WebMVC.Models;

public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public int? UserTypeId { get; set; }

    public int? EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte Status { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
	public string? Photo { get; set; }

	public virtual Employee? Employee { get; set; }

    public virtual UserType? UserType { get; set; }
	[NotMapped]
	public IFormFile? IPhoto { get; set; }
}
