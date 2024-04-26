using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Models;

[Table("employees")]
[Index("LastName", Name = "last_name")]
[Index("PostalCode", Name = "postal_code")]
public partial class Employee
{
    [Key]
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("last_name")]
    [Display(Name = "Last Name")]
    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [Column("first_name")]
    [Display(Name = "First Name")]
    [StringLength(10)]
    public string FirstName { get; set; } = null!;

    [Column("title")]
    [Display(Name = "Title")]
    [StringLength(30)]
    public string? Title { get; set; }

    [Column("title_of_courtesy")]
    [Display(Name = "Title of Courtesy")]
    [StringLength(25)]
    public string? TitleOfCourtesy { get; set; }

    [Column("birth_date", TypeName = "datetime")]
    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime? BirthDate { get; set; }

    [Column("hire_date", TypeName = "datetime")]
    [Display(Name = "Hire Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime? HireDate { get; set; }

    [Column("address")]
    [Display(Name = "Address")]
    [StringLength(60)]
    public string? Address { get; set; }

    [Column("city")]
    [Display(Name = "City")]
    [StringLength(15)]
    public string? City { get; set; }

    [Column("region")]
    [Display(Name = "Region")]
    [StringLength(15)]
    public string? Region { get; set; }

    [Column("postal_code")]
    [Display(Name = "Postal Code")]
    [StringLength(10)]
    public string? PostalCode { get; set; }

    [Column("country")]
    [Display(Name = "Country")]
    [StringLength(15)]
    public string? Country { get; set; }

    [Column("home_phone")]
    [Display(Name = "Home Phone")]
    [StringLength(24)]
    public string? HomePhone { get; set; }

    [Column("extension")]
    [Display(Name = "Extension")]
    [StringLength(4)]
    public string? Extension { get; set; }

    [Column("notes")]
    [Display(Name = "Notes")]
    [StringLength(500)]
    public string? Notes { get; set; }

    [Column("reports_to")]
    [Display(Name = "Reports To")]
    public int? ReportsTo { get; set; }

    [Column("photo_path")]
    [Display(Name = "Photo")]
    [StringLength(255)]
    public string? PhotoPath { get; set; }

    [InverseProperty("ReportsToNavigation")]
    public virtual ICollection<Employee> InverseReportsToNavigation { get; } = new List<Employee>();

    [InverseProperty("Employee")]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
     
    [ForeignKey("ReportsTo")]
    [Display(Name = "Reports To")]
    [InverseProperty("InverseReportsToNavigation")]
    public virtual Employee? ReportsToNavigation { get; set; }
}
