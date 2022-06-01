using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;


namespace Seri_Port
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        SerialPort serialPort1;
        string port;
        int baud;
        string data;

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            string[] portlar = SerialPort.GetPortNames();
            comboPortAdi.Items.Clear();
            foreach (string prt in portlar)
            {
                comboPortAdi.Items.Add(prt);
            }
            
            lblAlinan.Hide();
            
            txtAlinan.Hide();
           
           
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                lstBxDurum.Items.Clear();
                port = comboPortAdi.SelectedItem.ToString();
                lstBxDurum.Items.Add("Port: "+port);
                switch (comboBaudRate.SelectedIndex)
                {
                    case 0:
                        baud = 75;
                        break;
                    case 1:
                        baud = 110;
                        break;
                    case 2:
                        baud = 300;
                        break;
                    case 3:
                        baud = 1200;
                        break;
                    case 4:
                        baud = 2400;
                        break;
                    case 5:
                        baud = 4800;
                        break;
                    case 6:
                        baud = 9600;
                        break;
                    case 7:
                        baud = 19200;
                        break;
                    case 8:
                        baud = 38400;
                        break;
                    case 9:
                        baud = 57600;
                        break;
                    case 10:
                        baud = 115200;
                        break;
                    default:
                        baud = 9600;
                        break;
                }
                lstBxDurum.Items.Add("Veri Hýzý: "+baud.ToString());
                
                
                
                serialPort1 = new SerialPort(port, baud);
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                comboPortAdi.Text = port;
                comboBaudRate.Text = baud.ToString();


                serialPort1.Open();
                comboPortAdi.Enabled = false;
                comboBaudRate.Enabled = false;
                btnBaglan.Enabled = false;
                btnYenile.Enabled = false;


                btnBaglan.BackColor = Color.LightGreen;
                btnBaglan.Text = "BAÐLI: "+port;
                btnTemizle.Show();
                btnYeni.Show();
                lblAlinan.Show();
                txtAlinan.Show();

                
            }
            catch
            {
                lstBxDurum.Items.Add("Hata! Baðlantý gerçekleþtirilemedi.");
               
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Hide();
            serialPort1.Close();
            comboPortAdi.Enabled = true;
            comboBaudRate.Enabled = true;
            btnBaglan.Enabled = true;
            btnYenile.Enabled = true;
            btnBaglan.BackColor = Color.WhiteSmoke;
            btnBaglan.Text = "BAÐLAN";
            lstBxDurum.Items.Clear();
            lstBxDurum.Items.Add("Baðlantý Kapatýldý!");
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            string[] portlar = SerialPort.GetPortNames();
            comboPortAdi.Items.Clear();
            foreach (string prt in portlar)
            {
                comboPortAdi.Items.Add(prt);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAlinan.Clear();
            lstBxDurum.Items.Clear();

        }

        

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadExisting();
            txtAlinan.Text = txtAlinan.Text  + data + "\n";
            txtAlinan.Select(txtAlinan.TextLength, 0);
            txtAlinan.ScrollToCaret();
           

        }

        

    }
}
