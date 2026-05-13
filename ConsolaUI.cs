using System;

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

            MostrarAhorcado();

            Console.WriteLine($"Categoría: {_repositorio.CategoriaActual}");

            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");

            Console.WriteLine($"Pista: {_motor.ObtenerPista()}");

            Console.Write("Palabra: ");

            foreach (char c in _motor.PalabraSecreta)
            {
                Console.Write(_motor.LetrasUsadas.Contains(c) ? c : '_');
            }

            Console.WriteLine();
        }

        public char PedirLetra()
        {
            while (true)
            {
                Console.Write("\nIngresa una letra: ");

                string entrada = Console.ReadLine()!.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("No puedes dejar el campo vacío.");
                    continue;
                }

                if (entrada.Length != 1)
                {
                    Console.WriteLine("Solo debes ingresar una letra.");
                    continue;
                }

                if (!char.IsLetterOrDigit(entrada[0]))
                {
                    Console.WriteLine("Debes ingresar una letra o número válido.");
                    continue;
                }

                return entrada[0];
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n | |\n |\n |\n |\n |\n=========",
                " -----\n | |\n O |\n |\n |\n |\n=========",
                " -----\n | |\n O |\n | |\n |\n |\n=========",
                " -----\n | |\n O |\n/| |\n |\n |\n=========",
                " -----\n | |\n O |\n/|\\\\ |\n |\n |\n=========",
                " -----\n | |\n O |\n/|\\\\ |\n/ |\n |\n=========",
                " -----\n | |\n O |\n/|\\\\ |\n/ \\\\ |\n |\n========="
            };

            Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
        }
    }
}