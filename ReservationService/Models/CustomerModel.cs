using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Models;

public class CustomerModel
{
    [Key]
    public string? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

}