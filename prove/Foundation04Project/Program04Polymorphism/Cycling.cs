public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public double GetSpeedValue()
    {
        return _speed;
    }

    public void SetSpeedValue(double speed)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        double distance = _speed * (GetLengthInMinutes() / 60.0);
        return distance;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        double pace = 60 / _speed;
        return pace;
    }
}