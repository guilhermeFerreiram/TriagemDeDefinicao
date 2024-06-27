using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
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
            //itens.Add(new Item("Rotação de Marcha lenta", "Sport: 1.500 ± 150 rpm   Pop: 1400 ± 100 rpm.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Sistema de Escapamento", "Com a motocicleta ligada, verifique vazamento de gás.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Elemento de Filtro de Ar", "Verifique o quanto está sujo e a vida útil.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Embreagem", "Verifique: folga livre do manete ( Sport: 8 à 13mm Pop: 10 à 20mm).", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Freio dianteiro", "Verifique: folga livre do manete ( Sport: 15 à 20mm Pop: 10 à 20mm).", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Freio Traseiro", "Verifique: folga livre do pedal ( Sport: 15 à 20mm Pop: 20 à 30mm).", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Passagem dos Cabos", "verifique passagem dos cabos: Velocímetro, embreagem e freio.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Roda Dianteira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Roda Traseira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            //itens.Add(new Item("Corrente de Transmissão", "Verificar folga, alongamento e lubrificação.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Coroa", "Verificar perfil dos dentes.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Pinhão", "Verificar perfil dos dentes.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Caixa de Direção", "Verificar folga e calos de direção.", new TimeSpan(0, 25, 0)));
            //itens.Add(new Item("Suspensão Dianteira", "Verificar vazamento, parafusos soltos e alinhamento de montagem.", new TimeSpan(0, 10, 0)));
            //itens.Add(new Item("Amortecedor traseiro", "Verificar vazamento, parafusos soltos e bucha gasta.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Folga do Acelerador", "Verifique: folga livre da manopla do acelerador (Sport: 3 à 6mm Pop: 2 à 6mm).", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Carenagens", "verificar carenagens soltas.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Elétrica: Luzes e interruptores", "Verifique funcionamneto: farol, farol alto, setas, lanterna, luz de freio, iluminação de placa, buzina.", new TimeSpan(0, 6, 0)));
            //itens.Add(new Item("Pneus", "Verifique: profundidade da banda de rodagem, pressão.", new TimeSpan(0, 20, 0)));
            //itens.Add(new Item("Vazamento", "Verificar vazamento no motor.", new TimeSpan(0, 10, 0)));
            //itens.Add(new Item("Sistema de Ignição", "Verificar vela, cabo de vela e cachimbo.", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Parafusos", "Verifique: Parafusos soltos ou sem parafusos (inspeção visual).", new TimeSpan(0, 3, 0)));
            //itens.Add(new Item("Sintoma crônico que depende de análise", "Moto falhando; Moto morrendo; Embregem patinando; Ruído no motor; Luz da injeção acesa; Chassi desalinhado;", new TimeSpan(1, 0, 0)));
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
                MessageBox.Show("O campo placa não pode estar vazio!");
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
                    MessageBox.Show("Somente OK e NG são aceitos na coluna Resultado. Certifique-se de que não escreveu incorretamente!");
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
            SalvarButton.Visible = true;
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
            SalvarButton.Visible = false;
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

        private void SalvarButton_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string checklistFolderPath = System.IO.Path.Combine(desktopPath, "CHECKLISTS");

            Directory.CreateDirectory(checklistFolderPath);

            string filePath = System.IO.Path.Combine(checklistFolderPath, $"CheckList_{NovaMoto.Placa}_{DateTime.Now.ToString("yyyy-MM-dd")}.pdf");

            CreatePdf(filePath);

            MessageBox.Show($"Resultado salvo com sucesso em {checklistFolderPath}");
        }

        private void CreatePdf(string filePath)
        {
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    document.Add(new Paragraph("Olá, mundo! Este é um PDF gerado com iText 7 em um aplicativo Windows Forms."));

                    document.Close();
                }
            }
        }
    }
}
