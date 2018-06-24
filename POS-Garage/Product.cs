
class Product
{
    //ATRIBUTES & CONSTRUCTOR--------------------------------------------------

    private string code;
    private string description;
    private string category;
    private double sellPrice;
    private double buyPrice;
    private uint stock;
    private uint minStock;

    public Product(string code, string description, string category,
            double sellPrice, double buyPrice, uint stock, uint minStock)
    {
        this.code = code;
        this.description = description;
        this.category = category;
        this.sellPrice = sellPrice;
        this.buyPrice = buyPrice;
        this.stock = stock;
        this.minStock = minStock;
    }

    //GET-SET------------------------------------------------------------------

    public string GetCode()
    {
        return code;
    }
    public void SetCode(string code)
    {
        this.code = code;
    }

    public string GetDescription()
    {
        return description;
    }
    public void SetDescription(string description)
    {
        this.description = description;
    }

    public string GetCategory()
    {
        return category;
    }
    public void SetCategory(string category)
    {
        this.category = category;
    }

    public double GetSellPrice()
    {
        return sellPrice;
    }
    public void SetSellPrice(double sellPrice)
    {
        this.sellPrice = sellPrice;
    }

    public double GetBuyPrice()
    {
        return buyPrice;
    }
    public void SetBuyPrice(double buyPrice)
    {
        this.buyPrice = buyPrice;
    }

    public uint GetStock()
    {
        return stock;
    }
    public void SetStock(uint stock)
    {
        this.stock = stock;
    }

    public uint GetMinStock()
    {
        return minStock;
    }
    public void SetMinStock(uint minStock)
    {
        this.minStock = minStock;
    }
}