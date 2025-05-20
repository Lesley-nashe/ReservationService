using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationService.Models;

public class Waitlist
{
    [Key]
    public string? TableId { get; set; }

    public List<CustomerInput> CustomerQueue { get; set; } = new();
}

public class CustomerInput
{
    [Key]
    public string? CustomerId { get; set; }

    public List<string> Preferences { get; set; } = new();

}

