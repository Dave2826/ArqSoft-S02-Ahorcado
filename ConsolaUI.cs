using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        private readonly PalabrasEnMemoria _repositorio;

        public ConsolaUI(MotorAhorcado motor, PalabrasEnMemoria repositorio)
        {
            _motor = motor;
            _repositorio = repositorio;
        }

        public void MostrarTablero()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("========================================");
            Console.WriteLine("         ARQSOFT HANGMAN SYSTEM");
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nCATEGORIA : {_repositorio.CategoriaActual}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"PISTA     : {_motor.ObtenerPista()}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"INTENTOS  : {_motor.IntentosRestantes}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"USADAS    : {string.Join(", ", _motor.LetrasUsadas)}");

            MostrarAhorcado();

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nPALABRA: ");

            foreach (char c in _motor.PalabraSecreta)
            {
                if (_motor.LetrasUsadas.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{c} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("_ ");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\n\n========================================");
        }

        public string PedirEntrada()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n> Ingresa letra o palabra: ");

                string entrada = Console.ReadLine()!.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Entrada vacía.");
                    continue;
                }

                bool valido = true;

                foreach (char c in entrada)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        valido = false;
                        break;
                    }
                }

                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Solo letras y números.");
                    continue;
                }

                return entrada;
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n>>> {mensaje}");
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                @"
  +-------+
  |
  |
  |
  |
  |
=================",

                @"
  +-------+
  |       O
  |
  |
  |
  |
=================",

                @"
  +-------+
  |       O
  |       |
  |
  |
  |
=================",

                @"
  +-------+
  |       O
  |      /|
  |
  |
  |
=================",

                @"
  +-------+
  |       O
  |      /|\
  |
  |
  |
=================",

                @"
  +-------+
  |       O
  |      /|\
  |      /
  |
  |
=================",

                @"
  +-------+
  |       X
  |      /|\
  |      / \
  |
  |
================="
            };

            int etapa = 6 - _motor.IntentosRestantes;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(etapas[etapa]);
        }
    }
}