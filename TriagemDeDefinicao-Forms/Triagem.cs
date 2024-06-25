using TriagemDeDefinicao_Forms.Entities;

namespace TriagemDeDefinicao_Forms
{
    public partial class Triagem : Form
    {
        public Triagem()
        {
            InitializeComponent();
        }

        private List<Item> ListaDeItens()
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item("Óleo de Motor", "Rosqueie a vareta", new TimeSpan(0, 1, 0)));
            itens.Add(new Item("Comprssão", "Partida no motor", new TimeSpan(0, 2, 0)));
            itens.Add(new Item("Luzes", "Piscas, lanterna e farol", new TimeSpan(0, 3, 0)));
            return itens;
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputTextBox.Text == null || PlacaInputTextBox.Text == "")
            {
                MessageBox.Show("O campo placa não pode estar vazio!");
                return;
            }

            Moto moto = new Moto(PlacaInputTextBox.Text);
            PlacaInputTextBox.ReadOnly = true;
            TabelaDataGridView.Rows.Clear();

            foreach (var item in ListaDeItens())
            {
                TabelaDataGridView.Rows.Add(item.Nome, item.Verificacao, item.TempoDeExecucao.TotalMinutes);
            }
        }
    }
}
