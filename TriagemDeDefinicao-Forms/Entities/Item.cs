using TriagemDeDefinicao_Forms.Enums;

namespace TriagemDeDefinicao_Forms.Entities
{
    internal class Item
    {
        public string Nome { get; private set; }
        public string Verificacao { get; private set; }
        public TimeSpan TempoDeExecucao { get; private set; }
        public Cor Situacao { get; private set; }

        public Item() { }

        public Item(string nome, string verificacao, TimeSpan tempoDeExecucao)
        {
            Nome = nome;
            Verificacao = verificacao;
            TempoDeExecucao = tempoDeExecucao;
            DefinirSituacao();
        }

        public void DefinirSituacao()
        {
            if (TempoDeExecucao.TotalMinutes < 60)
            {
                Situacao = Cor.Amarelo;
            }
            else
            {
                Situacao = Cor.Vermelho;
            }
        }
    }
}
