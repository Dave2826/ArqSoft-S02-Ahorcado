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