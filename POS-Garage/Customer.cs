
public class Customer
{
    //ATRIBUTES & CONSTRUCTOR--------------------------------------------------

    protected string key;
    protected string name;
    protected string iD;
    protected string residence;
    protected string city;
    protected string postalCode;
    protected string country;
    protected uint phoneNumber;
    protected string eMail;
    protected string contact;
    protected string comments;

    public Customer(string name, string iD, string residence, string city,
                    string postalCode, string country, uint phoneNumber,
                    string eMail, string contact, string comments)
    {
        this.name = name;
        this.iD = iD;
        this.residence = residence;
        this.city = city;
        this.postalCode = postalCode;
        this.country = country;
        this.phoneNumber = phoneNumber;
        this.eMail = eMail;
        this.contact = contact;
        this.comments = comments;
        key = CreateKey();
    }
        
    //GET-SET------------------------------------------------------------------

    public void SetKey(string key)
    {
        this.key = key;
    }
    public string GetKey()
    {
        return key;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return name;
    }

    public void SetID(string iD)
    {
        this.iD = iD;
    }
    public string GetID()
    {
        return iD;
    }

    public void SetResidence(string residence)
    {
        this.residence = residence;
    }
    public string GetResidence()
    {
        return residence;
    }

    public void SetCity(string city)
    {
        this.city = city;
    }
    public string GetCity()
    {
        return city;
    }

    public void SetPostalCode(string postalCode)
    {
        this.postalCode = postalCode;
    }
    public string GetPostalCode()
    {
        return postalCode;
    }

    public void SetCountry(string country)
    {
        this.country = country;
    }
    public string GetCountry()
    {
        return country;
    }

    public void SetPhoneNumber(uint phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public uint GetPhoneNumber()
    {
        return phoneNumber;
    }

    public void SetEMail(string eMail)
    {
        this.eMail = eMail;
    }
    public string GetEMail()
    {
        return eMail;
    }

    public void SetContact(string contact)
    {
        this.contact = contact;
    }
    public string GetContact()
    {
        return contact;
    }

    public void SetComments(string comments)
    {
        this.comments = comments;
    }
    public string GetComments()
    {
        return comments;
    }

    //FUNCTIONS----------------------------------------------------------------

    private string CreateKey()
    {
        string[] nameAux = name.Split(' ');
        string key = "";
        for(int i = 0; i < nameAux.Length; i++)
        {
            key += nameAux[i].Substring(0, 3);
        }
        return key;
    }

    public override string ToString()
    {
        return      "KEY: " + GetKey() + "\n" +
                    "Name: " + GetName() + "\n" +
                    "ID: " + GetID() + "\n" +
                    "Residence: " + GetResidence() + "\n" +
                    "City: " + GetCity() + "\n" +
                    "Postal Code: " + GetPostalCode() + "\n" +
                    "Country: " + GetCountry() + "\n" +
                    "Phone Number: " + GetPhoneNumber() + "\n" +
                    "Email: " + GetEMail() + "\n" +
                    "Contact: " + GetContact() + "\n" +
                    "comments: " + GetComments(); 
    }

}

