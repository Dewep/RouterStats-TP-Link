using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace RouterStats
{
    public partial class RouterStats : Form
    {
        private bool fetch_clients = true;
        private Timer timer;
        private List<Client> clients = new List<Client>();
        private List<Stat> stats = new List<Stat>();
        private NetworkCredential credential = new NetworkCredential("admin", "admin");

        public RouterStats()
        {
            InitializeComponent();
            header.Controls.Add(new_label("Appareil", size: 9, bold: true), 0, 0);
            header.Controls.Add(new_label("Débit", size: 9, bold: true), 1, 0);
            header.Controls.Add(new_label("Total", size: 9, bold: true), 2, 0);
            timer = new Timer();
            timer.Tick += new EventHandler(Generate_Table_Event);
            timer.Interval = 5000;
            timer.Start();
            Generate_Table();
        }

        public Label new_label(string content, bool center = true, float size = 8, bool bold = false)
        {
            Label label = new Label() { Text = content };
            if (center)
                label.TextAlign = ContentAlignment.TopCenter;
            else
                label.TextAlign = ContentAlignment.TopLeft;
            if (size != 8)
                label.Font = new Font(label.Font.FontFamily, size);
            if (bold)
                label.Font = new Font(label.Font, FontStyle.Bold);
            return (label);
        }

        private void FetchDataClients()
        {
            try
            {
                var request = (HttpWebRequest) WebRequest.Create("http://192.168.1.1/userRpm/AssignedIpAddrListRpm.htm?Refresh=Refresh");
                request.Credentials = credential;
                var response = (HttpWebResponse) request.GetResponse();
                var stream = new StreamReader(response.GetResponseStream());
                stream.ReadLine();
                stream.ReadLine();
                string line = "";
                clients.Clear();
                while ((line = stream.ReadLine()) != "0,0 );")
                {
                    string[] param = line.Split(new Char[] { ' ', ',', '"' }, StringSplitOptions.RemoveEmptyEntries);
                    clients.Add(new Client() { ip = param[2], name = param[0] });
                }
                stream.Close();
                fetch_clients = false;
            }
            catch (Exception) { }
        }

        private void FetchDataStats(bool delete_all = false)
        {
            try
            {
                var request = (HttpWebRequest) WebRequest.Create("http://192.168.1.1/userRpm/SystemStatisticRpm.htm?itnerval=10&Num_per_page=100" + (delete_all ? "&DeleteAll=All" : ""));
                request.Credentials = credential;
                var response = (HttpWebResponse) request.GetResponse();
                var stream = new StreamReader(response.GetResponseStream());
                stream.ReadLine();
                stream.ReadLine();
                string line = "";
                stats.Clear();
                while ((line = stream.ReadLine()) != "0,0 );")
                {
                    string[] param = line.Split(new Char[] { ' ', ',', '"' }, StringSplitOptions.RemoveEmptyEntries);
                    stats.Add(new Stat() { ip = param[1], current = int.Parse(param[6]) / 1000, total = double.Parse(param[4]) / 1000 });
                }
                stream.Close();
            }
            catch (Exception) { }
        }

        private void Generate_Table_Event(object sender, EventArgs e)
        {
            Generate_Table();
        }

        private void Generate_Table(bool delete_all = false)
        {
            if (fetch_clients)
                FetchDataClients();
            FetchDataStats(delete_all);
            panel.Visible = false;
            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();
            panel.Controls.Clear();
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            int total_debit = 0;
            double total_total = 0;
            foreach (Stat s in stats)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                string name = s.getClient(clients);
                panel.Controls.Add(new_label(name, center: false), 0, panel.RowCount - 1);
                panel.Controls.Add(new_label(s.current + " Ko/s"), 1, panel.RowCount - 1);
                panel.Controls.Add(new_label((s.total / 1000.0).ToString("F3") + " Mo"), 2, panel.RowCount - 1);
                if (name == s.ip)
                    fetch_clients = true;
                total_debit += s.current;
                total_total += s.total;
            }
            panel.RowCount = panel.RowCount + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panel.Controls.Add(new_label("Total", center: false, bold: true), 0, panel.RowCount - 1);
            panel.Controls.Add(new_label(total_debit + " Ko/s"), 1, panel.RowCount - 1);
            panel.Controls.Add(new_label((total_total / 1000.0).ToString("F3") + " Mo"), 2, panel.RowCount - 1);
            panel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void reinit_Click(object sender, EventArgs e)
        {
            Generate_Table(true);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class Stat
    {
        public string ip;
        public int current;
        public double total;
        public string getClient(List<Client> clients)
        {
            foreach (Client c in clients)
            {
                if (c.ip == ip)
                    return c.name;
            }
            return ip;
        }
    }
    public class Client
    {
        public string ip;
        public string name;
    }
}
