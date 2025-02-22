using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model;

[Keyless]
[Table("City")]
public partial class City
{
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int Population { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
}
