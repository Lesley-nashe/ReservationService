using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Models;

public class ReservationResponseModel
{
    [Key]
    public string? ReservationId { get; set; }

    public string? Status { get; set; }

    public string? TableId { get; set; }

    public string? WaitlistMessage { get; set; }

}