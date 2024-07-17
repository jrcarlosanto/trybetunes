namespace BackTrybeTunes.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    public string? TrackName { get; set; }
    public string? PreviewUrl { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public virtual User? User { get; set; }
}
