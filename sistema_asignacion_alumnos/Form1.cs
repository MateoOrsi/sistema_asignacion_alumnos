using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace sistema_asignacion_alumnos
{
    public partial class Form1 : Form
    {
        string ruta = null;  // Ruta del archivo Excel de destino
        string rutaOrigen = null;  // Ruta del archivo Excel de origen
        DataTable tablaAlumnos = new DataTable();   // Tabla para almacenar los datos de los alumnos

        Dictionary<string, LAL> listas = new Dictionary<string, LAL>();     // diccionario para almacenar las listas

        public void iniciar_listas()
        {
            for (int i = 1; i < 10; i++)
            {
                string nombre = "lista" + i;    // "lista0", "lista1", ...
                listas[nombre] = new LAL();     // guardo cada lista en el diccionario
            }
        }
        public Form1()
        {
            InitializeComponent();
            iniciar_listas();

        }
        public void Inconsistencia1(object sender, EventArgs e)
        {

        }
        public void Inconsistencia2(object sender, EventArgs e)
        {

        }
        public void Inconsistencia3(object sender, EventArgs e)
        {

        }
        private void CargarCursosDesdeExcel()
        {
            cmbcurso.Items.Clear();

            using (var wb = new XLWorkbook(rutaOrigen))
            {
                foreach (var hoja in wb.Worksheets)
                {
                    cmbcurso.Items.Add(hoja.Name);
                }
            }
        }

        private void cmbcurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void ActualizarEstadoEnOrigen(string curso, string dni)
        {
            using (var wb = new XLWorkbook(rutaOrigen))
            {
                var ws = wb.Worksheet(curso);

                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    string dniExcel = row.Cell(3).Value.ToString();
                    if (dniExcel == dni)
                    {
                        row.Cell(4).Value = "CARGADO";
                        row.Cell(4).Style.Fill.BackgroundColor = XLColor.LightGreen;
                        break;
                    }
                }

                wb.Save();
            }
        }

        public void EscribirExcel(IXLWorksheet hoja, LAL lista)
        {
            vaciar_excel(hoja, lista);
            int fila = 2;

            while (!string.IsNullOrWhiteSpace(hoja.Cell(fila, 1).GetString()))
                fila++;
            ALUMNO actual = lista.primero; // asumimos que tu LAL tiene "primero"
            int filaManana = 0; // contador de filas pintadas para turno mañana
            int filaTarde = 0;  // contador de filas pintadas para turno tarde

            while (actual != null)
            {
                hoja.Cell(fila, 1).Value = actual.NOMBRE;
                hoja.Cell(fila, 2).Value = actual.DNI;
                hoja.Cell(fila, 3).Value = actual.ULTIMOS3;
                hoja.Cell(fila, 4).Value = actual.TURNO;
                hoja.Cell(fila, 5).Value = actual.CURSO;
                hoja.Cell(fila, 6).Value = actual.P1;
                hoja.Cell(fila, 7).Value = actual.P2;
                hoja.Cell(fila, 8).Value = actual.P3;

                var rangoFila = hoja.Range(fila, 1, fila, 9); // columnas A a I
                                                              // Pintar según turno y contador de la lista
                if (actual.TURNO == "MAÑANA")
                {
                    filaManana++;
                    if (filaManana <= 45) rangoFila.Style.Fill.BackgroundColor = XLColor.LightGreen;
                    else rangoFila.Style.Fill.BackgroundColor = XLColor.Red;
                }
                else if (actual.TURNO == "TARDE")
                {
                    filaTarde++;
                    if (filaTarde <= 45) rangoFila.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    else rangoFila.Style.Fill.BackgroundColor = XLColor.Red;
                }

                fila++;
                actual = actual.siguiente;
            }
        }
        public void c_col(IXLWorksheet hoja)
        {
            hoja.Cell("A1").Value = "NOMBRE";
            hoja.Cell("B1").Value = "DNI";
            hoja.Cell("C1").Value = "PRIMEROS 3 DIGITOS";
            hoja.Cell("D1").Value = "TURNO";
            hoja.Cell("E1").Value = "CURSO";
            hoja.Cell("F1").Value = "PRIORIDAD 1";
            hoja.Cell("G1").Value = "PRIORIDAD 2";
            hoja.Cell("H1").Value = "PRIORIDAD 3";
            hoja.ColumnWidth = 20;
        }

        public void vaciar_excel(IXLWorksheet hoja, LAL lista)
        {
            for (int i = 2; i < lista.cuantos + 5; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    hoja.Cell(i, j).Value = "";
                }
            }
        }
        public void detectar_ultima(IXLWorksheet hoja, LAL lista)
        {
            foreach (var row in hoja.RowsUsed().Skip(1))
            {
                if (!row.Cell(1).IsEmpty())
                {
                    string nombre = row.Cell(1).GetString();
                    int dni = row.Cell(2).GetValue<int>();
                    string turno = row.Cell(4).GetString();
                    string curso = row.Cell(5).GetString();
                    string p1 = row.Cell(6).GetString();
                    string p2 = row.Cell(7).GetString();
                    string p3 = row.Cell(8).GetString();

                    ALUMNO nuevo = new ALUMNO(nombre, dni, turno, curso, p1, p2, p3);
                    lista.agregar_ordenado(nuevo);
                }
            }
        }
        private void cmbturno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
