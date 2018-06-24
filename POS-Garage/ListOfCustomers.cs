using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ListOfCustomers
{
    //ATRIIBUTES,PROPERTIES, CONSTRUCTOR --------------------------------------

    protected List<Customer> myCustomers;

    public int Amount { get { return myCustomers.Count; } }

    public ListOfCustomers()
    {
        myCustomers = new List<Customer>();
        Load();
    }
    
    //FUNCTIONS----------------------------------------------------------------

    public Customer Get(int position)
    {
        return myCustomers.ElementAt(position);
    }

    public void Add(Customer customerToAdd)
    {
        myCustomers.Add(customerToAdd);
        Sort();
        Save();
    }

    private List<Customer> Sort()
    {
        return myCustomers = myCustomers.OrderBy(customer => customer.GetName())
                    .ThenBy(customer => customer.GetID()).ToList();
    }

    private void Load()
    {
        if (File.Exists("customers.txt"))
        {
            StreamReader customersInput = new StreamReader("customers.txt");
            string line;
            string[] customersAux;
            try
            {
                do
                {
                    line = customersInput.ReadLine();
                    if (line != null)
                    {
                        customersAux = line.Split(';');
                        myCustomers.Add(new Customer(
                            customersAux[1], customersAux[2],
                            customersAux[3], customersAux[4], customersAux[5],
                            customersAux[6], UInt32.Parse ( customersAux[7] ), 
                            customersAux[8], customersAux[9], customersAux[10],
                            Convert.ToBoolean( customersAux[11]) ) );
                    }
                }
                while (line != null);

                customersInput.Close();
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
        else
        {
            Console.WriteLine("The file does not exist");
        }
    }

    private void Save()
    {
        StreamWriter customersOutput = new StreamWriter("customers.txt", false);
        try
        {
            foreach(Customer c in myCustomers)
            {
                customersOutput.WriteLine(
                    c.GetKey()+";"+c.GetName() + ";" + c.GetID() + ";" +
                    c.GetResidence() + ";" + c.GetCity()+ ";" +
                    c.GetPostalCode() + ";" + c.GetCountry()+ ";" +
                    c.GetPhoneNumber() + ";" + c.GetEMail() + ";" +
                    c.GetContact() + ";" + c.GetComments() + ";" +c.GetDeleted());
            }
            customersOutput.Close();
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

    public void ConvertToCSV()
    {
        StreamWriter customersOutput = new StreamWriter("csv/customers.csv", false);
        try
        {
            customersOutput.WriteLine("KEY;NAME;ID;RESIDENCE;CITY;POSTAL_CODE" +
                "COUNTRY;PHONE;EMAIL;CONTACT;COMMENTS");
            foreach (Customer c in myCustomers)
            {
                customersOutput.WriteLine(
                    c.GetKey() + ";" + c.GetName() + ";" + c.GetID() + ";" +
                    c.GetResidence() + ";" + c.GetCity() + ";" +
                    c.GetPostalCode() + ";" + c.GetCountry() + ";" +
                    c.GetPhoneNumber() + ";" + c.GetEMail() + ";" +
                    c.GetContact() + ";" + c.GetComments());
            }
            customersOutput.Close();
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