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
            itens.Add(new Item("Óleo de Motor", "Verifique o nível rosqueando na Sport e encostando na Pop. Primeira troca com 1.000km e a cada 5.000km. Complete o nível se necessário.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Compressão do Motor", "Verifique acionando o pedal de partida.", new TimeSpan(0, 25, 0)));
            itens.Add(new Item("Rotação de Marcha lenta", "Sport: 1.500 ± 150 rpm   Pop: 1400 ± 100 rpm.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Sistema de Escapamento", "Com a motocicleta ligada, verifique vazamento de gás.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Elemento de Filtro de Ar", "Verifique o quanto está sujo e a vida útil.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Embreagem", "Verifique: folga livre do manete ( Sport: 8 à 13mm Pop: 10 à 20mm).", new TimeSpan(0, 8, 0)));
            itens.Add(new Item("Freio dianteiro", "Verifique: folga livre do manete ( Sport: 15 à 20mm Pop: 10 à 20mm).", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Freio Traseiro", "Verifique: folga livre do pedal ( Sport: 15 à 20mm Pop: 20 à 30mm).", new TimeSpan(0, 8, 0)));
            itens.Add(new Item("Passagem dos Cabos", "verifique passagem dos cabos: Velocímetro, embreagem e freio.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Roda Dianteira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            itens.Add(new Item("Roda Traseira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            itens.Add(new Item("Corrente de Transmissão", "Verificar folga, alongamento e lubrificação.", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Coroa", "Verificar perfil dos dentes.", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Pinhão", "Verificar perfil dos dentes.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Caixa de Direção", "Verificar folga e calos de direção.", new TimeSpan(0, 25, 0)));
            itens.Add(new Item("Suspensão Dianteira", "Verificar vazamento, parafusos soltos e alinhamento de montagem.", new TimeSpan(0, 10, 0)));
            itens.Add(new Item("Amortecedor traseiro", "Verificar vazamento, parafusos soltos e bucha gasta.", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Folga do Acelerador", "Verifique: folga livre da manopla do acelerador (Sport: 3 à 6mm Pop: 2 à 6mm).", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Carenagens", "verificar carenagens soltas.", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Elétrica: Luzes e interruptores", "Verifique funcionamneto: farol, farol alto, setas, lanterna, luz de freio, iluminação de placa, buzina.", new TimeSpan(0, 6, 0)));
            itens.Add(new Item("Pneus", "Verifique: profundidade da banda de rodagem, pressão.", new TimeSpan(0, 20, 0)));
            itens.Add(new Item("Vazamento", "Verificar vazamento no motor.", new TimeSpan(0, 10, 0)));
            itens.Add(new Item("Sistema de Ignição", "Verificar vela, cabo de vela e cachimbo.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Parafusos", "Verifique: Parafusos soltos ou sem parafusos (inspeção visual).", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Sintoma crônico que depende de análise", "Moto falhando; Moto morrendo; Embregem patinando; Ruído no motor; Luz da injeção acesa; Chassi desalinhado;", new TimeSpan(1, 0, 0)));
            return itens;
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputTextBox.Text == null || PlacaInputTextBox.Text == "")
            {
                MessageBox.Show("O campo placa não pode estar vazio!");
                return;
            }

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
