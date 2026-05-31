namespace Tienda.Core;

public interface IClock
{
    DateTime UtcNow { get; }
}

public class FakeClock : IClock
{
    public DateTime UtcNow { get; set; }
}

public class PromocionService
{
    private readonly IClock _clock;

    public PromocionService(IClock clock)
    {
        _clock = clock;
    }

    public bool EstaActiva()
    {
        return _clock.UtcNow.DayOfWeek is DayOfWeek.Friday;
    }
}
