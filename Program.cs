using System;
using System.Threading;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ARQSOFT ARCADE";

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Inicializando sistema...");
            Thread.Sleep(700);

            Console.WriteLine("Cargando modulos...");
            Thread.Sleep(700);

            Console.WriteLine("Conectando al nucleo...");
            Thread.Sleep(700);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==================================");
            Console.WriteLine("       ARQSOFT ARCADE");
            Console.WriteLine("==================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[1] AHORCADO");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[2] VIBORITA");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nSelecciona modo: ");

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

                    Thread.Sleep(Math.Max(60, 150 - motorViborita.Puntos * 8));
                }

                uiViborita.MostrarTablero();

                uiViborita.MostrarMensaje(
                    motorViborita.Ganado()
                    ? "\nMISIÓN COMPLETADA."
                    : "\nSISTEMA COLAPSADO."
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
                            ui.MostrarMensaje("Letra ya utilizada.");
                            continue;
                        }

                        motor.RegistrarLetra(letra);
                    }
                    else
                    {
                        bool correcto = motor.IntentarResolver(entrada);

                        if (correcto)
                        {
                            ui.MostrarMensaje("PALABRA DESCIFRADA.");
                        }
                        else
                        {
                            ui.MostrarMensaje("ACCESO DENEGADO.");
                        }
                    }
                }

                ui.MostrarTablero();

                if (motor.Ganado())
                {
                    ui.MostrarMensaje("\nMISIÓN COMPLETADA.");
                }
                else
                {
                    ui.MostrarMensaje($"\nSISTEMA FALLIDO. La palabra era: {motor.PalabraSecreta}");
                }
            }

            Console.ResetColor();
        }
    }
}