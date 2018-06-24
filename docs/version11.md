# Garage POS

## Version 11: Editing invoices and exporting CSV

The invoices module must allow to modify an invoice. It will ask the user if 
they want to edit the header or a line and, if it is a line, the line number to 
be modified.

The bottom line of Customer Management should add, after the option 
"7-Listings" a new option "A-Advanced", which will show a new screen, that will 
only have the option "Export to CSV". This option will dump to a file named 
"customers.csv" all the data of each client, between quotation marks and 
separated by semicolons, in the order in which they had been defined.

The same functionality must be added to Product Management.

In Invoice Management you can choose between "Export invoice headers" or 
"Export invoice details". The first option will dump number, date, customer 
name and total amount of each invoice. The second option will dump all lines of 
all invoices, detailing: invoice number, date, line number (in that invoice), 
product description, amount, unit amount, total amount.


---

## Entrega 11: Modificación de facturas y exportación CSV

El módulo de facturas debe permitir modificar una factura. Se preguntará si
cabecera o líneas y, en caso de ser una línea, el número de línea a modificar.

La línea inferior de la Gestión de Clientes debe añadir, tras la opción 
"7-Listings" ("7-Listados") una nueva opción "A-Advanced" ("A-Avanzado"), que 
mostrará una nueva pantalla, que por ahora sólo tendrá la opción "Export to 
CSV" ("Exportar a CSV"). Esta opción volcará a un fichero "customers.csv" todos 
los datos de cada cliente, entre comillas y separados por punto y coma, en el 
orden en el que se habían definido.

Se deberá añadir la misma funcionalidad a la Gestión de Productos.

En la Gestión de Facturas se podrá elegir entre "Exportar cabeceras de facturas"
o "Exportar detalles de facturas". La primera opción volcará número, fecha,
nombre de cliente e importe total de cada factura. La segunda opción volcará 
todas las líneas de todas las facturas, detallando: número de factura,
fecha, número de línea dentro de esa factura, descripción del producto,
cantidad, importe unitario, importe total.
