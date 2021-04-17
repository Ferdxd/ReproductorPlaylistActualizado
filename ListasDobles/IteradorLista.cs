using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor_PlaylistsProgra.ListasDobles
{
    class IteradorLista
    {
        public Nodo actual;

        public IteradorLista(ClsListaDoble ld)
        {
            actual = ld.cabeza;
        }

        public IteradorLista(ClsListaDoble ld, int iter)
        {
            actual = ld.cabeza;
            for (int j = 0; j < iter; j++)
            {
                if (actual != null)
                {
                    actual = actual.adelante;
                }
            }
        }



        public Nodo siguiente()
        {
            Nodo a;
            a = actual;
            if (actual != null)
            {
                actual = actual.adelante;
            }
            return a;
        }

   

        public Nodo anterior()
        {
            Nodo a;
            a = actual;
            if (actual != null)
            {
                actual = actual.atras;
            }
            return a;
        }
    }
}
