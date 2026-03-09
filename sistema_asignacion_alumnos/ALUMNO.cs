using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_asignacion_alumnos
{
    public class ALUMNO
    {
        public string NOMBRE { get; set; }
        public int DNI { get; set; }
        public int ULTIMOS3 { get; set; }
        public string TURNO { get; set; }
        public string CURSO { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }

        public ALUMNO(string nombre, int dni, string turno, string curso, string p1, string p2, string p3)
        {
            NOMBRE = nombre;
            DNI = dni;
            ULTIMOS3 = completar_ult();
            TURNO = turno;
            CURSO = curso;
            P1 = p1;
            P2 = p2;
            P3 = p3;

            siguiente = null;
            anterior = null;
        }

        public ALUMNO siguiente { get; set; }
        public ALUMNO anterior { get; set; }

        public int completar_ult()
        {
            string texto = DNI.ToString();
            string ultimos3 = texto.Substring(texto.Length - 3); // toma los últimos 3 caracteres
            return int.Parse(ultimos3);
        }
    }
}
