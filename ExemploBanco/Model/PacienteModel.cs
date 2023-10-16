using Dapper;
using ExemploBanco.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBanco.Model
{
    public class PacienteModel : ICRUD
    {
        public string connectionString = "Server=localhost;Database=ambulatorio;User=root;Password=root;";
        public void Create()
        {
            PacienteEntity paciente = new PacienteEntity();
            Console.WriteLine("Digite o nome");
            paciente.Nome = Console.ReadLine();
            Console.WriteLine("Digite a Idade");
            paciente.Idade = Convert.ToInt32(Console.ReadLine());

            using (MySqlConnection conexao = new MySqlConnection(connectionString)) 
            {
                string sql = "INSERT INTO paciente VALUE (NULL, @Nome, @Idade)";
                int linhas = conexao.Execute(sql, paciente);
                Console.WriteLine($"Paciente inserido - {linhas} linhas afetadas");
            }
        }

        public void Delete()
        {
            Read();
            Console.WriteLine("Digite o ID para excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {
                var parametros = new { ID = id };
                string sql = "DELETE FROM paciente WHERE ID = @id";
                conexao.Execute(sql, parametros );
                Console.WriteLine("Paciente excluido com sucesso!");
            }
        }

        public void Read()
        {
            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {
                IEnumerable<PacienteEntity> pacientes = conexao.Query<PacienteEntity>("SELECT * FROM paciente");
                foreach(PacienteEntity paciente in pacientes)
                {
                    paciente.Mostrar();
                }
            }
        }

        public void Update()
        {
            Read();
            Console.WriteLine("Digite o ID do paciente que deseja editar");
            int id = Convert.ToInt32(Console.ReadLine());

            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {
                string sql = "SELECT ID, Nome, Idade FROM Paciente WHERE ID = @id";
                var parametros = new { ID = id };
                PacienteEntity paciente = conexao.QueryFirst<PacienteEntity>(sql, parametros);

                Console.WriteLine($"Digite o novo Nome do {paciente.Nome}");
                paciente.Nome = Console.ReadLine();

                Console.WriteLine("Digite a idade");
                paciente.Idade = Convert.ToInt32(Console.ReadLine());

                string sql2 = "UPDATE Paciente SET Nome = @Nome, Idade WHERE ID = @id";
                conexao.Execute(sql2, paciente);
                Console.WriteLine("Paciente atualizado com sucesso!");

            }

            
            
        }
    }
}
