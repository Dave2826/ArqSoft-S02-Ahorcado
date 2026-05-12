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
            Console.Write("\nIngresa una letra: ");

            return Console.ReadLine()[0];
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