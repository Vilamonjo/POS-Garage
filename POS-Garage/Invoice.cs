using System;
using System.Collections.Generic;
using System.IO;


class Invoice
{
    private Header header;
    private List<Line> lines;

    public static int invoiceCount = 1;

    public Invoice(Customer customer)
    {
        header = new Header(
            invoiceCount, DateTime.Now, customer);
        lines = new List<Line>();
    }
    public Invoice(int count, DateTime date, Customer customer)
    {
        header = new Header(
            count, date, customer);
        lines = new List<Line>();
    }

    public Header GetHeader()
    {
        return header;
    }
    public List<Line> GetLines()
    {
        return lines;
    }

    public void AddLine(Product product, int amount, double price)
    {
        lines.Add(new Line(product, amount, price));
    }

    public void Save()
    {
        StreamWriter invoicesOutput;
        try
        {
            invoicesOutput = new StreamWriter("invoices/invoice-"+
            header.GetDate().Year.ToString("0000")+"-"+
            header.GetNumInvoice().ToString() +".dat", false);
  

                invoicesOutput.Write(
                    GetHeader().GetNumInvoice() + ";" +
                    GetHeader().GetDate().Day + "/" +
                    GetHeader().GetDate().Month + "/" +
                    GetHeader().GetDate().Year + ";" +
                    GetHeader().GetCustomer().GetKey()
                    );
                foreach (Line l in GetLines())
                {
                    invoicesOutput.Write(
                        ";" + l.GetProduct().GetCode() +
                        ";" + l.GetAmount() +
                        ";" + l.GetPrice());
                }
                invoicesOutput.WriteLine();
            
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
