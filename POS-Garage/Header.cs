
using System;

class Header
{
    private int numInvoice;
    private DateTime date;
    private Customer customer;

    public Header(int numInvoice, DateTime date, Customer customer)
    {
        this.numInvoice = numInvoice;
        this.date = date;
        this.customer = customer;
    }


    public DateTime GetDate()
    {
        return date;
    }
    public void SetDate(DateTime date)
    {
        this.date = date;
    }

    public Customer GetCustomer()
    {
        return customer;
    }
    public void SetCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public int GetNumInvoice()
    {
        return numInvoice;
    }
    public void SetNumInvoice(int numInvoice)
    {
        this.numInvoice = numInvoice;
    }
}