using System;
using System.Collections.Generic;



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
    
}
