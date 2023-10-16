using ExemploBanco.Model;

namespace ExemploBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PacienteModel paciente = new PacienteModel();
            paciente.Read();
            paciente.Create();
            paciente.Read();
            Console.Clear();
            paciente.Delete();
            paciente.Update();
            paciente.Read();

        }

        //Jaineeeee
    }
}