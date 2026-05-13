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
            "backend",
            "frontend",
            "docker",
            "visualstudio",
            "bug"
        }
    },

    {
        "Videojuegos",
        new List<string>
        {
            "minecraft",
            "warzone",
            "valorant",
            "halo",
            "fortnite"
        }
    },

    {
        "Motos",
        new List<string>
        {
            "kawasaki",
            "ducati",
            "ninja400",
            "panigale",
            "bmws1000rr"
        }
    },

    {
        "Heroes",
        new List<string>
        {
            "batman",
            "deadpool",
            "punisher",
            "wolverine",
            "spiderman"
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