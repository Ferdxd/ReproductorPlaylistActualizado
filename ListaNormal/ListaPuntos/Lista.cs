using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Progra_Listas.ListaPuntos
{
    class Lista
    {
        public Nodon primero;
        public Lista()
        {
            primero = null;
        }
        
        private int leerEntero()
        {
            Console.WriteLine("Ingrese valor, -1 para inicializar");
            return int.Parse(Console.ReadLine());
        }

       /* public Lista crearLista()
        {
            string x;
            primero = null;
            do
            {
                //x = leerEntero();
                if (x != "")
                {
                    primero = new Nodo(x, primero);
                }

            } while (x!="");
            return this;
        }*/
        
        public Nodon buscarPosicion(int posicion)
        {
            Nodon indice;
            int i;
            if (posicion < 0)
            {
                return null;
            }
            indice = primero;
            for (i = 1; (i < posicion) && (indice != null); i++)
            {
                indice = indice.enlace;
            }
            return indice;
        }

        public Lista insertarUltimo(Nodon ultimo,string entrada)
        {
            ultimo.enlace = new Nodon(entrada);
            ultimo = ultimo.enlace;
            return this;
        }

        public Lista insertarCabeza(Nodon cabeza,string valor)
        {
            cabeza.enlace = new Nodon(valor);
            cabeza = cabeza.enlace;
            return this;
        }

        
        public Nodon buscarLista(string destino)
        {
            Nodon indice;
            for (indice = primero; indice != null; indice = indice.enlace)
            {
                if (destino.Equals(indice.dato))
                {
                    return indice;
                }
            }
            return null;
        }

        public void eliminar(string entrada)
        {
            Nodon actual, anterior;
            bool encontrado;
            //inicializa los apuntadores
            actual = primero;
            anterior = null;
            encontrado = false;
            //busqueda del nodo anterior
            while ((actual != null) && (encontrado))
            {
                encontrado = (actual.dato.Equals(entrada));
                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }
            //enlace del nodo anterior con el siguiente
            if (actual != null)
            {
                if (actual == primero)
                {
                    primero = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
                actual = null;
            }
        }


        public Lista insertarLista(string testigo,string entrada)
        {
            Nodon nuevo, anterior;
            anterior = buscarLista(testigo);
            if (anterior != null)
            {
                nuevo = new Nodon(entrada);
                nuevo.enlace = anterior.enlace;
                anterior.enlace = nuevo;
            }
            return this;
        }

        public void visualizar()
        {
            Nodon n;
            int k = 0;
            n = primero;
            while (n != null)
            {
                Console.Write(n.dato + " ");
                n = n.enlace;
                k++;
                Console.WriteLine(k % 15 != 0 ? " " : "\n");
            }
        }


        

    }
}
