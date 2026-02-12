using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApiExample.Models;

public partial class CoreApiEx
{
    [Key]
    public int? ExampleId { get; set; }
    [Required]
    public string? ProjectName { get; set; }
    [Required]
    [MaxLength(50)]
    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
