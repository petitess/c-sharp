// return IEnumerable
public IEnumerable<User> GetUsers(IEnumerable<User> data)
{
    return data.Select(d => d);
}

public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
{
    return data.Select(d => d.ToUpper());
}
