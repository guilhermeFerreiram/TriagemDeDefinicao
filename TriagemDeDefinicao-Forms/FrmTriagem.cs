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
            itens.Add(new Item("�leo de Motor", "Verifique o n�vel rosqueando na Sport e encostando na Pop. Primeira troca com 1.000km e a cada 5.000km. Complete o n�vel se necess�rio.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Compress�o do Motor", "Verifique acionando o pedal de partida.", new TimeSpan(0, 25, 0)));
            itens.Add(new Item("Rota��o de Marcha lenta", "Sport: 1.500 � 150 rpm   Pop: 1400 � 100 rpm.", new TimeSpan(0, 3, 0)));
            itens.Add(new Item("Sistema de Escapamento", "Com a motocicleta ligada, verifique vazamento de g�s.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Elemento de Filtro de Ar", "Verifique o quanto est� sujo e a vida �til.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Embreagem", "Verifique: folga livre do manete ( Sport: 8 � 13mm Pop: 10 � 20mm).", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Freio dianteiro", "Verifique: folga livre do manete ( Sport: 15 � 20mm Pop: 10 � 20mm).", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Freio Traseiro", "Verifique: folga livre do pedal ( Sport: 15 � 20mm Pop: 20 � 30mm).", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Passagem dos Cabos", "verifique passagem dos cabos: Veloc�metro, embreagem e freio.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Roda Dianteira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Roda Traseira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Corrente de Transmiss�o", "Verificar folga, alongamento e lubrifica��o.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Coroa", "Verificar perfil dos dentes.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Pinh�o", "Verificar perfil dos dentes.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Caixa de Dire��o", "Verificar folga e calos de dire��o.", new TimeSpan(0, 25, 0)));
            //itens.Add(new Item("Suspens�o Dianteira", "Verificar vazamento, parafusos soltos e alinhamento de montagem.", new TimeSpan(0, 10, 0)));
            //itens.Add(new Item("Amortecedor traseiro", "Verificar vazamento, parafusos soltos e bucha gasta.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Folga do Acelerador", "Verifique: folga livre da manopla do acelerador (Sport: 3 � 6mm Pop: 2 � 6mm).", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Carenagens", "verificar carenagens soltas.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("El�trica: Luzes e interruptores", "Verifique funcionamneto: farol, farol alto, setas, lanterna, luz de freio, ilumina��o de placa, buzina.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Pneus", "Verifique: profundidade da banda de rodagem, press�o.", new TimeSpan(0, 20, 0)));
            //itens.Add(new Item("Vazamento", "Verificar vazamento no motor.", new TimeSpan(0, 10, 0)));
            //itens.Add(new Item("Sistema de Igni��o", "Verificar vela, cabo de vela e cachimbo.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Parafusos", "Verifique: Parafusos soltos ou sem parafusos (inspe��o visual).", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Sintoma cr�nico que depende de an�lise", "Moto falhando; Moto morrendo; Embregem patinando; Ru�do no motor; Luz da inje��o acesa; Chassi desalinhado;", new TimeSpan(1, 0, 0)));
            return itens;
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputEstaVazio()) return;

            TabelaDataGridView.Rows.Clear();

            foreach (var item in ListaDeItens())
            {
                TabelaDataGridView.Rows.Add(item.Nome, item.Verificacao);
            }

            ResultadoButton.Visible = true;
            IniciarButton.Visible = false;
        }

        private bool PlacaInputEstaVazio()
        {
            if (PlacaInputTextBox.Text == null || PlacaInputTextBox.Text.Trim() == "")
            {
                MessageBox.Show("O campo placa n�o pode estar vazio!");
                return true;
            }
            return false;
        }

        private bool PreenchimentoCorreto()
        {
            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ResultadoColumn"].Value == null || row.Cells["ResultadoColumn"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Escreva OK ou NG para TODOS os itens na tabela!");
                    return false;
                }

                if (row.Cells["ResultadoColumn"].Value.ToString().Trim().ToUpper() != "OK" && row.Cells["ResultadoColumn"].Value.ToString().Trim().ToUpper() != "NG")
                {
                    MessageBox.Show("Somente OK e NG s�o aceitos na coluna Resultado. Certifique-se de que n�o escreveu incorretamente!");
                    return false;
                }
            }

            return true;
        }

        private void ResultadoButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputEstaVazio()) return;

            if (!PreenchimentoCorreto()) return;

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

                if (row.Cells["ResultadoColumn"].Value.ToString().Trim().ToUpper() == "NG")
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

            TempoExecucaoTextBox.Text = $"{NovaMoto.TempoDeExecucao.Hours.ToString()}h{NovaMoto.TempoDeExecucao.Minutes.ToString()}m";

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

        private void TabelaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TabelaDataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
        }

        private void TabelaDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TabelaDataGridView.IsCurrentCellDirty)
            {
                TabelaDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void TabelaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (TabelaDataGridView.Columns[e.ColumnIndex].Name == "ResultadoColumn")
            {
                if (e.Value != null && e.Value.ToString().Trim().ToUpper() == "NG")
                {
                    Item item = new Item();
                    item = ListaDeItens()[e.RowIndex];
                    if (item.Situacao == Enums.Cor.Amarelo)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else if (item.Situacao == Enums.Cor.Vermelho)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
                else if (e.Value != null && e.Value.ToString().Trim().ToUpper() == "OK")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
