public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_METERS = 50;
    private const double METERS_PER_MILE = 1609.34;

    public Swimming(string date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public int GetLaps()
    {
        return _laps;
    }

    public void SetLaps(int laps)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceInMiles = (_laps * LAP_LENGTH_METERS) / METERS_PER_MILE;
        return distanceInMiles;
    }

    public override double GetSpeed()
    {
        double speed = (GetDistance() / GetLengthInMinutes()) * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetLengthInMinutes() / GetDistance();
        return pace;
    }
}