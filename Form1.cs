using Proyecto_Progra_Listas.ListaPuntos;
using Proyecto_Progra_Listas.ListasOrdenadas;
using Reproductor_PlaylistsProgra.ListasCirculares;
using Reproductor_PlaylistsProgra.ListasDobles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor_PlaylistsProgra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] archivo, ruta;
        bool reproducir = true;
        //listas dobles
        ClsListaDoble rutas = new ClsListaDoble();
        ClsListaDoble canciones = new ClsListaDoble();
        //listas circulares
        ClsListaCircular replay_rutas=new ClsListaCircular();
        ClsListaCircular replay_canciones = new ClsListaCircular();
        //iteradores de listas dobles
        IteradorLista iterador_rutas;
        IteradorLista iterador_Nombres;
        bool repetir = false;
        int i = 0;
        //ListaOrden rutas = new ListaOrden();
        //ListaOrden canciones = new ListaOrden();
       // int iterador=1;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (repetir==false)
            {
                iterador_rutas = new IteradorLista(rutas);
                iterador_Nombres = new IteradorLista(canciones);
                if (reproducir)
                {
                    axWindowsMediaPlayer1.URL = iterador_rutas.actual.dato;
                    reproducir = false;
                }
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lblCancion.Text = iterador_Nombres.actual.dato;
            }
            else
            {
                if (reproducir)
                {
                    replay_rutas.siguiente();
                    replay_canciones.siguiente();
                    axWindowsMediaPlayer1.URL = replay_rutas.lc.dato;
                       
                }
       
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lblCancion.Text = replay_canciones.lc.dato.ToString();
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                  
          //      axWindowsMediaPlayer1.URL = rutas.buscarPosicion(listBox1.SelectedIndex+1).dato.ToString();
            }
            catch
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = "";
                axWindowsMediaPlayer1.close();
            }
            //iterador = listBox1.SelectedIndex+1;
            //lblCancion.Text = canciones.buscarPosicion(iterador).dato.ToString();

        }

    

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (repetir==false)
            {
                i++;
                iterador_rutas.siguiente();
                axWindowsMediaPlayer1.URL = iterador_rutas.actual.dato;
                iterador_Nombres.siguiente();
                lblCancion.Text = iterador_Nombres.actual.dato;
            }
            else
            {
                replay_rutas.siguiente();
                replay_canciones.siguiente();
                axWindowsMediaPlayer1.URL = replay_rutas.lc.dato;
                lblCancion.Text = replay_canciones.lc.dato.ToString();
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();
         
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (repetir==false)
            {
                i--;
                iterador_rutas.anterior();
                axWindowsMediaPlayer1.URL = iterador_rutas.actual.dato;
                iterador_Nombres.anterior();
                lblCancion.Text = iterador_Nombres.actual.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {

            }
        }

        private void lblCancion_Click(object sender, EventArgs e)
        {
           
        }

     

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //dejar de usar los iteradores
            if (repetir == false)
            {
                rutas.eliminar(axWindowsMediaPlayer1.URL);
                listBox1.Items.RemoveAt(i);
                canciones.eliminar(lblCancion.Text);
                iterador_rutas = new IteradorLista(rutas, i);
                iterador_Nombres = new IteradorLista(canciones, i);
                axWindowsMediaPlayer1.URL = iterador_rutas.actual.dato;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lblCancion.Text = iterador_Nombres.actual.dato;
            }
            else
            {
                canciones.eliminar(lblCancion.Text);
                replay_canciones.eliminar(lblCancion.Text);
                replay_rutas.eliminar(axWindowsMediaPlayer1.URL);
                rutas.eliminar(axWindowsMediaPlayer1.URL);
                listBox1.Items.Clear();
                iterador_rutas = new IteradorLista(rutas, i);
                iterador_Nombres = new IteradorLista(canciones, i);

                IteradorLista recorrer = new IteradorLista(canciones);
                while (recorrer.actual != null)
                {
                    listBox1.Items.Add(recorrer.actual.dato);
                    recorrer.siguiente();

                }

            }
            

        }

        private void btnRepeticion_Click(object sender, EventArgs e)
        {
            IteradorLista recorrer = new IteradorLista(rutas);
            IteradorLista recorrer_nombres = new IteradorLista(canciones);
            if (repetir)
            {
                repetir = false;
            }
            else
            {
                repetir = true;
            }

            if (repetir == false)
            {
                replay_rutas.borrarLista();
            }
            else
            {
                while (recorrer.actual != null)
                {
                    replay_rutas.insertar(recorrer.actual.dato);
                    recorrer.siguiente();
                    replay_canciones.insertar(recorrer_nombres.actual.dato);
                    recorrer_nombres.siguiente(); 
                }
                i = 1;
                reproducir = false;
             

            }
                   
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK){
                archivo = openFileDialog1.SafeFileNames;
                ruta = openFileDialog1.FileNames;
                for(int i = 0; i < archivo.Length; i++)
                {
                    rutas.insertaDespues(rutas.cabeza,ruta[i]);
                    canciones.insertaDespues(canciones.cabeza, archivo[i]);

                }
            }

            IteradorLista recorrer = new IteradorLista(canciones);
            while (recorrer.actual!=null)
            {
                listBox1.Items.Add(recorrer.actual.dato);
                recorrer.siguiente();
                
            }
           


        }
    }
}
