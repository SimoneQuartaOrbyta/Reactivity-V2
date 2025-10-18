using System;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Activity
{
    //Nei casi standard qualsiasi proprieta id viene usate come chiave primaria
    //ma possiamo usare anche altri nomi usando [Key]
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required  string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsCancelled { get; set; }

    //location props
    public string City { get; set; }
    public string Venue { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
