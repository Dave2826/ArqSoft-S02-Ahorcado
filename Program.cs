namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PalabrasEnMemoria repositorio = new PalabrasEnMemoria();

            MotorAhorcado motor = new MotorAhorcado(repositorio);

            ConsolaUI ui = new ConsolaUI(motor, repositorio);

            while (!motor.Ganado() && !motor.Perdido())
            {
                ui.MostrarTablero();

                char letra = ui.PedirLetra();

                if (motor.LetraYaUsada(letra))
                {
                    ui.MostrarMensaje("Ya usaste esa letra.");
                    continue;
                }

                motor.RegistrarLetra(letra);
            }

            ui.MostrarTablero();

            if (motor.Ganado())
            {
                ui.MostrarMensaje("\nGanaste.");
            }
            else
            {
                ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
            }
        }
    }
}