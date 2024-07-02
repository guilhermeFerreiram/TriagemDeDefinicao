using TriagemDeDefinicao_Forms.Enums;

namespace TriagemDeDefinicao_Forms.Entities
{
    internal class Moto
    {
        public string Placa { get; private set; }
        public List<Item> Itens { get; private set; }
        public TimeSpan TempoEstimado { get; private set; }
        public Cor Situacao { get; private set; }
        public Cor CorPreTriagem { get; private set; }

        public Moto()
        {
            Itens = new List<Item>();
            TempoEstimado = TimeSpan.Zero;
            Situacao = Cor.Verde;
        }
        public void CalcularTempoDeExecucao()
        {
            foreach (Item item in Itens)
            {
                TempoEstimado += item.TempoDeExecucao;
            }
        }

        public void DefinirSituacao()
        {
            if (TempoEstimado.TotalMinutes < 25)
            {
                Situacao = Cor.Verde;
            }
            else if (TempoEstimado.TotalMinutes >= 25 && TempoEstimado.TotalMinutes < 60)
            {
                Situacao = Cor.Amarelo;
            }
            else
            {
                Situacao = Cor.Vermelho;
            }
        }

        public void DefinirPlaca(string placa)
        {
            Placa = placa.ToUpper().Trim();
        }

        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }

        public void LimparDados()
        {
            Placa = "";
            Itens.Clear();
            TempoEstimado = TimeSpan.Zero;
            Situacao = Cor.Verde;
        }

        public string ExibirTempoEstimado()
        {
            return $"{TempoEstimado.Hours.ToString()}h{TempoEstimado.Minutes.ToString()}m";
        }

        public void DefinirCorPreTriagem(string cor)
        {
            switch (cor)
            {
                case "Verde":
                    CorPreTriagem = Cor.Verde;
                    break;
                case "Amarelo":
                    CorPreTriagem = Cor.Amarelo;
                    break;
                case "Vermelho":
                    CorPreTriagem = Cor.Vermelho;
                    break;
            }
        }
    }
}
