using System;
using System.Windows.Forms;

namespace Fumadores_1._0 {
    class Mesa : HiloVisual {
        private String sIngrediente1;
        private String sIngrediente2;
        private bool IngredientesColocado;   //PAra saber si ya hay algun ingrediente colocado

        public Mesa(ListBox cConsola) {
            Consola = cConsola;
            IngredientesColocado = false; //No hay ingredientes al principio
        }

        public bool QuitaIngrediente(int id, String ingrFumador) {
            if ((sIngrediente1 != sIngrediente2) && IngredientesColocado) {
                if (ingrFumador != sIngrediente1 && ingrFumador != sIngrediente2) {
                    //Se pudo quitar el ingrediente
                    EscribeEnConsola("Fumador " + id + ": Tengo " + ingrFumador + ". Fumaré");
                    IngredientesColocado = false;   //Ya no hay ingredientes
                    return true;
                } else {
                    //No se pudo quitar el ingrediente
                    return false;
                }
            } else {
                //No se pudo quitar el ingrediente
                return false;
            }
        }

        //Cuando llegan aquí los ingredientes, ya es seguro de que son distintos
        public void ColocaIngredientes(String sIngr1, String sIngr2) {
            sIngrediente1 = sIngr1;
            sIngrediente2 = sIngr2;
            EscribeEnConsola("Agente: Ingredientes: " + sIngrediente1 + " y " + sIngrediente2);
            IngredientesColocado = true; //Se han colocado ingredientes
        }
    }
}
