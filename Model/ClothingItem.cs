using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model;

[Table("clothingItems")]
public partial class ClothingItem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("StoreID")]
    public int StoreId { get; set; }

    [Column("tops")]
    [StringLength(50)]
    [Unicode(false)]
    public string Tops { get; set; } = null!;

    [Column("pants")]
    [StringLength(50)]
    [Unicode(false)]
    public string Pants { get; set; } = null!;

    [Column("outerwear")]
    [StringLength(50)]
    [Unicode(false)]
    public string Outerwear { get; set; } = null!;

    [Column("shoes")]
    [StringLength(50)]
    [Unicode(false)]
    public string Shoes { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [ForeignKey("StoreId")]
    [InverseProperty("ClothingItems")]
    public virtual ClothingBrand Store { get; set; } = null!;
}
