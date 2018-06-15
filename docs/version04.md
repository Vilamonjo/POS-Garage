# Garage POS

## Version 04: Enhanced Console

To simplify repetitive tasks, such as displaying texts in certain screen 
positions and with certain colors, or entering data by the user, we have 
decided to create an EnhancedConsole class, with static methods like:

    WriteAt (x, y, text, colour)

where the colour could be a text string with its full or abbreviated name,
as in WriteAt (35, 2, "Welcome", "blue")


We also want a method to ask the user for text, which could receive the 
coordinates and the maximum length, like this:

    string phoneNumber = GetAt(10, 4, 12);

which would show a gap of 12 columns in the coordinates (10, 4), such as this: 

    [------------]


A method to draw a "window" (simply a rectangle on the screen) with a certain 
background color, which can be used to display warnings:

    DrawWindow (x, y, width, height, colour);

It could have an overloaded version, to draw a window of preset size
(for example, width 40 and height 8), and even with preset colours:

    DrawWindow ("Do you want to continue? (Y/N)", "ye", "cy");
    
    DrawWindow ("Do you want to continue? (Y/N)");


You should also be able to write a text centered on a certain row: 

    WriteCentered (2, "Welcome", "blue")


And ask for a text that only accepts certain characters as an answer (for 
example, only one letter which must be Y or N): 

    string confirm = GetAt(10, 4, 1, "YN");


Or wait for a key, accepting only certain characters in response: 

    char option = WaitForKey("01234");


And ask for an integer between two limit values (for example, 1 to 99): 

    int age = GetIntegerAt (10, 4, 1, 99);


---

## Entrega 04: Consola Mejorada

Para simplificar tareas repetitivas, como la visualización de textos en ciertas 
posiciones de pantalla y con ciertos colores, o la introducción de datos por 
parte del usuario, se ha decidido crear una clase EnhancedConsole (Consola 
Mejorada), con métodos estáticos como:

    WriteAt (x, y, texto, color)

donde el color podría ser una cadena de texto con su nombre completo o abreviado, 
como en WriteAt (35, 2, "Bienvenido", "blue")


También se desea un método para pedir texto podría recibir las coordenadas y la 
longitud máxima, así: 

    string telefono = GetAt(10, 4, 12); 

qué mostraría en las coordenadas (10, 4) un hueco de 12 columnas de tamaño, por 
ejemplo así: 

    [------------]


Un método para dibujar una "ventana" (simplemente un rectángulo en pantalla) 
con cierto color de fondo, que se pueda usar para mostrar avisos:

    DrawWindow(x, y, ancho, alto, color); 

Podría tener una variante sobrecargada, que dibuje una ventana de tamaño prefijado
(por ejemplo, ancho 40 y alto 8) e incluso con color de texto prefijado:

    DrawWindow("¿Desea continuar? (S/N)", "am", "cy");
    
    DrawWindow("¿Desea continuar? (S/N)");


También se debe poder escribir un texto centrado en una cierta fila: 

    WriteCentered(2, "Bienvenido", "azul")


Y pedir un texto que solo admita ciertos caracteres como respuesta (por 
ejemplo, sólo una letra que sea S o N): 

    string confirmacion = GetAt(10, 4, 1, "SN"); 


O esperar una tecla, aceptando solo ciertos caracteres como respuesta: 

    char opcion = WaitForKey("01234");


Y pedir un número entero entre dos valores límites (por ejemplo, entre 1 y 99): 

    int edad = GetIntegerAt(10, 4, 1, 99); 

