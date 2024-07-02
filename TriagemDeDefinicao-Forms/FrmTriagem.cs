using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using TriagemDeDefinicao_Forms.Entities;
using System.Globalization;

namespace TriagemDeDefinicao_Forms
{
    public partial class FrmTriagem : Form
    {
        public FrmTriagem()
        {
            InitializeComponent();
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (PlacaInputEstaVazio()) return;
            if (CorPreTriagemEstaVazio()) return;

            TabelaDataGridView.Rows.Clear();

            foreach (var item in Triagem.Itens)
            {
                TabelaDataGridView.Rows.Add(item.Nome, item.Verificacao);
            }

            ResultadoButton.Visible = true;
            IniciarButton.Visible = false;

            Triagem.DefinirInicioTriagem(DateTime.Now);
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

        private bool CorPreTriagemEstaVazio()
        {
            if (CorPreTriagemComboBox.Text == "" || CorPreTriagemComboBox.Text == null)
            {
                MessageBox.Show("O campo Cor Anterior à Triagem não pode estar vazio!");
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
            if (CorPreTriagemEstaVazio()) return;
            if (!PreenchimentoCorreto()) return;

            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                row.Cells["ResultadoColumn"].ReadOnly = true;
            }

            Triagem.Moto.LimparDados();

            Triagem.Moto.DefinirPlaca(PlacaInputTextBox.Text);
            Triagem.Moto.DefinirCorPreTriagem(CorPreTriagemComboBox.Text);

            AdicionarItens(Triagem.Moto);

            Triagem.Resultado();

            Triagem.DefinirFinalTriagem(DateTime.Now);
            Triagem.CalcularTempoTriagem();

            ExibirResultado();
            ExibirBotoesPosResultado();

            ResultadoButton.Visible = false;
        }

        private void AdicionarItens(Moto moto)
        {
            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ResultadoColumn"].Value.ToString().Trim().ToUpper() == "NG")
                {
                    Item item = new Item();
                    item = Triagem.Itens[row.Index];
                    moto.AdicionarItem(item);
                }
            }
        }

        private void ExibirResultado()
        {
            PlacaTriadaOutputTextBox.Text = Triagem.Moto.Placa;

            switch (Triagem.Moto.Situacao)
            {
                case Enums.Cor.Verde:
                    ComplexidadeOutputTextBox.BackColor = System.Drawing.Color.Green;
                    break;
                case Enums.Cor.Amarelo:
                    ComplexidadeOutputTextBox.BackColor = System.Drawing.Color.Yellow;
                    break;
                case Enums.Cor.Vermelho:
                    ComplexidadeOutputTextBox.BackColor = System.Drawing.Color.Red;
                    break;
            }

            TempoEstimadoOutputTextBox.Text = Triagem.Moto.ExibirTempoEstimado();

            TempoTriagemOutputTextBox.Text = ExibirTempoDeTriagem();

            PlacaTriadaOutputTextBox.Visible = true;
            ComplexidadeOutputTextBox.Visible = true;
            TempoEstimadoOutputTextBox.Visible = true;
            TempoTriagemOutputTextBox.Visible = true;
        }

        private void ExibirBotoesPosResultado()
        {
            EditarButton.Visible = true;
            SalvarButton.Visible = true;
        }

        private void NovaTriagem()
        {
            Triagem.Moto.LimparDados();
            TabelaDataGridView.Rows.Clear();

            OcultarResultado();
            ResultadoButton.Visible = false;

            IniciarButton.Visible = true;
            PlacaInputTextBox.Text = null;
            CorPreTriagemComboBox.SelectedIndex = -1;
        }

