using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ListOfProducts
{
    private List<Product> myProducts;

    public int Amount { get { return myProducts.Count; } }

    public ListOfProducts()
    {
        myProducts = new List<Product>();
        Load();
    }

    public Product Get(int position)
    {
        return myProducts.ElementAt(position);
    }

    public void Add(Product productToAdd)
    {
        myProducts.Add(productToAdd);
        Sort();
        Save();
    }

    private List<Product> Sort()
    {
        return myProducts = myProducts.OrderBy(product => product.GetCode())
                    .ThenBy(product => product.GetDescription()).ToList();
    }

    private void Load()
    {
        if (File.Exists("products.txt"))
        {
            StreamReader productsInput = new StreamReader("products.txt");
            string line;
            string[] productsAux;
            try
            {
                do
                {
                    line = productsInput.ReadLine();
                    if (line != null)
                    {
                        productsAux = line.Split(';');
                        myProducts.Add(new Product(productsAux[0],
                            productsAux[1], productsAux[2],
                            Double.Parse(productsAux[3]),
                            Double.Parse(productsAux[4]),
                            UInt32.Parse(productsAux[5]),
                            UInt32.Parse(productsAux[6])
                           ));
                    }
                }
                while (line != null);

                productsInput.Close();

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
        StreamWriter productsOutput = new StreamWriter("products.txt", false);
        try
        {
            foreach (Product p in myProducts)
            {
                productsOutput.WriteLine(
                    p.GetCode() + ";" + p.GetDescription() + ";" + p.GetCategory() + ";" +
                    p.GetSellPrice() + ";" + p.GetBuyPrice() + ";" +
                    p.GetStock() + ";" + p.GetMinStock());
            }
            productsOutput.Close();
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