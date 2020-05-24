class User
{
    public string name;
    public string id;
    public string email;

    public User(string name, string id, string email)
    {
        this.name = name;
        this.id = id;
        this.email = email;
    }

    public User(string name, string id)
    {
        this.name = name;
        this.id = id;
    }
}
