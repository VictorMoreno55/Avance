using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_QUE_SEA
{
    internal class Acciones
    {
        private List<Alumno> alumnoList = new List<Alumno>
        {
           
        };
        public List<Alumno> Mostrar()
        {
            return alumnoList;
        }

        public bool ExportarExcel()
        {
            try
            {
                var workbook = new ClosedXML.Excel.XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Alumnos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Nombre";
                worksheet.Cell(1, 2).Value = "Edad";
                worksheet.Cell(1, 3).Value = "Carrera";
                worksheet.Cell(1, 4).Value = "Matricula";
                worksheet.Cell(1, 5).Value = "Fecha de Ingreso";

                // Cargar datos
                int fila = 2;
                foreach (var alumno in alumnoList)
                {
                    worksheet.Cell(fila, 1).Value = alumno.Nombre;
                    worksheet.Cell(fila, 2).Value = alumno.Edad;
                    worksheet.Cell(fila, 3).Value = alumno.Carrera;
                    worksheet.Cell(fila, 4).Value = alumno.Matricula;
                    worksheet.Cell(fila, 5).Value = alumno.Fechanacimiento.ToShortDateString();
                    fila++;
                }

                // Obtener ruta del escritorio
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rutaArchivo = Path.Combine(escritorio, "Alumnos.xlsx");

                // Guardar archivo
                workbook.SaveAs(rutaArchivo);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ImportarExcel()
        {
            try
            {
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rutaArchivo = Path.Combine(escritorio, "Alumnos.xlsx");

                if (!File.Exists(rutaArchivo))
                    return false;

                var workbook = new XLWorkbook(rutaArchivo);
                var worksheet = workbook.Worksheet("Alumnos");

                alumnoList.Clear();

                int fila = 2;
                while (!worksheet.Cell(fila, 1).IsEmpty())
                {
                    string nombre = worksheet.Cell(fila, 1).GetString();
                    int edad = worksheet.Cell(fila, 2).GetValue<int>();
                    string carrera = worksheet.Cell(fila, 3).GetString();
                    int matricula = worksheet.Cell(fila, 4).GetValue<int>();
                    DateTime fecha = worksheet.Cell(fila, 5).GetDateTime();

                    alumnoList.Add(new Alumno(nombre, edad, carrera, matricula, fecha));
                    fila++;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
