namespace TriagemDeDefinicao_Forms
{
    partial class Triagem
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
            ((System.ComponentModel.ISupportInitialize)TabelaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // TabelaDataGridView
            // 
            TabelaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaDataGridView.Columns.AddRange(new DataGridViewColumn[] { NomeColumn, VerificacaoColumn, TempoDeExecucaoColumn, ResultadoColumn });
            TabelaDataGridView.Location = new Point(30, 152);
            TabelaDataGridView.Name = "TabelaDataGridView";
            TabelaDataGridView.RowHeadersWidth = 62;
            TabelaDataGridView.Size = new Size(727, 225);
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
            // Triagem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(IniciarButton);
            Controls.Add(PlacaTextBox);
            Controls.Add(PlacaInputTextBox);
            Controls.Add(TabelaDataGridView);
            Name = "Triagem";
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
        private Button ResultadoButton;
        private TextBox PlacaInputTextBox;
        private TextBox PlacaTextBox;
        private Button IniciarButton;
    }
}
