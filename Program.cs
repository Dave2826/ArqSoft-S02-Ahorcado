using System.Threading;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¿Qué juego quieres jugar?");
            Console.WriteLine("1 — Ahorcado");
            Console.WriteLine("2 — Viborita");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "2")
            {
                var motorViborita = new MotorViborita();

                var uiViborita = new ConsolaUIViborita(motorViborita);

                Console.CursorVisible = false;

                while (!motorViborita.Ganado() && !motorViborita.Perdido())
                {
                    uiViborita.MostrarTablero();

                    var tecla = uiViborita.LeerTecla();

                    if (tecla == ConsoleKey.Q)
                        break;

                    if (tecla != ConsoleKey.NoName)
                        motorViborita.CambiarDireccion(tecla);

                    motorViborita.Avanzar();

                    Thread.Sleep(150);
                }

                uiViborita.MostrarTablero();

                uiViborita.MostrarMensaje(
                    motorViborita.Ganado()
                    ? "\n¡Ganaste! Llegaste a 10 puntos."
                    : "\nGame over."
                );
            }
            else
            {
                PalabrasEnMemoria repositorio = new PalabrasEnMemoria();

                MotorAhorcado motor = new MotorAhorcado(repositorio);

                ConsolaUI ui = new ConsolaUI(motor, repositorio);

                while (!motor.Ganado() && !motor.Perdido())
                {
                    ui.MostrarTablero();

                    string entrada = ui.PedirEntrada();

                    if (entrada.Length == 1)
                    {
                        char letra = entrada[0];

                        if (motor.LetraYaUsada(letra))
                        {
                            ui.MostrarMensaje("Ya usaste esa letra.");
                            continue;
                        }

                        motor.RegistrarLetra(letra);
                    }
                    else
                    {
                        bool correcto = motor.IntentarResolver(entrada);

                        if (correcto)
                        {
                            ui.MostrarMensaje("Adivinaste la palabra completa.");
                        }
                        else
                        {
                            ui.MostrarMensaje("Palabra incorrecta.");
                        }
                    }
                }

                ui.MostrarTablero();

                if (motor.Ganado())
                {
                    ui.MostrarMensaje("\nGanaste. El barrio gamer/motociclista te respalda.");
                }
                else
                {
                    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}. Te faltó barrio.");
                }
            }
        }
    }
}