        private void OcultarResultado()
        {
            EditarButton.Visible = false;
            SalvarButton.Visible = false;
            PlacaTriadaOutputTextBox.Visible = false;
            ComplexidadeOutputTextBox.Visible = false;
            TempoEstimadoOutputTextBox.Visible = false;
            TempoTriagemOutputTextBox.Visible = false;
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
                    item = Triagem.Itens[e.RowIndex];
                    if (item.Situacao == Enums.Cor.Amarelo)
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (item.Situacao == Enums.Cor.Vermelho)
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Red;
                    }
                }
                else if (e.Value != null && e.Value.ToString().Trim().ToUpper() == "OK")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void SalvarButton_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string checklistFolderPath = System.IO.Path.Combine(desktopPath, "CHECKLISTS");

            Directory.CreateDirectory(checklistFolderPath);

            string filePath = System.IO.Path.Combine(checklistFolderPath, $"CheckList_{Triagem.Moto.Placa}_{DateTime.Now.ToString("yyyy-MM-dd")}.pdf");

            CreatePdf(filePath);

            MessageBox.Show($"Resultado salvo com sucesso em {checklistFolderPath}");

            NovaTriagem();
        }

        private void CreatePdf(string filePath)
        {
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    document.Add(new Paragraph($"CHECKLIST - PLACA: {Triagem.Moto.Placa} - {DateTime.Now.ToString("yyyy-MM-dd")}"));
                    document.Add(new Paragraph($"COR ANTERIOR À TRIAGEM: {Triagem.Moto.CorPreTriagem.ToString().ToUpper()}"));
                    document.Add(new Paragraph($"COMPLEXIDADE: {Triagem.Moto.Situacao.ToString().ToUpper()}"));
                    document.Add(new Paragraph($"TEMPO ESTIMADO: {Triagem.Moto.ExibirTempoEstimado()}"));
                    document.Add(new Paragraph($"TEMPO DE TRIAGEM: {ExibirTempoDeTriagem()}"));

                    Table table = new Table(2);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    Style headerStyle = new Style()
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBold();

                    Style cellStyle = new Style()
                        .SetTextAlignment(TextAlignment.CENTER);

                    Cell headerCell;

                    headerCell = new Cell().Add(new Paragraph("Item"));
                    headerCell.AddStyle(headerStyle);
                    table.AddHeaderCell(headerCell);

                    headerCell = new Cell().Add(new Paragraph("Resultado"));
                    headerCell.AddStyle(headerStyle);
                    table.AddHeaderCell(headerCell);

                    foreach (DataGridViewRow row in TabelaDataGridView.Rows)
                    {
                        string nomeItem = row.Cells["NomeColumn"].Value.ToString().Trim();
                        string resultado = row.Cells["ResultadoColumn"].Value.ToString().ToUpper().Trim();

                        AddTableRow(table, nomeItem, resultado, cellStyle);
                    }

                    document.Add(table);

                    document.Close();
                }
            }
        }

        private void AddTableRow(Table table, string nomeItem, string resultado, Style cellStyle)
        {
            table.AddCell(new Cell().Add(new Paragraph(nomeItem)).AddStyle(cellStyle));

            Cell resultCell = new Cell().Add(new Paragraph(resultado)).AddStyle(cellStyle);
            if (resultado == "OK")
            {
                resultCell.SetBackgroundColor(ColorConstants.GREEN);
            }
            else if (resultado == "NG")
            {
                resultCell.SetBackgroundColor(ColorConstants.YELLOW);
            }

            table.AddCell(resultCell);
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TabelaDataGridView.Rows)
            {
                row.Cells["ResultadoColumn"].ReadOnly = false;
            }

            Triagem.Moto.LimparDados();
            OcultarResultado();

            ResultadoButton.Visible = true;
        }

        private string ExibirTempoDeTriagem()
        {
            if (Triagem.TempoTriagem.Hours > 0)
            {
                return $"{Triagem.TempoTriagem.Hours.ToString()}H{Triagem.TempoTriagem.Minutes.ToString()}m{Triagem.TempoTriagem.Seconds.ToString()}s";
            }
            else
            {
                return $"{Triagem.TempoTriagem.Minutes.ToString()}m{Triagem.TempoTriagem.Seconds.ToString()}s";
            }
        }
    }
}
