using System;
using System.Threading;
using System.Windows.Forms;

namespace Fumadores_1._0 {
    class Fumador : HiloVisual {
        private int iIdentificador;
        private Mesa mMiMesa;
        private String sIngredienteInfinito;

        public Fumador(int i, Mesa m, String ingrediente, PictureBox Imagen) {
            iIdentificador = i;
            mMiMesa = m;
            sIngredienteInfinito = ingrediente;
            Dibujo = Imagen;
        }

        //Thread Run viene siendo lo mismo que el Run en Java
        public void ThreadRun() {
            while (true) {
                Random r = new Random();
                //Aqui quitamos el ingrediente de la Mesa(Buffer o buzón)
                if (mMiMesa.QuitaIngrediente(iIdentificador, sIngredienteInfinito)) {
                    //Si se pudo quitar, iniciamos la animación de fumar
                    Fuma();
                }
            }
        }

        public void Fuma() {
            switch (iIdentificador) {
                case 1:
                    Dibujo.Image = Properties.Resources.FumadorFumando1;
                    Dibujo.Invalidate();
                    Thread.Sleep(1000);
                    Dibujo.Image = Properties.Resources.FumadorEsperando1;
                    Dibujo.Invalidate();
                    break;
                case 2:
                    Dibujo.Image = Properties.Resources.FumadorFumando2;
                    Dibujo.Invalidate();
                    Thread.Sleep(1000);
                    Dibujo.Image = Properties.Resources.FumadorEsperando2;
                    Dibujo.Invalidate();
                    break;
                case 3:
                    Dibujo.Image = Properties.Resources.FumadorFumando3;
                    Dibujo.Invalidate();
                    Thread.Sleep(1000);
                    Dibujo.Image = Properties.Resources.FumadorEsperando3;
                    Dibujo.Invalidate();
                    break;
            }
        }
    }
}
