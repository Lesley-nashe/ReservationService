using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableService.Models.Models;

public class TableModel
{
    [Key]
    public string? TableId { get; set; }

    public required int Capacity { get; set; }

    public string? Location { get; set; }

    public required bool Available { get; set; }

}