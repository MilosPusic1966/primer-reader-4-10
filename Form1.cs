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

namespace primer_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection("Data source=INF_4_PROFESOR\\SQLPBG; Initial catalog=MilosP2021; Integrated security=true");
            SqlCommand komanda = new SqlCommand("SELECT * FROM promet",veza);
            veza.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            double zbir = 0;
            while (citac.Read())
            {
                string ul_str, izl_str;
                if (citac.IsDBNull(1))
                {
                    ul_str = "0.00";
                }
                else
                {
                    zbir = zbir + (double)citac["ulaz"];
                    ul_str = citac["ulaz"].ToString();
                }

                if (citac.IsDBNull(2))
                {
                    izl_str = "0.00";
                }
                else
                {
                    zbir = zbir - (double)citac["izlaz"];
                    izl_str = citac["izlaz"].ToString();
                    // izl_str = string.Format("{0.00}", (double)citac["izlaz"]);
                }
                // izl_str.PadRight(15);

                string red = citac["povod"].ToString() +" " +ul_str + " "+izl_str+" "+zbir.ToString();
                listBox1.Items.Add(red);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection("Data source=INF_4_PROFESOR\\SQLPBG; Initial catalog=MilosP2021; Integrated security=true");
            SqlCommand komanda = new SqlCommand("SELECT * FROM promet", veza);
            veza.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            DataTable podaci = new DataTable();
            podaci.Load(citac);
            dataGridView1.DataSource = podaci;
            veza.Close();
        }
    }
}
