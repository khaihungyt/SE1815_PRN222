using System;
using System.Collections.Generic;

namespace RestaurantBusiness;

public partial class Table
{
    public int Id { get; set; }

    public int TableNumber { get; set; }

    public int? Seats { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
