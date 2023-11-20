using System;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente {get;set;}
            public DateTime FechaCita {get;set;}
            public string? RazonConsulta {get;set;}
            public double CostoConsulta {get;set;}
        }
         static void Main(string[] args)
        {
            Console.Write("\n-----------CITAS PARA UNA CLINICA DESNTISTA-----------");
            Console.Write("\nIngrese la cantidad de citas a crear: ");
            int cantidadCitas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < cantidadCitas; i++)
            {
                ConsultaMedica consulta = new ConsultaMedica();

                Console.WriteLine($"Ingrese los datos para la cita {i}:");
                Console.Write("Nombre del paciente: ");
                consulta.NombrePaciente = Console.ReadLine();

                Console.Write("Fecha de la cita (DD/MM/YYYY H:MM): ");
                consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Razón de la consulta: ");
                consulta.RazonConsulta = Console.ReadLine();

                Console.Write("Costo de la consulta: ");
                consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

                // Crear el nombre del archivo según el formato especificado
                string nombreArchivo = $"Cita{i:D3}";
                GuardarConsultaEnArchivo(consulta, nombreArchivo);
            }

            Console.WriteLine("Citas guardadas exitosamente. \n");
        }

        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            // Agregar el número de iteración al nombre del archivo
            string nombreCompleto = $"{nombreArchivo}#{consulta.NombrePaciente}.txt";

            // Crear el contenido del archivo
            string contenido =  $"Nombre del Paciente: {consulta.NombrePaciente}\n" +
                                $"Fecha de Citas: {consulta.FechaCita}\n" +
                                $"Razón de Consulta: {consulta.RazonConsulta}\n" +
                                $"Costo de Consulta: {consulta.CostoConsulta}";


            // Guardar el contenido en el archivo
            File.WriteAllText(nombreCompleto, contenido);

            Console.WriteLine($"\nCita guardad en el archivo: {nombreCompleto}");
        }
    }
}