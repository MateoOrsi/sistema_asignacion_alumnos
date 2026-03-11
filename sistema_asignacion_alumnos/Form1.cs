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
            if ((cmbp1.SelectedIndex == cmbp2.SelectedIndex) && cmbp1.SelectedIndex != -1 && cmbp2.SelectedIndex != -1 || (cmbp1.SelectedIndex == cmbp3.SelectedIndex) && cmbp1.SelectedIndex != -1 && cmbp3.SelectedIndex != -1)
            {
                MessageBox.Show("Modalidad repetida en otra prioridad.");
                cmbp1.SelectedItem = null;
            }
        }
        public void Inconsistencia2(object sender, EventArgs e)
        {
            if ((cmbp1.SelectedIndex == cmbp2.SelectedIndex) && cmbp1.SelectedIndex != -1 && cmbp2.SelectedIndex != -1 || (cmbp2.SelectedIndex == cmbp3.SelectedIndex) && cmbp1.SelectedIndex != -1 && cmbp3.SelectedIndex != -1)
            {
                MessageBox.Show("Modalidad repetida en otra prioridad.");
                cmbp2.SelectedItem = null;
            }
        }
        public void Inconsistencia3(object sender, EventArgs e)
        {
            if ((cmbp2.SelectedIndex == cmbp3.SelectedIndex) && cmbp2.SelectedIndex != -1 && cmbp3.SelectedIndex != -1 || (cmbp1.SelectedIndex == cmbp3.SelectedIndex) && cmbp1.SelectedIndex != -1 && cmbp3.SelectedIndex != -1)
            {
                MessageBox.Show("Modalidad repetida en otra prioridad.");
                cmbp3.SelectedItem = null;
            }
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
            if (cmbcurso.SelectedIndex != -1)
            {
                string cursoSeleccionado = cmbcurso.SelectedItem.ToString();
                tablaAlumnos = new DataTable();

                tablaAlumnos.Columns.Add("N°");
                tablaAlumnos.Columns.Add("Nombre y Apellido");
                tablaAlumnos.Columns.Add("DNI");
                tablaAlumnos.Columns.Add("Estado");

                using (var wb = new XLWorkbook(rutaOrigen))
                {
                    var ws = wb.Worksheet(cursoSeleccionado);
                    int fila = 3;
                    int contador = 1;


                    while (!ws.Cell(fila, 1).IsEmpty())
                    {
                        string nombre = ws.Cell(fila, 2).GetString();
                        string dni = ws.Cell(fila, 3).GetString();
                        if (ws.Cell(fila, 4).IsEmpty())
                        {
                            ws.Cell(fila, 4).Value = "PENDIENTE";
                        }
                        string estado = ws.Cell(fila, 4).GetString();

                        tablaAlumnos.Rows.Add(contador, nombre, dni, estado);

                        contador++;
                        fila++;
                    }
                }

                dataGridView1.DataSource = tablaAlumnos;
            }
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
            if (e.RowIndex >= 0)
            {
                lblname.Text = tablaAlumnos.Rows[e.RowIndex]["Nombre y Apellido"].ToString();
                lbldni.Text = tablaAlumnos.Rows[e.RowIndex]["DNI"].ToString();
                lblestado.Text = tablaAlumnos.Rows[e.RowIndex]["Estado"].ToString();
                lblcurso.Text = cmbcurso.SelectedItem.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XLWorkbook wb;

            if (rutaOrigen == null)
            {
                MessageBox.Show("Seleccione primero el archivo de alumnos");
                return;
            }

            string carpeta = Path.GetDirectoryName(ruta);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }


            if (!File.Exists(ruta))
            {
                wb = new XLWorkbook();

                // Crear las 9 hojas (EM, EL y AU para 1, 2 y 3)
                for (int i = 1; i <= 3; i++)
                {
                    IXLWorksheet EM_x = wb.AddWorksheet("EM" + i);
                    c_col(EM_x);

                    IXLWorksheet EL_x = wb.AddWorksheet("EL" + i);
                    c_col(EL_x);

                    IXLWorksheet AU_x = wb.AddWorksheet("AU" + i);
                    c_col(AU_x);
                }

                wb.SaveAs(ruta);
                MessageBox.Show("Se creó el archivo Excel en: " + ruta);
            }
            else
            {
                wb = new XLWorkbook(ruta);
                listas.Clear();
                iniciar_listas();

                detectar_ultima(wb.Worksheet("EM1"), listas["lista1"]);
                detectar_ultima(wb.Worksheet("EL1"), listas["lista2"]);
                detectar_ultima(wb.Worksheet("AU1"), listas["lista3"]);
                detectar_ultima(wb.Worksheet("EM2"), listas["lista4"]);
                detectar_ultima(wb.Worksheet("EL2"), listas["lista5"]);
                detectar_ultima(wb.Worksheet("AU2"), listas["lista6"]);
                detectar_ultima(wb.Worksheet("EM3"), listas["lista7"]);
                detectar_ultima(wb.Worksheet("EL3"), listas["lista8"]);
                detectar_ultima(wb.Worksheet("AU3"), listas["lista9"]);
                wb.Save();
            }

            if (lblestado.Text == "CARGADO")
            {
                MessageBox.Show("El alumno ya fue cargado previamente.");
                return;
            }
            if (cmbcurso.SelectedItem == null || cmbp1.SelectedItem == null || cmbp2.SelectedItem == null || cmbp3.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
                return;
            }
            string turno;
            if (cmbcurso.SelectedIndex == 2 || cmbcurso.SelectedIndex == 3 || cmbcurso.SelectedIndex == 4 || cmbcurso.SelectedIndex == 7)
            {
                turno = "TARDE";
            }
            else
            {
                turno = "MAÑANA";
            }
            string nombre = lblname.Text;
            string curso = cmbcurso.Text;
            string p1 = cmbp1.Text;
            string p2 = cmbp2.Text;
            string p3 = cmbp3.Text;
            if (!int.TryParse(lbldni.Text, out int dni))
            {
                MessageBox.Show("DNI inválido");
                return;
            }

            ALUMNO nuevo = new ALUMNO(nombre, dni, turno, curso, p1, p2, p3);

            IXLWorksheet hoja1;
            switch (nuevo.P1)
            {
                case "ELECTROMECANICA":
                    listas["lista1"].agregar_ordenado(nuevo);
                    hoja1 = wb.Worksheet("EM1");
                    vaciar_excel(hoja1, listas["lista1"]);
                    EscribirExcel(hoja1, listas["lista1"]);
                    break;

                case "ELECTRONICA":
                    listas["lista2"].agregar_ordenado(nuevo);
                    hoja1 = wb.Worksheet("EL1");
                    vaciar_excel(hoja1, listas["lista2"]);
                    EscribirExcel(hoja1, listas["lista2"]);
                    break;

                case "AUTOMOTORES":
                    listas["lista3"].agregar_ordenado(nuevo);
                    hoja1 = wb.Worksheet("AU1");
                    vaciar_excel(hoja1, listas["lista3"]);
                    EscribirExcel(hoja1, listas["lista3"]);
                    break;
            }

            IXLWorksheet hoja2;
            switch (nuevo.P2)
            {
                case "ELECTROMECANICA":
                    listas["lista4"].agregar_ordenado(nuevo);
                    hoja2 = wb.Worksheet("EM2");
                    vaciar_excel(hoja2, listas["lista4"]);
                    EscribirExcel(hoja2, listas["lista4"]);
                    break;

                case "ELECTRONICA":
                    listas["lista5"].agregar_ordenado(nuevo);
                    hoja2 = wb.Worksheet("EL2");
                    vaciar_excel(hoja2, listas["lista5"]);
                    EscribirExcel(hoja2, listas["lista5"]);
                    break;

                case "AUTOMOTORES":
                    listas["lista6"].agregar_ordenado(nuevo);
                    hoja2 = wb.Worksheet("AU2");
                    vaciar_excel(hoja2, listas["lista6"]);
                    EscribirExcel(hoja2, listas["lista6"]);
                    break;
            }

            IXLWorksheet hoja3;
            switch (nuevo.P3)
            {
                case "ELECTROMECANICA":
                    listas["lista7"].agregar_ordenado(nuevo);
                    hoja3 = wb.Worksheet("EM3");
                    vaciar_excel(hoja3, listas["lista7"]);
                    EscribirExcel(hoja3, listas["lista7"]);
                    break;

                case "ELECTRONICA":
                    listas["lista8"].agregar_ordenado(nuevo);
                    hoja3 = wb.Worksheet("EL3");
                    vaciar_excel(hoja3, listas["lista8"]);
                    EscribirExcel(hoja3, listas["lista8"]);
                    break;

                case "AUTOMOTORES":
                    listas["lista9"].agregar_ordenado(nuevo);
                    hoja3 = wb.Worksheet("AU3");
                    vaciar_excel(hoja3, listas["lista9"]);
                    EscribirExcel(hoja3, listas["lista9"]);
                    break;
            }
            wb.Save();
            MessageBox.Show("Se acaba de guardar");
            ActualizarEstadoEnOrigen(cmbcurso.SelectedItem.ToString(), lbldni.Text);
            tablaAlumnos.Clear();
            cmbcurso_SelectedIndexChanged(null, null);
            cmbp1.SelectedItem = null;
            cmbp2.SelectedItem = null;
            cmbp3.SelectedItem = null;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbcurso.SelectedIndex = -1;
            cmbp1.SelectedIndex = -1;
            cmbp2.SelectedIndex = -1;
            cmbp3.SelectedIndex = -1;
            dataGridView1.DataSource = null;

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel Files| *.xlsx;*.xls";
            ofd.Title = "Seleccione el archivo de alumnos";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaOrigen = ofd.FileName;
                MessageBox.Show("Archivo seleccionado: " + rutaOrigen);

                CargarCursosDesdeExcel();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string carpeta = fbd.SelectedPath;

                ruta = Path.Combine(carpeta, "CUARTO_AÑO.xlsx");

                MessageBox.Show("El archivoo se guardara en: " + ruta);
            }
        }
    }
}
