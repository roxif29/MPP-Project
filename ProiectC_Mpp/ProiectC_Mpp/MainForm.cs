using ProiectC_Mpp.repository.DB;
using System;
using ProiectC_Mpp.service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProiectC_Mpp.model;

namespace ProiectC_Mpp
{
    public partial class MainForm : Form

    {

        AngajatDbRepository angajatDbRepository = new AngajatDbRepository();
        ParticipantDbRepository participantDbRepository = new ParticipantDbRepository();
        CursaDbRepository cursaDbRepository = new CursaDbRepository();
        InscriereDbRepository inscriereDbRepository = new InscriereDbRepository();
        ServiceAll service;

        private void initialize()
        {
            curseDataGridView.DataSource = service.getAllCurse();
            foreach(Cursa c in service.getAllCurse())
            {
                Console.WriteLine("id este {0}", c.Id);
            }
            participantiDataGridView.DataSource = service.getAllParticipanti();
            setComboBox();
            
        }

        public MainForm()
        {
            InitializeComponent();
            service = new ServiceAll(angajatDbRepository, cursaDbRepository, inscriereDbRepository, participantDbRepository);
            initialize();  
        }

        private void setComboBox()
        {
            List<int> lista = new List<int>();
            IEnumerable<Cursa> curse = service.getAllCurse();
            foreach(Cursa c in curse){
                lista.Add(c.CapacMotor);
            }

            categorieComboBox.DataSource = lista;

            capMotorComboBox.DataSource = lista;
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void curseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = curseDataGridView.Rows[index];
            idTextBox.Text = selectedRow.Cells[0].Value.ToString();
        }
        private void curseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = curseDataGridView.Rows[index];
            idTextBox.Text = selectedRow.Cells[0].Value.ToString();
        }
        private void participantiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = participantiDataGridView.Rows[index];
            numeTextBox.Text = selectedRow.Cells[2].Value.ToString();
            echipaTextBox.Text = selectedRow.Cells[3].Value.ToString();
            capMotorComboBox.SelectedIndex = capMotorComboBox.FindString(selectedRow.Cells[1].Value.ToString());
        }

        private void participantiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = participantiDataGridView.Rows[index];
            numeTextBox.Text = selectedRow.Cells[2].Value.ToString();
            echipaTextBox.Text = selectedRow.Cells[3].Value.ToString();
            capMotorComboBox.SelectedIndex = capMotorComboBox.FindString(selectedRow.Cells[1].Value.ToString());
        }

        private void inscrieButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idCursa = Int32.Parse(idTextBox.Text);
                string nume = numeTextBox.Text;
                string echipa = echipaTextBox.Text;
                int capacMotor = Int32.Parse(categorieComboBox.SelectedItem.ToString());

               Participant p = service.findParticipantByNumeSiEchipaSiCapacMotor(capacMotor,nume,echipa);
                Console.WriteLine(p.ToString());
                Cursa c = service.findCursaByCapacMotor(capacMotor);
                Console.WriteLine(c.ToString());
                c.Id = idCursa;
                Inscriere inscriere = new Inscriere(c, p);

                if (c.CapacMotor==capacMotor)
                {
                    inscriereDbRepository.save(inscriere);
                     cursaDbRepository.delete(idCursa);
                    //sterg ca sa pot adauga noua cursa cu nrpers updatat
                    c.NrPers = c.NrPers + 1;
                    cursaDbRepository.save(c);

                    //curseDataGridView.DataSource = service.findByCapacMotor(Int32.Parse(categorieComboBox.SelectedItem.ToString()));
                    curseDataGridView.DataSource = service.getAllCurse();
                }
                else
                    MessageBox.Show("Capacitatea motorului != categoria cursei");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Selectati atat participantul cat si cursa pentru inscriere");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Participantul este deja inscris la cursa");
            }
        }

        private void categorieComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capMotor = Int32.Parse(categorieComboBox.SelectedItem.ToString());
            //curseDataGridView.DataSource = service.findByCapacMotor(capMotor);
            curseDataGridView.DataSource = service.getAllCurse();
        }

        private void capMotorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void echipaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cautareButton_Click(object sender, EventArgs e)
        {
            string echipa = cautareDupaEchipaTextBox.Text;
            participantiDataGridView.DataSource = service.getAllParticipantsByEchipa(echipa);
        }

        private void cautareDupaEchipaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
