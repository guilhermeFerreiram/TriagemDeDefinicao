using TriagemDeDefinicao_Forms.Entities;

namespace TriagemDeDefinicao_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var item in ListaDeItens())
            {
                TabelaDataGridView.Rows.Add(item.Nome, item.Verificacao, item.TempoDeExecucao.TotalMinutes);
            }
        }

        private List<Item> ListaDeItens()
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item("Óleo de Motor", "Rosqueie a vareta", new TimeSpan(0, 1, 0)));
            itens.Add(new Item("Comprssão", "Partida no motor", new TimeSpan(0, 2, 0)));
            itens.Add(new Item("Luzes", "Piscas, lanterna e farol", new TimeSpan(0, 3, 0)));
            return itens;
        }
    }
}
