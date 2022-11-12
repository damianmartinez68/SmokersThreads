using System;
using System.Windows.Forms;

namespace Fumadores_1._0 {
    class HiloVisual {
        private PictureBox Imagen;
        private ListBox lbConsola;

        delegate void LlamadaAFijarTexto(String Texto);

        public PictureBox Dibujo {
            set {
                Imagen = value;
            }
            get {
                return Imagen;
            }
        }

        public ListBox Consola {
            set {
                lbConsola = value;
            }
        }

        public void EscribeEnConsola(String Mensaje) {
            if (lbConsola.InvokeRequired) {
                LlamadaAFijarTexto Delegado = new LlamadaAFijarTexto(EscribeEnConsola);
                lbConsola.Invoke(Delegado, new object[] { Mensaje });
            } else {
                lbConsola.Items.Add(Mensaje);
            }
        }
    }
}
