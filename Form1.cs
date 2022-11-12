/* DETALLES:
 * En esta nueva versión (1.0), se elimina el uso de la consola de sistema y se cambia por una "consola" en 
 * el Windows Form usando un ListBox y delegados para poder hacer modificaciones a los controles del
 * Form de manera segura 
 * Correcciones de Bugs Menores
 * Limpieza y optimización (Kind of...)
 * */
using System.Threading;
using System.Windows.Forms;

namespace Fumadores_1._0 {
    public partial class Form1 : Form {
        private Agente aAgente;
        private Fumador fFumador1;
        private Fumador fFumador2;
        private Fumador fFumador3;
        private Mesa mMesa;

        private Thread tProductor1;
        private Thread tFumador1;
        private Thread tFumador2;
        private Thread tFumador3;

        public Form1() {
            InitializeComponent();

            mMesa = new Mesa(LB_Consola);
            aAgente = new Agente(mMesa);
            fFumador1 = new Fumador(1, mMesa, "Papel", PB_Fumador1);
            fFumador2 = new Fumador(2, mMesa, "Tabaco", PB_Fumador2);
            fFumador3 = new Fumador(3, mMesa, "Cerillos", PB_Fumador3);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            
        }

        private void B_Iniciar_Click(object sender, System.EventArgs e) {
            tProductor1 = new Thread(aAgente.ThreadRun);
            tFumador1 = new Thread(fFumador1.ThreadRun);
            tFumador2 = new Thread(fFumador2.ThreadRun);
            tFumador3 = new Thread(fFumador3.ThreadRun);

            tProductor1.Start();            
            tFumador1.Start();
            tFumador2.Start();
            tFumador3.Start();
        }

        private void B_Detener_Click(object sender, System.EventArgs e) {
            tProductor1.Abort();
            tFumador1.Abort();
            tFumador2.Abort();
            tFumador3.Abort();

            fFumador1.Dibujo.Image = Properties.Resources.FumadorEsperando1;
            fFumador2.Dibujo.Image = Properties.Resources.FumadorEsperando2;
            fFumador3.Dibujo.Image = Properties.Resources.FumadorEsperando3;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                tProductor1.Abort();
                tFumador1.Abort();
                tFumador2.Abort();
                tFumador3.Abort();
            } catch (System.Exception) {
                throw;
            }
        }
    }
}
