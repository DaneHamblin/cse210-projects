public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;
    private string _zipCode;

    public Address(string street, string city, string stateOrProvince, string country, string zipCode)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
        _zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince} {_zipCode}\n{_country}";
    }

    public string GetStreet()
    {
        return _street;
    }

    public string GetCity()
    {
        return _city;
    }

    public string GetStateOrProvince()
    {
        return _stateOrProvince;
    }

    public string GetCountry()
    {
        return _country;
    }

    public string GetZipCode()
    {
        return _zipCode;
    }
}