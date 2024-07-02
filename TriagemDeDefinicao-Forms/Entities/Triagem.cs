using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriagemDeDefinicao_Forms.Entities
{
    internal class Triagem
    {
        public List<Item> Itens { get; private set; }
        public Moto Moto { get; private set; }
        public DateTime InicioTriagem { get; private set; }
        public DateTime FinalTriagem { get; private set; }
        public TimeSpan TempoTriagem { get; set; }

        public Triagem()
        {
            Itens = new List<Item>();
            ListaDeItens();
            Moto = new Moto();
        }

        private void ListaDeItens()
        {
            Itens.Add(new Item("Óleo do Motor", "Verifique o nível rosqueando na Sport e encostando na Pop. Primeira troca com 1.000km e a cada 5.000km. Complete o nível se necessário.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Compressão do Motor", "Verifique acionando o pedal de partida.", new TimeSpan(0, 25, 0)));
            Itens.Add(new Item("Rotação de Marcha lenta", "Sport: 1.500 ± 150 rpm   Pop: 1400 ± 100 rpm.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Sistema de Escapamento", "Com a motocicleta ligada, verifique vazamento de gás.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Elétrica: Luzes e interruptores", "Verifique funcionamneto: farol, farol alto, setas, lanterna, luz de freio, iluminação de placa, buzina.", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Elemento de Filtro de Ar", "Verifique o quanto está sujo e a vida útil.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Embreagem", "Verifique: folga livre do manete ( Sport: 8 à 13mm Pop: 10 à 20mm).", new TimeSpan(0, 8, 0)));
            Itens.Add(new Item("Freio dianteiro", "Verifique: folga livre do manete ( Sport: 15 à 20mm Pop: 10 à 20mm).", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Freio Traseiro", "Verifique: folga livre do pedal ( Sport: 15 à 20mm Pop: 20 à 30mm).", new TimeSpan(0, 8, 0)));
            Itens.Add(new Item("Folga do Acelerador", "Verifique: folga livre da manopla do acelerador (Sport: 3 à 6mm Pop: 2 à 6mm).", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Roda Dianteira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            Itens.Add(new Item("Roda Traseira", "Verifique amassamento, folga do rolamento e outras irregularidades.", new TimeSpan(0, 8, 0)));
            Itens.Add(new Item("Corrente de Transmissão", "Verificar folga, alongamento e lubrificação.", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Coroa", "Verificar perfil dos dentes.", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Pinhão", "Verificar perfil dos dentes.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Suspensão Dianteira", "Verificar vazamento, parafusos soltos e alinhamento de montagem.", new TimeSpan(0, 10, 0)));
            Itens.Add(new Item("Amortecedor traseiro", "Verificar vazamento, parafusos soltos e bucha gasta.", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Pneus", "Verifique: profundidade da banda de rodagem, pressão.", new TimeSpan(0, 20, 0)));
            Itens.Add(new Item("Vazamento", "Verificar vazamento no motor.", new TimeSpan(0, 10, 0)));
            Itens.Add(new Item("Sistema de Ignição", "Verificar vela, cabo de vela e cachimbo.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Parafusos", "Verifique: Parafusos soltos ou sem parafusos (inspeção visual).", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Carenagens", "verificar carenagens soltas.", new TimeSpan(0, 6, 0)));
            Itens.Add(new Item("Caixa de Direção", "Verificar folga e calos de direção.", new TimeSpan(0, 25, 0)));
            Itens.Add(new Item("Passagem dos Cabos", "verifique passagem dos cabos: Velocímetro, embreagem e freio.", new TimeSpan(0, 3, 0)));
            Itens.Add(new Item("Sintoma crônico que depende de análise", "Moto falhando; Moto morrendo; Embregem patinando; Ruído no motor; Luz da injeção acesa; Chassi desalinhado;", new TimeSpan(1, 0, 0)));
        }

        public void Resultado()
        {
            Moto.CalcularTempoDeExecucao();
            Moto.DefinirSituacao();
        }

        public void CalcularTempoTriagem()
        {
            TempoTriagem = FinalTriagem.Subtract(InicioTriagem);
        }

        public void DefinirInicioTriagem(DateTime d)
        {
            InicioTriagem = d;
        }

        public void DefinirFinalTriagem(DateTime d)
        {
            FinalTriagem = d;
        }
    }
}
