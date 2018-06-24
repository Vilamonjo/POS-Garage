
class Line
{
    private Product product;
    private int amount;
    private double price;

    public Line(Product product, int amount, double price)
    {
        this.product = product;
        this.amount = amount;
        this.price = price;
    }

    public void SetProduct(Product product)
    {
        this.product = product;
    }
    public Product GetProduct()
    {
        return product;
    }

    public void SetAmount(int amount)
    {
        this.amount = amount;
    }
    public int GetAmount()
    {
        return amount;
    }

    public void SetPrice(double price)
    { 
        this.price = price;
    }
    public double GetPrice()
    {
        return price;
    }
}