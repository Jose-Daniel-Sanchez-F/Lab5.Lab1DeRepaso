using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5.Lab1DeRepaso
{
    public partial class Form1 : Form
    {
        List<Empleado> EmpleadoList=new List<Empleado>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leer();
            LeerMess();

            foreach (var empleado in EmpleadoList)
            {
                empleado.sueldoCalculado = empleado.sueldo * empleado.HorasMes;
  
            }
            dataGridView1.DataSource = null;

            dataGridView1.Refresh();
            dataGridView1.DataSource = EmpleadoList;
          
            dataGridView1.Refresh();

        }

        void Leer ()
        {

            FileStream stream = new FileStream("Empleados.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleado empleado = new Empleado();

                empleado.NoEmpleado = Convert.ToInt32(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.sueldo = Convert.ToDouble(reader.ReadLine());
                
                EmpleadoList.Add(empleado);

            }
            reader.Close();

        }
        void LeerMess()
        {

            FileStream stream = new FileStream("Enero.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleado empleado = new Empleado();

                string numero = reader.ReadLine();
                string horas = reader.ReadLine();

                foreach(var e in EmpleadoList )
                {
                    if(e.NoEmpleado ==Convert.ToInt32(numero))
                    {
                        e.HorasMes=Convert.ToInt32(horas);

                    }
                }

            }
            reader.Close();

        }
    }
}
