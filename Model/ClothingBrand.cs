using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model;

[Table("clothingBrand")]
public partial class ClothingBrand
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Location { get; set; } = null!;

    [InverseProperty("Store")]
    public virtual ICollection<ClothingItem> ClothingItems { get; set; } = new List<ClothingItem>();
}
