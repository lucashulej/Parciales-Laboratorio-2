using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Data.SqlClient;

namespace Frm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Cajon<Manzana> cajonManzana = new Cajon<Manzana>(1, 3);
        private Cajon<Banana> cajonBanana = new Cajon<Banana>(2, 3);
        private Cajon<Durazno> cajonDurazno = new Cajon<Durazno>(18, 4);
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        //private DataTable tabla;
        //SqlConnection dataBase;
        //SqlCommand comando;
        //SqlDataAdapter dataAdapter;

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Lucas Hulej");
            this.Text = "Lucas Hulej";
            //this.tabla = new DataTable("tabla de frutas");
            //this.conectarBaseDeDatos();
        }

        //private void conectarBaseDeDatos()
        //{
        //    try
        //    {
        //        this.dataBase = new SqlConnection(Properties.Settings.Default.Conexion);
                
        //        dataBase.Open();
        //        this.comando = new SqlCommand();
        //        comando.Connection = dataBase;
        //        comando.CommandType = CommandType.Text;
        //        comando.CommandText = "SELECT * FROM frutas";
        //        this.dataAdapter = new SqlDataAdapter(comando);
        //        dataAdapter.Fill(this.tabla);

        //        dataAdapter.InsertCommand = new SqlCommand("INSERT INTO frutas VALUES (@p1, @p2, @p3)", dataBase);
        //        dataAdapter.InsertCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "nombre");
        //        dataAdapter.InsertCommand.Parameters.Add("@p2", SqlDbType.Float, 10, "peso");
        //        dataAdapter.InsertCommand.Parameters.Add("@p3", SqlDbType.Float, 10, "precio");

        //        dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM frutas WHERE id = @id");
        //        dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        //private void resetTabla()
        //{
        //    this.dataAdapter.Update(this.tabla);
        //    this.tabla.Clear();
        //    this.dataAdapter.Fill(this.tabla);
        //}

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
            Fruta aux;
            try
            {
                this.cajonManzana.Xml("CajonManzana.xml");
                this.cajonBanana.Xml("CajonBanana.xml");
                this.cajonDurazno.Xml("CajonDurazno.xml");
                this._manzana.Xml("manzana.xml");
                ((IDeserilizar)this._manzana).Xml("manzana.xml", out aux);
                MessageBox.Show((aux.ToString()));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MessageBox.Show("Finalizado");
        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //implementar estructura de manejo de excepciones
            this.btnPunto3_Click(sender, e);
            try
            {
                this.cajonDurazno += this._durazno;
                this.cajonDurazno += this._durazno;

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.(en el escritorio del cliente)
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos y crearlo en la clase Manejadora (de instancia).
            this.btnPunto4_Click(sender, e);
            Manejadora<Durazno> manejadora = new Manejadora<Durazno>();
            cajonDurazno.EventoPrecio += new Cajon<Durazno>.delegadoPrecio(manejadora.LimitePrecio);
            //cajonDurazno.EventoPrecio += manejadora.LimitePrecio;
            this.cajonDurazno += this._durazno;

        }

        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            this.ObtenerListadoFrutas();
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if(this.AgregarFrutas())
            {
                MessageBox.Show("Se agrego con exito las 3 frutas");
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar las 3 frutas");
            }
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
            //this.dataAdapter.Update(this.tabla);
            try
            {
                if(cajonManzana.ElimiarFruta(20))
                {
                    MessageBox.Show("TRUE");
                    //this.resetTabla();
                }
                else
                {
                    MessageBox.Show("FALSE");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ObtenerListadoFrutas()
        {
            try
            {
                using (SqlConnection dataBase = new SqlConnection(Properties.Settings.Default.Conexion))
                {
                    dataBase.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = dataBase;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "SELECT * FROM frutas";
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show(reader["id"].ToString() + "\n" + reader["nombre"].ToString() + "\n" + reader["peso"].ToString() + "\n" + reader["precio"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            //foreach (DataRow item in tabla.Rows)
            //{
            //    MessageBox.Show(item["id"].ToString() + "\n" + item["nombre"].ToString() + "\n" + item["peso"].ToString() + "\n" + item["precio"]);
            //}
        }

        private bool AgregarFrutas()
        {
            bool retorno = false;

            ////SIN DATA TABLE
            try
            {
                int contador = 0;
                using (SqlConnection dataBase = new SqlConnection(Properties.Settings.Default.Conexion))
                {
                    dataBase.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = dataBase;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO frutas ([nombre],[peso],[precio]) VALUES(@nombre,@peso,@precio)";
                    comando.Parameters.AddWithValue("@nombre", this._manzana.Nombre);
                    comando.Parameters.AddWithValue("@peso", this._manzana.Peso.ToString());
                    comando.Parameters.AddWithValue("@precio", "100");
                    contador += comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nombre", this._banana.Nombre);
                    comando.Parameters.AddWithValue("@peso", this._banana.Peso.ToString());
                    comando.Parameters.AddWithValue("@precio", "100");
                    contador += comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nombre", this._durazno.Nombre);
                    comando.Parameters.AddWithValue("@peso", this._durazno.Peso.ToString());
                    comando.Parameters.AddWithValue("@precio", "100");
                    contador += comando.ExecuteNonQuery();
                    if(contador == 3)
                    {
                        retorno = true;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            //DATA TABLE
            //DataRow row = this.tabla.NewRow();
            //row["nombre"] = this._manzana.Nombre;
            //row["peso"] = this._manzana.Peso;
            //row["precio"] = this.cajonManzana.PrecioUnitario;
            //this.tabla.Rows.Add(row);
            //row = this.tabla.NewRow();
            //row["nombre"] = this._banana.Nombre;
            //row["peso"] = this._banana.Peso;
            //row["precio"] = this.cajonBanana.PrecioUnitario;
            //this.tabla.Rows.Add(row);
            //row = this.tabla.NewRow();
            //row["nombre"] = this._durazno.Nombre;
            //row["peso"] = this._durazno.Peso;
            //row["precio"] = this.cajonDurazno.PrecioUnitario;
            //this.tabla.Rows.Add(row);
            //if(this.dataAdapter.Update(this.tabla) == 3)
            //{
            //    retorno = true;
            //}
            return retorno;
        }

        ///AGREGAR
    }
}
