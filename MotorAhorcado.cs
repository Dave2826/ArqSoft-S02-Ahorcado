using System.Collections.Generic;

namespace Ahorcado
{
    public class MotorAhorcado
    {
        private readonly string _palabraSecreta;

        private readonly List<char> _letrasUsadas = new();

        private int _intentosRestantes = 6;

        public string PalabraSecreta => _palabraSecreta;

        public List<char> LetrasUsadas => _letrasUsadas;

        public int IntentosRestantes => _intentosRestantes;

        public MotorAhorcado(IRepositorioPalabras repositorio)
        {
            _palabraSecreta = repositorio.ObtenerPalabraAleatoria().ToLower();
        }

        public bool LetraYaUsada(char letra)
        {
            return _letrasUsadas.Contains(char.ToLower(letra));
        }

        public void RegistrarLetra(char letra)
        {
            letra = char.ToLower(letra);

            _letrasUsadas.Add(letra);

            if (!_palabraSecreta.Contains(letra))
            {
                _intentosRestantes--;
            }
        }

        public bool IntentarResolver(string intento)
        {
            intento = intento.ToLower();

            if (intento == _palabraSecreta)
            {
                foreach (char c in _palabraSecreta)
                {
                    if (!_letrasUsadas.Contains(c))
                    {
                        _letrasUsadas.Add(c);
                    }
                }

                return true;
            }

            _intentosRestantes--;

            return false;
        }

        public string ObtenerPista()
        {
            return $"La palabra tiene {_palabraSecreta.Length} caracteres y comienza con '{_palabraSecreta[0]}'.";
        }

        public bool Ganado()
        {
            foreach (char c in _palabraSecreta)
            {
                if (!_letrasUsadas.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Perdido()
        {
            return _intentosRestantes <= 0;
        }
    }
}