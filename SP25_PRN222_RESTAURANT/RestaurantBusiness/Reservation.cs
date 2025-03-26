using System;
using System.Collections.Generic;

namespace RestaurantBusiness;

public partial class Reservation
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TableId { get; set; }

    public DateTime? ReservationDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Table? Table { get; set; }

    public virtual User? User { get; set; }
}
