using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Models;

[Table("orders")]
[Index("CustomerId", Name = "customer_id")]
[Index("CustomerId", Name = "customers_orders")]
[Index("EmployeeId", Name = "employee_id")]
[Index("EmployeeId", Name = "employees_orders")]
[Index("OrderDate", Name = "order_date")]
[Index("ShipPostalCode", Name = "ship_postal_code")]
[Index("ShippedDate", Name = "shipped_date")]
[Index("ShipVia", Name = "shippers_orders")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("customer_id")]
    [StringLength(5)]
    public string? CustomerId { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [Column("order_date", TypeName = "datetime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [Display(Name = "Ordered")]
    public DateTime? OrderDate { get; set; }

    [Column("required_date", TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("shipped_date", TypeName = "datetime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [Display(Name = "Shipped")]
    public DateTime? ShippedDate { get; set; }

    [Column("ship_via")]
    public int? ShipVia { get; set; }

    [Column("freight", TypeName = "money")]
    [Display(Name = "Freight")]
    public decimal? Freight { get; set; }

    [Column("ship_name")]
    [Display(Name = "Ship Name")]
    [StringLength(40)]
    public string? ShipName { get; set; }

    [Column("ship_address")]
    [StringLength(60)]
    public string? ShipAddress { get; set; }

    [Column("ship_city")]
    [StringLength(15)]
    public string? ShipCity { get; set; }

    [Column("ship_region")]
    [Display(Name = "Region")]
    [StringLength(15)]
    public string? ShipRegion { get; set; }

    [Column("ship_postal_code")]
    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [Column("ship_country")]
    [Display(Name = "Country")]
    [StringLength(15)]
    public string? ShipCountry { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Orders")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("ShipVia")]
    [InverseProperty("Orders")]
    public virtual Shipper? ShipViaNavigation { get; set; }
}
