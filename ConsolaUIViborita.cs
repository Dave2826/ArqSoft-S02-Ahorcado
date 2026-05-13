using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("========================================");
            Console.WriteLine("         NEON SNAKE PROTOCOL");
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"SCORE: {_motor.Puntos}   |   TARGET: 10");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("+" + new string('-', _motor.Ancho * 2) + "+");

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("|");

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    if (_motor.Cuerpo.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("██");
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("▓▓");
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("◉ ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', _motor.Ancho * 2) + "+");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\nFLECHAS = mover | Q = salir");
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(intercept: true).Key;
            }

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n>>> {mensaje}");
        }
    }
}