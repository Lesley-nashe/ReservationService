using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Models;

public class ReservationRequestModel
{
    [Key]
    public string? TableId { get; set; }

    public string? CustomerId { get; set; }

    public string? ReservationType { get; set; }

    public List<string> Preferences { get; set; } = new();

}