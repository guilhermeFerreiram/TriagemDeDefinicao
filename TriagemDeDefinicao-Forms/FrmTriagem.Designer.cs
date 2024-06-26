using TriagemDeDefinicao_Forms.Entities;

namespace TriagemDeDefinicao_Forms
{
    partial class FrmTriagem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabelaDataGridView = new DataGridView();
            NomeColumn = new DataGridViewTextBoxColumn();
            VerificacaoColumn = new DataGridViewTextBoxColumn();
            TempoDeExecucaoColumn = new DataGridViewTextBoxColumn();
            ResultadoColumn = new DataGridViewComboBoxColumn();
            PlacaInputTextBox = new TextBox();
            PlacaTextBox = new TextBox();
            IniciarButton = new Button();
            ResultadoButton = new Button();
            NovaMoto = new Moto();
            PlacaTriadaTextBox = new TextBox();
            ComplexidadeTextBox = new TextBox();
            TempoExecucaoTextBox = new TextBox();
            NovaTriagemButton = new Button();
            ((System.ComponentModel.ISupportInitialize)TabelaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // TabelaDataGridView
            // 
            TabelaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaDataGridView.Columns.AddRange(new DataGridViewColumn[] { NomeColumn, VerificacaoColumn, TempoDeExecucaoColumn, ResultadoColumn });
            TabelaDataGridView.Location = new Point(71, 85);
            TabelaDataGridView.Name = "TabelaDataGridView";
            TabelaDataGridView.RowHeadersWidth = 62;
            TabelaDataGridView.Size = new Size(668, 220);
            TabelaDataGridView.TabIndex = 0;
            // 
            // NomeColumn
            // 
            NomeColumn.Frozen = true;
            NomeColumn.HeaderText = "Nome";
            NomeColumn.MinimumWidth = 8;
            NomeColumn.Name = "NomeColumn";
            NomeColumn.ReadOnly = true;
            NomeColumn.Width = 150;
            // 
            // VerificacaoColumn
            // 
            VerificacaoColumn.Frozen = true;
            VerificacaoColumn.HeaderText = "Verificação";
            VerificacaoColumn.MinimumWidth = 8;
            VerificacaoColumn.Name = "VerificacaoColumn";
            VerificacaoColumn.ReadOnly = true;
            VerificacaoColumn.Width = 150;
            // 
            // TempoDeExecucaoColumn
            // 
            TempoDeExecucaoColumn.Frozen = true;
            TempoDeExecucaoColumn.HeaderText = "Tempo de Execução";
            TempoDeExecucaoColumn.MinimumWidth = 8;
            TempoDeExecucaoColumn.Name = "TempoDeExecucaoColumn";
            TempoDeExecucaoColumn.ReadOnly = true;
            TempoDeExecucaoColumn.Width = 150;
            // 
            // ResultadoColumn
            // 
            ResultadoColumn.Frozen = true;
            ResultadoColumn.HeaderText = "Resultado";
            ResultadoColumn.Items.AddRange(new object[] { "NG", "OK" });
            ResultadoColumn.MinimumWidth = 8;
            ResultadoColumn.Name = "ResultadoColumn";
            ResultadoColumn.Width = 150;
            // 
            // PlacaInputTextBox
            // 
            PlacaInputTextBox.Location = new Point(239, 48);
            PlacaInputTextBox.Name = "PlacaInputTextBox";
            PlacaInputTextBox.Size = new Size(150, 31);
            PlacaInputTextBox.TabIndex = 1;
            // 
            // PlacaTextBox
            // 
            PlacaTextBox.Location = new Point(83, 48);
            PlacaTextBox.Name = "PlacaTextBox";
            PlacaTextBox.ReadOnly = true;
            PlacaTextBox.Size = new Size(150, 31);
            PlacaTextBox.TabIndex = 2;
            PlacaTextBox.Text = "Placa:";
            // 
            // IniciarButton
            // 
            IniciarButton.Location = new Point(627, 45);
            IniciarButton.Name = "IniciarButton";
            IniciarButton.Size = new Size(112, 34);
            IniciarButton.TabIndex = 3;
            IniciarButton.Text = "Iniciar";
            IniciarButton.UseVisualStyleBackColor = true;
            IniciarButton.Click += IniciarButton_Click;
            // 
            // ResultadoButton
            // 
            ResultadoButton.Location = new Point(84, 316);
            ResultadoButton.Name = "ResultadoButton";
            ResultadoButton.Size = new Size(112, 34);
            ResultadoButton.TabIndex = 4;
            ResultadoButton.Text = "Resultado";
            ResultadoButton.UseVisualStyleBackColor = true;
            ResultadoButton.Visible = false;
            ResultadoButton.Click += ResultadoButton_Click;
            // 
            // PlacaTriadaTextBox
            // 
            PlacaTriadaTextBox.Location = new Point(71, 376);
            PlacaTriadaTextBox.Name = "PlacaTriadaTextBox";
            PlacaTriadaTextBox.ReadOnly = true;
            PlacaTriadaTextBox.Size = new Size(150, 31);
            PlacaTriadaTextBox.TabIndex = 5;
            PlacaTriadaTextBox.Visible = false;
            // 
            // ComplexidadeTextBox
            // 
            ComplexidadeTextBox.Location = new Point(256, 376);
            ComplexidadeTextBox.Name = "ComplexidadeTextBox";
            ComplexidadeTextBox.ReadOnly = true;
            ComplexidadeTextBox.Size = new Size(150, 31);
            ComplexidadeTextBox.TabIndex = 7;
            ComplexidadeTextBox.Visible = false;
            // 
            // TempoExecucaoTextBox
            // 
            TempoExecucaoTextBox.Location = new Point(434, 376);
            TempoExecucaoTextBox.Name = "TempoExecucaoTextBox";
            TempoExecucaoTextBox.ReadOnly = true;
            TempoExecucaoTextBox.Size = new Size(150, 31);
            TempoExecucaoTextBox.TabIndex = 8;
            TempoExecucaoTextBox.Visible = false;
            // 
            // NovaTriagemButton
            // 
            NovaTriagemButton.Location = new Point(215, 316);
            NovaTriagemButton.Name = "NovaTriagemButton";
            NovaTriagemButton.Size = new Size(139, 34);
            NovaTriagemButton.TabIndex = 9;
            NovaTriagemButton.Text = "Nova triagem";
            NovaTriagemButton.UseVisualStyleBackColor = true;
            NovaTriagemButton.Visible = false;
            NovaTriagemButton.Click += NovaTriagemButton_Click;
            // 
            // FrmTriagem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NovaTriagemButton);
            Controls.Add(TempoExecucaoTextBox);
            Controls.Add(ComplexidadeTextBox);
            Controls.Add(PlacaTriadaTextBox);
            Controls.Add(ResultadoButton);
            Controls.Add(IniciarButton);
            Controls.Add(PlacaTextBox);
            Controls.Add(PlacaInputTextBox);
            Controls.Add(TabelaDataGridView);
            Name = "FrmTriagem";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)TabelaDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView TabelaDataGridView;
        private DataGridViewTextBoxColumn NomeColumn;
        private DataGridViewTextBoxColumn VerificacaoColumn;
        private DataGridViewTextBoxColumn TempoDeExecucaoColumn;
        private DataGridViewComboBoxColumn ResultadoColumn;
        private TextBox PlacaInputTextBox;
        private TextBox PlacaTextBox;
        private Button IniciarButton;
        private Button ResultadoButton;
        private Moto NovaMoto;
        private TextBox PlacaTriadaTextBox;
        private TextBox ComplexidadeTextBox;
        private TextBox TempoExecucaoTextBox;
        private Button NovaTriagemButton;
    }
}
