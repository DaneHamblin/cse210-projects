public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public double GetDistanceValue()
    {
        return _distance;
    }

    public void SetDistanceValue(double distance)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        double speed = (_distance / GetLengthInMinutes()) * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetLengthInMinutes() / _distance;
        return pace;
    }
}