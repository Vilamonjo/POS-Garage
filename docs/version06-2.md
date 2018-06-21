# Garage POS

## Version 06: Classes structure

This version should extend the basic class structure of the project and create 
the product management module:

- The GarageManager class will become the CustomerManager class. The 
GarageManager class will now have a single "Run" method, which will show a main 
menu with 4 options:

```
1. Invoice management
2. Customer management
3. Product management
0. Exit
```

- If the user chooses option 2 in the main menu, an object of the 
CustomerManager class will be created, and its Run method will be called, which 
will do what the "Main" of the previous version was.

- The new Main of the application will be in the GarageManager class, and will 
simply create an object of the class GarageManager and call the Run method.

- There will be a class ProductManager, as well as classes Product (for 
products and services) and ListOfProducts, so if the user chooses option 3 in 
the main menu, an object of the ProductManager class will be created, and his 
Run method will be called , which will behave in a similar way as 
CustomerManager does.

For each product you must store: code, description, category, sell 
price, purchase price, current stock, minimum desired stock.

- There will be a BillManager class, so if the user chooses the option 3 in the 
main menu, an object of this class will be created, and its method Run will be 
called. It will only display the text "(Soon available)" and will wait for the 
user to press a key to return to the main menu.

- The rest of the classes related to the creation and management of invoices 
are postponed for a next version.


---


## Entrega 06: Estructura de clases

Esta entrega debe ampliar la estructura de clases básica del proyecto y crear 
el módulo de gestión de productos:

- Lo que hasta ahora era el contenido de la clase GarageManager pasará a ser la 
clase CustomerManager. La clase GarageManager pasará a tener un único método 
"Run", que mostrará un menú principal con 4 opciones:

```
1. Gestión de facturas
2. Gestión de clientes
3. Gestión de productos
0. Salir
```

(o su equivalente en inglés).

- Si el usuario escoge la opción 2 en el menú principal, se creará un objeto de 
la clase CustomerManager, y se llamará a su método Run, que corresponderá a lo 
que era el "Main" de la entrega anterior.

- El nuevo Main de la aplicación estará en la clase GarageManager, y se 
limitará a crear un objeto de la clase GarageManager y llamar al método Run.

- Existirá una clase ProductManager, así como clases Product (para productos y 
servicios) y ListOfProducts, de modo que si el usuario escoge la opción 3 en el 
menú principal, se creará un objeto de la clase ProductManager, y se llamará a 
su método Run, que se comportará de forma similar a como hace CustomerManager.

De cada producto se deberá guardar: código, descripción, categoría, precio de 
venta, precio de compra, stock (cantidad en almacén), stock mínimo deseado.

- Existirá una clase BillManager, de modo que si el usuario escoge la opción 3 
en el menú principal, se creará un objeto de esta clase, y se llamará a su 
método Run, que sólo mostrará el texto "(Soon available)" y esperará a que el 
usuario pulse una tecla para volver al menú principal.

- El resto de clases relacionadas con la creación y gestión de facturas quedan 
para una entrega próxima. 
