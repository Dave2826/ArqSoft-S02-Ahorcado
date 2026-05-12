using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            {
                "Programación",
                new List<string>
                {
                    "arquitectura",
                    "interfaz",
                    "polimorfismo",
                    "encapsulamiento",
                    "herencia"
                }
            },

            {
                "Videojuegos",
                new List<string>
                {
                    "minecraft",
                    "zelda",
                    "warzone",
                    "fortnite",
                    "halo"
                }
            },

            {
                "Motos",
                new List<string>
                {
                    "kawasaki",
                    "yamaha",
                    "ducati",
                    "bmw",
                    "honda"
                }
            }
        };

        public string CategoriaActual { get; private set; } = "";

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();

            List<string> nombresCategorias = new(_categorias.Keys);

            CategoriaActual = nombresCategorias[random.Next(nombresCategorias.Count)];

            List<string> palabras = _categorias[CategoriaActual];

            return palabras[random.Next(palabras.Count)];
        }
    }
}