using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_asignacion_alumnos
{
    public class LAL
    {
        public ALUMNO primero { get; set; }
        public int cuantos { get; set; }
        public int c_ma { get; set; }
        public int c_ta { get; set; }

        public void agregar_ordenado(ALUMNO nuevo)
        {
            if (primero == null)
            {
                primero = nuevo;
                cuantos++;
                return;
            }

            if (nuevo.TURNO == "MAÑANA")
            {
                // insertar al principio
                nuevo.siguiente = primero;
                primero.anterior = nuevo;
                primero = nuevo;
                cuantos++;
                c_ma++;
            }
            else // TARDE
            {
                // buscar el último nodo
                ALUMNO actual = primero;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }

                // insertar al final
                actual.siguiente = nuevo;
                nuevo.anterior = actual;
                cuantos++;
                c_ta++;
            }
        }

        public bool TisAbove()
        {
            if (c_ta > 45)
            {
                return true;
            }
            return false;
        }

        public bool MisAbove()
        {
            if (c_ma > 45)
            {
                return true;
            }
            return false;
        }
    }
}
