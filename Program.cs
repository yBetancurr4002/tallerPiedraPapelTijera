// See https://aka.ms/new-console-template for more information

/* PIEDRA, PAPEL O TIJERA
 * 
 */

Random random = new Random();

while (true)
{
    Console.WriteLine("===== Nueva Ronda =====");
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Turno {i + 1}");

        // Computadora elige aleatoriamente
        string[] opciones = { "piedra", "papel", "tijera" };
        string eleccionComputadora = opciones[random.Next(0, 3)];

        // Jugador elige
        string eleccionJugador = opciones.Contains(ObtenerEleccionJugador()) ? ObtenerEleccionJugador() : "Inválido";

        if (eleccionJugador != "Inválido")
        {
            // Determinar ganador
            string resultado = DeterminarGanador(eleccionJugador, eleccionComputadora);
            Console.WriteLine($"Computadora eligió: {eleccionComputadora}");    
            Console.WriteLine($"Resultado: {resultado}");            
        }
        else
        {
            break;
        }
    }

    Console.WriteLine("¿Deseas jugar otra ronda? (s/n)");
    string continuar = Console.ReadLine().ToLower();
    if (continuar != "s")
    {
        break;
    }
}

static string ObtenerEleccionJugador()
{
    int intentosFallidos = 0;
    int limiteDeIntentos = 5;
    
    while (intentosFallidos < limiteDeIntentos)
    {
        Console.WriteLine("Elige: (piedra, papel, tijera)");
        string eleccion = Console.ReadLine().ToLower();
        if (eleccion == "piedra" || eleccion == "papel" || eleccion == "tijera")
        {
            Console.WriteLine(eleccion);
            return eleccion;
        }
        else
        {
            intentosFallidos++;
            Console.WriteLine("Eleccion inválida. Inténtalo de nuevo.");
        }
    }

    // Si el usuario excede el límite de intentos fallidos, se devuelve una cadena vacía o se maneja de otra manera adecuada

    Console.WriteLine("Ha superado el número máximo de intentos fallidos.");

    return "";
}


static string DeterminarGanador(string jugador, string computadora)
{
    if (jugador == computadora)
    {
        return "Empate";
    }
    else if ((jugador == "piedra" && computadora == "tijera") ||
             (jugador == "papel" && computadora == "piedra") ||
             (jugador == "tijera" && computadora == "papel"))
    {
        return "¡Ganaste!";
    }
    else
    {
        return "¡La computadora gana!";
    }
}


