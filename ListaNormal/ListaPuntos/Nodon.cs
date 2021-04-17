using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Progra_Listas.ListaPuntos
{
    class Nodon
    {
        public string dato;
        public Nodon enlace;

        public Nodon(string x)
        {
            dato = x;
            enlace = null;
        }

        public Nodon(string x,Nodon n)
        {
            dato = x;
            enlace = n;
        }

        public string getDato()
        {
            return dato;
        }
        public Nodon getEnlace()
        {
            return enlace;
        }

        public void setEnlace(Nodon Enlace)
        {
            this.enlace = Enlace;
        }


    }
}
