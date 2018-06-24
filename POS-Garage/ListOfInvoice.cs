
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ListOfInvoice
{
    private List<Invoice> myInvoices;

    public int Amount { get { return myInvoices.Count; } } 

    public ListOfInvoice()
    {
        myInvoices = new List<Invoice>();
    }

    public Invoice Get(int position)
    {
        return myInvoices.ElementAt(position);
    }

    public void Add(Customer c)
    {
        Invoice.invoiceCount++;
        myInvoices.Add(new Invoice(c));
    }


    public void Load(ListOfCustomers customers, ListOfProducts products)
    {
        DirectoryInfo d = new DirectoryInfo("invoices/");

        foreach(FileInfo f in d.GetFiles("*.dat"))
        {
            StreamReader invoicesInput = new StreamReader(f.FullName);
            string line;
            string[] invoicessAux;
            int invoiceMax = 1;
            try
            {
                do
                {
                    line = invoicesInput.ReadLine();
                    if (line != null)
                    {
                        invoicessAux = line.Split(';');

                        int invoiceNumber = Int32.Parse(invoicessAux[0]);
                        if (invoiceNumber > invoiceMax)
                            invoiceMax = invoiceNumber;
                        Invoice.invoiceCount = invoiceMax;

                        string[] dateAux = invoicessAux[1].Split('/');

                        DateTime date = new DateTime(Int32.Parse(dateAux[2]),
                                                     Int32.Parse(dateAux[1]),
                                                     Int32.Parse(dateAux[0]));
                        string key = invoicessAux[2];

                        int countCustomers = 0;
                        bool found = false;
                        do
                        {
                            if (key == customers.Get(countCustomers).GetKey())
                            {
                                found = true;
                                countCustomers--;
                            }

                            countCustomers++;
                        }
                        while (countCustomers < customers.Amount && !found);

                        myInvoices.Add(new Invoice(invoiceNumber, date,
                            customers.Get(countCustomers)));
                        Product p;
                        string code;
                        double price;
                        int amount;
                        int countProduct;
                        if (invoicessAux.Length > 3)
                            for (int i = 3; i < invoicessAux.Length; i += 3)
                            //We start at 1, to not get out of the array size
                            {
                                countProduct = 0;
                                found = false;
                                code = invoicessAux[i];
                                do
                                {
                                    if (code == products.Get(countProduct).GetCode())
                                    {
                                        found = true;
                                        countProduct--;
                                    }

                                    countProduct++;
                                }
                                while (countProduct < products.Amount && !found);
                                p = products.Get(countProduct);
                                amount = Int32.Parse(invoicessAux[i + 1]);
                                price = Double.Parse(invoicessAux[i + 2]);

                                myInvoices.Last().AddLine(p, amount, price);
                            }
                    }
                }
                while (line != null);
                invoicesInput.Close();
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

    public void Save()
    {
        foreach(Invoice i in myInvoices)
        {
            i.Save();
        }
    }

    public void ExportHeadersCSV()
    {
        StreamWriter invoicesOutput = new StreamWriter("csv/headers.csv");
        try
        {
            invoicesOutput.WriteLine("NUMBER;DATE;CUSTOMER;TOTAL"); 
            foreach(Invoice i in myInvoices)
            {
                Header h = i.GetHeader();
                invoicesOutput.WriteLine("\"" + h.GetNumInvoice() + "\"" + ";" 
                    + "\"" + h.GetDate().Day.ToString("00") + "/" +
                    h.GetDate().Month.ToString("00") + "/" +
                    h.GetDate().Year.ToString("0000") + "\"" + ";" 
                    + "\"" + h.GetCustomer().GetName() + "\"" + ";" 
                    + "\"" + i.CalculateTotal().ToString() + "\"");
            }
            invoicesOutput.Close();
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

    public void ExportLinesCSV()
    {
        StreamWriter invoicesOutput = new StreamWriter("csv/lines.csv");
        int count = 1; //To Have control of the number of line
        try
        {
            invoicesOutput.WriteLine("INVOICE;DATE;NUMBER;DESCRIPTION;AMOUNT;PRICE;TOTAL");
            foreach (Invoice i in myInvoices)
            {
                count = 1;
                List<Line> list = i.GetLines();
                foreach(Line l in list)
                {
                    invoicesOutput.WriteLine("\"" + i.GetHeader().GetNumInvoice().ToString() + "\"" + ";"
                       + "\"" + i.GetHeader().GetDate().Day.ToString("00") + "/" +
                        i.GetHeader().GetDate().Month.ToString("00") + "/" +
                        i.GetHeader().GetDate().Year.ToString("0000") + "\"" + ";"
                        + "\"" + count.ToString() + "\"" + ";"
                        + "\"" + l.GetProduct().GetDescription() + "\"" + ";" 
                        + "\"" + l.GetAmount() + "\"" + ";"
                        + "\"" + l.GetPrice().ToString() + "\"" + ";" + "\"" +
                        (l.GetPrice() * l.GetAmount()).ToString() + "\"" );
                    count++;
                }
            }
            invoicesOutput.Close();
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