using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;

namespace SP
{
    //DESARROLLAR DENTRO DEL NAMESPACE RAIZ ENTIDADES.SP EN UN PROYECTO DE TIPO CLASS LIBRARY

    public partial class SegundoParcial: Form
    {
        private Cajon<Fruta> cajonManzana = new Cajon<Fruta>(1, 3);
        private Cajon<Fruta> cajonBanana = new Cajon<Fruta>(2, 3);
        private Cajon<Fruta> cajonDurazno = new Cajon<Fruta>(3, 3);
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public SegundoParcial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Lucas Hulej");
            this.Text = "Lucas Hulej";
        }

        //Crear la siguiente jerarquía de clases:
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Crear una instancia de cada clase e inicializar los atributos del form _manzana, _banana y _durazno. 
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("Rojo", 1, "Chingolo");
            this._banana = new Banana("Amarillo", 2, "Chile");
            this._durazno = new Durazno("Naranja", 3, 100);
            //MessageBox.Show(this._manzana.ToString());
            //MessageBox.Show(this._banana.ToString());
            //MessageBox.Show(this._durazno.ToString());
        }

        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.btnPunto1_Click(sender, e);
            this.cajonManzana += this._manzana;
            this.cajonBanana += this._banana;
            this.cajonDurazno += this._durazno;
            //MessageBox.Show(cajonManzana.ToString());
            //MessageBox.Show(cajonBanana.ToString());
            //MessageBox.Show(cajonDurazno.ToString());

        }

        //Crear las interfaces: 
        //ISerializar -> Xml(string):bool
        //IDeserializar -> Xml(string, out Fruta):bool
        //Implementar (implicitamente) ISerializar en Cajon y manzana
        //Implementar (explicitamente) IDeserializar en manzana
        //Los archivos .xml guardarlos en el escritorio del cliente
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            this.btnPunto2_Click(sender, e);
            try
            {
                this.cajonBanana.Xml("CajonBanana.xml");
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
            MessageBox.Show("Finalizado");
            this.Close();
        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //implementar estructura de manejo de excepciones
           
            
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.(en el escritorio del cliente)
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos y crearlo en la clase Manejadora (de instancia).
          
        }

        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            
        }

        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //implementar manejo de excepciones
            //if (this.c_manzanas.EliminarFruta(1))
            //{
            //    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
            //}
            //else
            //{
            //    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
            //}

            //implementar manejo de excepciones
            //if (this.c_manzanas.EliminarFruta(1))
            //{
            //    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
            //}
            //else
            //{
            //    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
            //}

        }

        

    }
}
