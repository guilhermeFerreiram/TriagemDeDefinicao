using System.Windows.Forms;
using TriagemDeDefinicao_Forms.Entities;

namespace TriagemDeDefinicao_Forms
{
    public partial class FrmTriagem : Form
    {
        public FrmTriagem()
        {
            InitializeComponent();
        }

        private List<Item> ListaDeItens()
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item("Óleo de Motor", "Rosqueie a vareta", new TimeSpan(0, 1, 0)));
            itens.Add(new Item("Comprssão", "Partida no motor", new TimeSpan(0, 25, 0)));
            itens.Add(new Item("Luzes", "Piscas, lanterna e farol", new TimeSpan(0, 61, 0)));
            return itens;
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputTextBox.Text == null || PlacaInputTextBox.Text == "")
            {
                MessageBox.Show("O campo placa não pode estar vazio!");
                return;
            }

            PlacaInputTextBox.ReadOnly = true;
            TabelaDataGridView.Rows.Clear();

            foreach (var item in ListaDeItens())
            {
                TabelaDataGridView.Rows.Add(item.Nome, item.Verificacao, item.TempoDeExecucao.TotalMinutes);
            }

            ResultadoButton.Visible = true;
            IniciarButton.Visible = false;
        }

        private void ResultadoButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ResultadoColumn"].Value == null)
                {
                    MessageBox.Show("Selecione OK ou NG para TODOS os itens na tabela!");
                    return;
                }
            }

            NovaMoto.LimparDados();
            NovaMoto.DefinirPlaca(PlacaInputTextBox.Text);
            AdicionarItens();

            NovaMoto.CalcularTempoDeExecucao();
            NovaMoto.DefinirSituacao();

            ExibirResultado();
            ExibirBotoesPosResultado();
        }

        private void AdicionarItens()
        {
            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ResultadoColumn"].Value.ToString() == "NG")
                {
                    Item item = new Item();
                    item = ListaDeItens()[row.Index];
                    NovaMoto.AdicionarItem(item);
                }
            }
        }

        private void ExibirResultado()
        {
            PlacaTriadaTextBox.Text = NovaMoto.Placa;

            switch (NovaMoto.Situacao)
            {
                case Enums.Cor.Verde:
                    ComplexidadeTextBox.BackColor = Color.Green;
                    break;
                case Enums.Cor.Amarelo:
                    ComplexidadeTextBox.BackColor = Color.Yellow;
                    break;
                case Enums.Cor.Vermelho:
                    ComplexidadeTextBox.BackColor = Color.Red;
                    break;
            }

            TempoExecucaoTextBox.Text = NovaMoto.TempoDeExecucao.ToString();

            PlacaTriadaTextBox.Visible = true;
            ComplexidadeTextBox.Visible = true;
            TempoExecucaoTextBox.Visible = true;
        }

        private void ExibirBotoesPosResultado()
        {
            NovaTriagemButton.Visible = true;
        }

        private void NovaTriagemButton_Click(object sender, EventArgs e)
        {
            NovaMoto.LimparDados();
            TabelaDataGridView.Rows.Clear();

            OcultarBotoesPosResultado();
            PlacaTriadaTextBox.Visible = false;
            ComplexidadeTextBox.Visible = false;
            TempoExecucaoTextBox.Visible = false;
            ResultadoButton.Visible = false;

            IniciarButton.Visible = true;
            PlacaInputTextBox.Text = null;
            PlacaInputTextBox.ReadOnly = false;
        }

        private void OcultarBotoesPosResultado()
        {
            NovaTriagemButton.Visible = false;
        }
    }
}
