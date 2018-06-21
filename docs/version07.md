# Garage POS

## Version 07 : 07: Invoices and lines, first approach.

Each invoice will consist of two parts: a "header" and several "lines".

In the "header" we will store the invoice number, the date and the customer
(when dumping to file, only the ID of the customer will be saved).

In each line of the invoice, we will store a product or service, along with the 
amount that has been purchased from that item and its unit price (so that the 
invoice is recalculated correctly, even if the price of the article changes 
later). Again, when dumping to file, not all the data of each article will be 
saved, but only its code (and its current price).

In this first approach, you must create an class Invoice with those features, a 
class ListOfInvoices, and a class InvoiceManager (and maybe some other 
additional class you might need to store the invoice lines).

The user must be able to enter invoices consisting of one or several lines, and 
these invoices will be saved and loaded, as well as displayed (but more 
advanced options, such as Edit or Search will still not be available).


---

## Entrega 07: Facturas y líneas, primera aproximación

Cada factura estará formado por dos partes: una "cabecera" y varias "líneas".

En la "cabecera" se guardará el número de la factura, la fecha y el cliente
para el que es la factura (que al volcar a fichero se reflejará sólo como su
código, no todos los datos).

En cada línea de la factura se almacenará un producto o servicio, junto con la 
cantidad que se ha comprado de ese artículo y su precio unitario (para que la 
factura se recalcule de forma correcta, incluso si cambia el precio del 
artículo posteriormente). Nuevamente, al volcar a fichero no se guardarán todos 
los datos de cada artículo, sino sólo su código (y su precio actual).

En esta primera aproximación, se creará una clase Invoice (Factura) con esas 
características, una clase ListOfInvoices y una clase InvoiceManager (y 
quizá alguna otra clase adicional para almacenar las líneas de facturas).

El usuario deberá poder introducir facturas formadas por una o varias líneas, y 
dichas facturas se guardarán y cargarán, además de poderse visualizar (pero 
opciones más avanzadas, como Editar o Buscar todavía no estarán disponibles).
