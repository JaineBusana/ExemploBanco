using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBanco.Entity
{
    public class PacienteEntity
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Mostrar()
        {
            Console.WriteLine($"{ID} - {Nome} - Idade:{Idade}");
        }
    }
}
