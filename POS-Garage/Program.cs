using System;
using System.IO;

public struct  Customer
{
    public string Name;
    public string ID;
    public string Residence;
    public string City;
    public ushort PostalCode;
    public string Country;
    public uint PhoneNumber;
    public string EMail;
    public string Contact;
    public string Observations;
}
class Program
{
    static void Main(string[] args)
    {
        ushort totalCustomers = 0;
        Customer[] allCustomers = LoadCustomers(out totalCustomers);

        DisplayMenuAnUsersControl(allCustomers, totalCustomers);    

    }

    public static void DisplayMenuAnUsersControl(Customer[] allCustomers, ushort totalCustomers)
    {
        bool exit = false;
        uint count = 0;
        do
        {
            ShowCustomer( allCustomers[count] );
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine("1.-Previus Customer      2.-Next Customer");
            Console.WriteLine("5.-Add Customer      0.-Exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    if (count != 0)
                        count--;
                    break;

                case "2":
                    //I cant allCustomers[count+1] != null
                    if (count != 999 && allCustomers[count + 1].Name != null)
                        count++;
                    break;

                case "5":
                    allCustomers[totalCustomers-1] = AddCustomer();
                    totalCustomers++;
                    break;

                case "0":
                    exit = true;
                    break;

            }
        } while (!exit);

        SaveCustomers(allCustomers, totalCustomers);

        
    }

    public static void ShowCustomer(Customer customer)
    {
        Console.SetCursorPosition(0, 4);
        Console.WriteLine("Name: "+customer.Name);
        Console.WriteLine("ID: " + customer.ID);
        Console.WriteLine("Residence: " + customer.Residence);
        Console.WriteLine("City: " + customer.City);
        Console.WriteLine("Postal Code: " + customer.PostalCode);
        Console.WriteLine("Country: " + customer.Country);
        Console.WriteLine("Phone Number: " + customer.PhoneNumber);
        Console.WriteLine("eMail: " + customer.EMail);
        Console.WriteLine("Contact: " + customer.Contact);
        Console.WriteLine("Observations: " + customer.Observations);
    }

    public static Customer AddCustomer()
    {

        Console.SetCursorPosition(4, 10);

        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("ID: ");
        string iD = Console.ReadLine();

        Console.WriteLine("Residence: ");
        string residence = Console.ReadLine();

        Console.WriteLine("City: ");
        string city = Console.ReadLine();

        Console.WriteLine("Postal Code: ");
        string postalCodeSTR;
        ushort postalCode;
        do
        {
            postalCodeSTR = Console.ReadLine();
        } while (UInt16.TryParse(postalCodeSTR, out postalCode));   

        Console.WriteLine("Country: ");
        string country = Console.ReadLine();

        Console.WriteLine("Phone Number: ");
        string phoneSTR;
        uint phone;
        do
        {
            phoneSTR = Console.ReadLine();
        } while (UInt32.TryParse(phoneSTR, out phone));

        Console.WriteLine("eMail: ");
        string eMail = Console.ReadLine();
        Console.WriteLine("Contact: ");
        string contact = Console.ReadLine();
        Console.WriteLine("Observations: ");
        string observation = Console.ReadLine();

        Customer customerToReturn = new Customer
        {
            Name = name,
            ID = iD,
            Residence = residence,
            City = city,
            PostalCode = postalCode,
            Country = country,
            PhoneNumber = phone,
            EMail = eMail,
            Contact = contact,
            Observations = observation
        };
        return customerToReturn;
    }

    public static Customer[] LoadCustomers(out ushort totalCustomers)
    {
        if(File.Exists("customers.txt"))
        {
            Customer[] arrayToReturn = new Customer[1000];
            StreamReader customersInput = new StreamReader("customers.txt");
            string line;
            totalCustomers = 0;
            bool end = false;
            try
            {
                while (totalCustomers < 1000 && !end)
                {
                    line = customersInput.ReadLine();
                    if (line != null)
                    {
                        string[] lineAux = line.Split(';');

                        arrayToReturn[totalCustomers] = new Customer
                        {
                            Name = lineAux[0],
                            ID = lineAux[1],
                            Residence = lineAux[2],
                            City = lineAux[3],
                            PostalCode = ushort.Parse(lineAux[4]),
                            Country = lineAux[5],
                            PhoneNumber = uint.Parse(lineAux[6]),
                            EMail = lineAux[7],
                            Contact = lineAux[8],
                            Observations = lineAux[9]
                        };

                        totalCustomers++;
                    }
                    else
                        end = true;
                }
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Error: Path Too Long.");
                throw;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found.");
                throw;
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O error: " + e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                throw;
            }

            customersInput.Close();
            return arrayToReturn;
        }
        else
        {
            Console.WriteLine("The file does not exist");
            totalCustomers = 0;
            return null;
        }    
    }

    public static void SaveCustomers(Customer[] arrayToSave, ushort totalCustomers)
    {
        StreamWriter customersOutput = new StreamWriter("customers.txt", false);
        try
        {
            for(ushort i =0; i < totalCustomers; i++)
            {
                customersOutput.WriteLine(
                    arrayToSave[i].Name + ";" + arrayToSave[i].ID + ";" +
                    arrayToSave[i].Residence + ";" + arrayToSave[i].City + ";" +
                    arrayToSave[i].PostalCode + ";" + arrayToSave[i].Country + ";" +
                    arrayToSave[i].PhoneNumber + ";" +arrayToSave[i].EMail + ";" + 
                    arrayToSave[i].Contact + ";" + arrayToSave[i].Observations);
            }
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Error: Path Too Long.");
            throw;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found.");
            throw;
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O error: " + e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            throw;
        }
    }
}

