using Reproductor_PlaylistsProgra.ListasDobles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor_PlaylistsProgra.ListasCirculares
{
    class ClsListaCircular
    {
        public NodoCircular lc;

        public ClsListaCircular()
        {
            lc = null;
        }
        

        public ClsListaCircular insertar(string entrada)
        {
            NodoCircular nuevo;
            nuevo = new NodoCircular(entrada);
            if (lc != null)
            { //Lista no vacia 
                nuevo.enlace = lc.enlace;
                lc.enlace = nuevo;
            }
            lc = nuevo;
            return this;
        }

        public void eliminar(string entrada)
        {
            NodoCircular actual;
            bool encontrado = false;
            //Bucle de busqueda
            actual = lc;
            while ((actual.enlace != lc) && (!encontrado))
            {
                encontrado = (actual.enlace.dato.Equals(entrada));
                if (!encontrado)
                {
                    actual = actual.enlace;
                }
            }
            encontrado = (actual.enlace.dato.Equals(entrada));
            //Enlace de Nodo anterior con el siguiente
            if (encontrado)
            {
                NodoCircular p;
                p = actual.enlace; //Nodo a eliminar
                if (lc == lc.enlace)
                {
                    lc = null;
                }
                else
                {
                    if (p == lc)
                    {
                        lc = actual; //Se borra el elemento reclamado por lc
                    }
                    actual.enlace = p.enlace;
                }
                p = null;
            }
        }


        public void borrarLista()
        {
            NodoCircular p;
            if (lc != null)
            {
                p = lc;
                do
                {
                    NodoCircular t;
                    t = p;
                    p = p.enlace;
                    t = null; // no es estrictamente necesario
                } while (p != lc);
            }
            else
            {
                Console.WriteLine("\n\t Lista vacía.");
            }
            lc = null;
        }



        public void recorrer()
        {
            NodoCircular p;
            if (lc != null)
            {
                p = lc.enlace; // siguiente nodo al de acceso
                do
                {
                    Console.Write("\t" + p.dato);
                    p = p.enlace;
                } while (p != lc.enlace);
            }
            else
            {
                Console.Write("\t Lista Circular vacía.");
            }
        }

        public void siguiente()
        {
            if (lc.dato != null)
            {
                lc = lc.enlace;
               
            }
        }
      

  

    }
}
