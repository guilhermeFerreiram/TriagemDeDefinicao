﻿using TriagemDeDefinicao_Forms.Entities;

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
            ResultadoColumn = new DataGridViewTextBoxColumn();
            PlacaInputTextBox = new TextBox();
            PlacaTextBox = new TextBox();
            IniciarButton = new Button();
            ResultadoButton = new Button();
            PlacaTriadaTextBox = new TextBox();
            ComplexidadeTextBox = new TextBox();
            TempoEstimadoTextBox = new TextBox();
            SalvarButton = new Button();
            EditarButton = new Button();
            TempoTriagemTextBox = new TextBox();
            CorPreTriagemTextBox = new TextBox();
            CorPreTriagemComboBox = new ComboBox();
            Triagem = new Triagem();
            ((System.ComponentModel.ISupportInitialize)TabelaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // TabelaDataGridView
            // 
            TabelaDataGridView.AllowUserToAddRows = false;
            TabelaDataGridView.AllowUserToDeleteRows = false;
            TabelaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TabelaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaDataGridView.Columns.AddRange(new DataGridViewColumn[] { NomeColumn, VerificacaoColumn, ResultadoColumn });
            TabelaDataGridView.Location = new Point(84, 130);
            TabelaDataGridView.Name = "TabelaDataGridView";
            TabelaDataGridView.RowHeadersWidth = 62;
            TabelaDataGridView.Size = new Size(1700, 600);
            TabelaDataGridView.TabIndex = 0;
            TabelaDataGridView.CellFormatting += TabelaDataGridView_CellFormatting;
            TabelaDataGridView.CellValueChanged += TabelaDataGridView_CellValueChanged;
            TabelaDataGridView.CurrentCellDirtyStateChanged += TabelaDataGridView_CurrentCellDirtyStateChanged;
            // 
            // NomeColumn
            // 
            NomeColumn.Frozen = true;
            NomeColumn.HeaderText = "Nome";
            NomeColumn.MinimumWidth = 8;
            NomeColumn.Name = "NomeColumn";
            NomeColumn.ReadOnly = true;
            NomeColumn.Width = 97;
            // 
            // VerificacaoColumn
            // 
            VerificacaoColumn.Frozen = true;
            VerificacaoColumn.HeaderText = "Verificação";
            VerificacaoColumn.MinimumWidth = 8;
            VerificacaoColumn.Name = "VerificacaoColumn";
            VerificacaoColumn.ReadOnly = true;
            VerificacaoColumn.Width = 132;
            // 
            // ResultadoColumn
            // 
            ResultadoColumn.HeaderText = "Resultado";
            ResultadoColumn.MinimumWidth = 8;
            ResultadoColumn.Name = "ResultadoColumn";
            ResultadoColumn.Width = 126;
            // 
            // PlacaInputTextBox
            // 
            PlacaInputTextBox.Location = new Point(249, 80);
            PlacaInputTextBox.Name = "PlacaInputTextBox";
            PlacaInputTextBox.Size = new Size(150, 31);
            PlacaInputTextBox.TabIndex = 1;
            // 
            // PlacaTextBox
            // 
            PlacaTextBox.Location = new Point(84, 80);
            PlacaTextBox.Name = "PlacaTextBox";
            PlacaTextBox.ReadOnly = true;
            PlacaTextBox.Size = new Size(150, 31);
            PlacaTextBox.TabIndex = 2;
            PlacaTextBox.Text = "Placa:";
            // 
            // IniciarButton
            // 
            IniciarButton.Location = new Point(1472, 77);
            IniciarButton.Name = "IniciarButton";
            IniciarButton.Size = new Size(112, 34);
            IniciarButton.TabIndex = 3;
            IniciarButton.Text = "Iniciar";
            IniciarButton.UseVisualStyleBackColor = true;
            IniciarButton.Click += IniciarButton_Click;
            // 
            // ResultadoButton
            // 
            ResultadoButton.Location = new Point(85, 753);
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
            PlacaTriadaTextBox.Location = new Point(1097, 753);
            PlacaTriadaTextBox.Name = "PlacaTriadaTextBox";
            PlacaTriadaTextBox.ReadOnly = true;
            PlacaTriadaTextBox.Size = new Size(150, 31);
            PlacaTriadaTextBox.TabIndex = 5;
            PlacaTriadaTextBox.Visible = false;
            // 
            // ComplexidadeTextBox
            // 
            ComplexidadeTextBox.Location = new Point(1282, 753);
            ComplexidadeTextBox.Name = "ComplexidadeTextBox";
            ComplexidadeTextBox.ReadOnly = true;
            ComplexidadeTextBox.Size = new Size(150, 31);
            ComplexidadeTextBox.TabIndex = 7;
            ComplexidadeTextBox.Visible = false;
            // 
            // TempoEstimadoTextBox
            // 
            TempoEstimadoTextBox.Location = new Point(1460, 753);
            TempoEstimadoTextBox.Name = "TempoEstimadoTextBox";
            TempoEstimadoTextBox.ReadOnly = true;
            TempoEstimadoTextBox.Size = new Size(150, 31);
            TempoEstimadoTextBox.TabIndex = 8;
            TempoEstimadoTextBox.Visible = false;
            // 
            // SalvarButton
            // 
            SalvarButton.Location = new Point(402, 753);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(112, 34);
            SalvarButton.TabIndex = 10;
            SalvarButton.Text = "Salvar";
            SalvarButton.UseVisualStyleBackColor = true;
            SalvarButton.Visible = false;
            SalvarButton.Click += SalvarButton_Click;
            // 
            // EditarButton
            // 
            EditarButton.Location = new Point(213, 753);
            EditarButton.Name = "EditarButton";
            EditarButton.Size = new Size(174, 34);
            EditarButton.TabIndex = 11;
            EditarButton.Text = "Editar Seleção";
            EditarButton.UseVisualStyleBackColor = true;
            EditarButton.Visible = false;
            EditarButton.Click += EditarButton_Click;
            // 
            // TempoTriagemTextBox
            // 
            TempoTriagemTextBox.Location = new Point(1460, 811);
            TempoTriagemTextBox.Name = "TempoTriagemTextBox";
            TempoTriagemTextBox.ReadOnly = true;
            TempoTriagemTextBox.Size = new Size(150, 31);
            TempoTriagemTextBox.TabIndex = 12;
            TempoTriagemTextBox.Visible = false;
            // 
            // CorPreTriagemTextBox
            // 
            CorPreTriagemTextBox.Location = new Point(415, 80);
            CorPreTriagemTextBox.Name = "CorPreTriagemTextBox";
            CorPreTriagemTextBox.ReadOnly = true;
            CorPreTriagemTextBox.Size = new Size(212, 31);
            CorPreTriagemTextBox.TabIndex = 13;
            CorPreTriagemTextBox.Text = "Cor Anterior à Triagem:";
            // 
            // CorPreTriagemComboBox
            // 
            CorPreTriagemComboBox.FormattingEnabled = true;
            CorPreTriagemComboBox.Location = new Point(646, 80);
            CorPreTriagemComboBox.Name = "CorPreTriagemComboBox";
            CorPreTriagemComboBox.Size = new Size(182, 33);
            CorPreTriagemComboBox.TabIndex = 14;
            CorPreTriagemComboBox.Items.AddRange(new string[] { "Amarelo", "Vermelho", "Roxo"});
            // 
            // FrmTriagem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1702, 1029);
            Controls.Add(CorPreTriagemComboBox);
            Controls.Add(CorPreTriagemTextBox);
            Controls.Add(TempoTriagemTextBox);
            Controls.Add(EditarButton);
            Controls.Add(SalvarButton);
            Controls.Add(TempoEstimadoTextBox);
            Controls.Add(ComplexidadeTextBox);
            Controls.Add(PlacaTriadaTextBox);
            Controls.Add(ResultadoButton);
            Controls.Add(IniciarButton);
            Controls.Add(PlacaTextBox);
            Controls.Add(PlacaInputTextBox);
            Controls.Add(TabelaDataGridView);
            Name = "FrmTriagem";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)TabelaDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView TabelaDataGridView;
        private DataGridViewTextBoxColumn NomeColumn;
        private DataGridViewTextBoxColumn VerificacaoColumn;
        private TextBox PlacaInputTextBox;
        private TextBox PlacaTextBox;
        private Button IniciarButton;
        private Button ResultadoButton;
        private TextBox PlacaTriadaTextBox;
        private TextBox ComplexidadeTextBox;
        private TextBox TempoEstimadoTextBox;
        private DataGridViewTextBoxColumn ResultadoColumn;
        private Button SalvarButton;
        private Button EditarButton;
        private TextBox TempoTriagemTextBox;
        private TextBox CorPreTriagemTextBox;
        private ComboBox CorPreTriagemComboBox;
        private Triagem Triagem;
    }
}
