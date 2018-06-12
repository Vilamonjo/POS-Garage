# Garage POS

## Version 02: Classes Customer and ListOfCustomers

Instead of the "struct" that represents the data of a customer, you must 
create a class "Customer", which will contain the same attributes as 
well as a alphanumeric code (which will behave as a "primary key"), the 
Getters and Setters for those attributes, and (only) a constructor to 
set all the attributes. The getters and setters can follow the classic 
style, or be C # properties.

In addition, you must create a class "ListOfCustomers", which can still 
be internally an array of customers (so that you do not need to change 
too much the structure of the previous version) or a list of customers, 
if you prefer (if you choose to keep the array, you will have to change 
it to a list in a later version). To mimic the functionality of the 
previous version, this class will have a method "Get(n)", which will 
return the customer that is in a certain position, a property "Amount" 
to return the number of existing customer and a method "Add(client)" to 
add a client to the end of the existing data structure.

The main class will now be called GarageManager, and it will be inside a file
named GarageManager.cs.

The behaviour of the application must be exactly the same as that of 
the first version, so the class "ListOfCustomers" should have a private 
method to load the data from file and another private method to 
save the data into the file. Also, the constructor for CustomerList  
must call the Load method and the Add method should call Save.

---

## Entrega 02: Clases Cliente y ListaDeClientes

En vez del "struct" que representa los datos de un cliente, deberás 
crear una clase "Customer", que contendrá esos mismos atributos además 
de un código alfanumérico (que hará la misma función que haría una 
"clave primaria"), los correspondientes Get/Set y un (único) 
constructor que dé valor a todos los atributos. Los getters y setters 
pueden seguir el estilo clásico, o bien ser propiedades de C#.

Además, deberás crear una clase "ListOfCustomers", que todavía puede 
ser internamente un array de clientes (para no cambiar mucho la 
estructura de la entrega anterior) o bien una lista de clientes, 
preferible (si no lo cambias a lista ahora, tendrás que hacerlo en una 
entrega posterior). Para poder imitar la funcionalidad de la versión 
anterior, esta clase tendrá un método "Get(n)", que devuelva el cliente 
que hay en una cierta posición, una propiedad "Amount" que devuelva la 
cantidad de clientes existentes y un método "Add(cliente)" que añada un 
cliente al final de la estructura de datos existente.

La clase principal ahora se llamará GarageManager, y estará dentro de un 
fichero llamado GarageManager.cs.

El funcionamiento de la aplicación deberá ser exactamente igual que el 
de la primera version, para lo que la clase "ListaDeClientes" deberá 
tener un método privado para cargar los datos desde fichero y otro 
método privado para guardar los datos en fichero, y además el 
constructor de ListaDeClientes deberá llamar al método Load y el método 
Add deberá llamar a Save.
