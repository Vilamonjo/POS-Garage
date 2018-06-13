# Garage POS

## Version 03: Customers Management

The third version must implement most of the remaining functionalities related 
to clients:

- Option 3 will allow the user to jump to the record that has a certain number 
(for example, a 2 to jump to the second).

- Option 4 will look for the following record (starting with the current one, 
not included) containing a certain text entered by the user (case insensitive). 
If it finds a match, it will show the record and display in yellow text "Found 
on the record XXX". If it reaches the end and does not find it, the text "Not 
found. Do you want to search from the first record?" will be displayed in red. 
If the user presses "S", a new search will be performed starting from the first 
record, or the search will be interrupted if another key is pressed.

- Option 5, after adding a new data, will sort the existing data by name.

- Option 6 will allow to modify all the data of the record that is being
sown (you can press Enter to keep the data that you do not want to modify,
instead of needing to retype them).

- Option B/D ("borrar", "delete") will ask the user if they want to delete the 
current record (Y/N). If "Y" is chosen, the current record will be marked as 
deleted, but it will not be will physically removed from the data structure.

- The options "Listings" and "Help" will be added later.


## Entrega 03: Gestión de clientes

La tercera entrega debe implementar la mayoría de funcionalidades restantes relativas a clientes:

- La opción 3 permitirá saltar a la ficha que tenga un cierto número (por ejemplo, un 2 para saltar a la segunda).

- La opción 4 buscará la siguiente ficha (a partir de la actual, no incluida) 
que contenga un cierto texto introducido por el usuario (independientemente de 
mayúsculas y minúsculas). Si encuentra una ficha, la mostrará y aparecerá en 
color amarillo el texto "Encontrado en la ficha XXX". Si llega al final sin 
encontrarla, aparecerá en color rojo el texto "No encontrado. ¿Desea buscar 
desde el principio?" Si se pulsa "S", se realizará una nueva búsqueda desde la 
primera ficha, o se interrumpirá si se pulsa otra tecla.

- La opción 5, después de añadir un nuevo dato, ordenará los datos existentes
por nombre.

- La opción 6 permitirá modificar todos los datos de la ficha que se está
visualizando (se podrá pulsar Intro para conservar los que no se quieran modificar,
en vez de necesitar teclearlos nuevamente).

- La opción B pedirá confirmación sobre si se desea borrar la ficha actual (S/N).
Si se escoge "S", la ficha actual quedará marcada como borrada, pero no se 
eliminará físicamente de la estructura de datos.

- La opción de "Listados" y la de "Ayuda" se realizarán más adelante.
