using System;
using System.Threading;

namespace Fumadores_1._0 {
    class Agente {
        private int iIngrediente1;
        private int iIngrediente2;
        private Mesa mMesa;
        private String[] aIngredientes = new string[3];

        public Agente(Mesa m) {
            mMesa = m;
        }

        public void ThreadRun() {
            while (true) {
                Random r1 = new Random();
                Random r2 = new Random();
                Random r3 = new Random();

                aIngredientes[0] = "Papel";
                aIngredientes[1] = "Tabaco";
                aIngredientes[2] = "Cerillos";

                iIngrediente1 = r1.Next(3);
                iIngrediente2 = r2.Next(3);

                if (iIngrediente1 != iIngrediente2) {
                    mMesa.ColocaIngredientes(aIngredientes[iIngrediente1], aIngredientes[iIngrediente2]);
                    //Se esperará 1 segundo despues de la produccion de los ingredientes
                    try {
                        Thread.Sleep(1000);
                    } catch (Exception) {
                        throw;
                    }
                }
            }
        }
    }
}
