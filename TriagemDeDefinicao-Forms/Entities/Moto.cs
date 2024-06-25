using TriagemDeDefinicao_Forms.Enums;

namespace TriagemDeDefinicao_Forms.Entities
{
    internal class Moto
    {
        public string Placa { get; private set; }
        public List<Item> Itens { get; private set; }
        public TimeSpan TempoDeExecucao { get; private set; }
        public Cor Situacao { get; private set; }

        public Moto()
        {
            Itens = new List<Item>();
            TempoDeExecucao = TimeSpan.Zero;
            Situacao = Cor.Verde;
        }

        public Moto(string placa) : this()
        {
            Placa = placa;
        }

        public void Triagem(List<Item> itens)
        {
            for (int i = 0; i < itens.Count; i++)
            {
                Console.WriteLine($"#{i + 1} - {itens[i].Nome}, {itens[i].Verificacao}, {itens[i].TempoDeExecucao}");
                Console.Write("NG ou OK: ");
                string s = Console.ReadLine();

                if (s.ToUpper().Trim() == "OK")
                {
                    Itens.Add(itens[i]);
                }
            }
        }

        public void CalcularTempoDeExecucao()
        {
            foreach (Item item in Itens)
            {
                TempoDeExecucao += item.TempoDeExecucao;
            }
        }

        public void DefinirSituacao()
        {
            if (TempoDeExecucao.TotalMinutes <= 5)
            {
                Situacao = Cor.Verde;
            }
            else if (TempoDeExecucao.TotalMinutes > 5 && TempoDeExecucao.TotalMinutes <= 10)
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
