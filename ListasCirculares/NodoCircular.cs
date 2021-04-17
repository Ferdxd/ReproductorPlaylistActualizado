using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor_PlaylistsProgra.ListasCirculares
{
    class NodoCircular
    {
        public string dato;
        public NodoCircular enlace;

        public NodoCircular(string entrada)
        {
            dato = entrada;
            enlace = this;
        }
    }
}
