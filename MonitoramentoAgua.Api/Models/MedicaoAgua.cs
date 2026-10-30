using Microsoft.Win32;

namespace MonitoramentoAgua.Api.Models
{
    public class MedicaoAgua
    {
        public int Id { get; set; }
        public decimal DistanciaCm { get; set; }
        public decimal NivelCm { get; set; }
        public decimal NivelPercentual { get; set; }
        public DateTime DataHora { get; set; }
    }
}

// como sempre o Ruan precisa explicar né bb
//Código O que faz
//namespace Define a localização lógica da classe
//public class MedicaoAgua    Cria a entidade de medição
//Id  Identificador único de cada registro
//DistanciaCm Distância entre o sensor e a água
//NivelCm Altura atual da água
//NivelPercentual Percentual de preenchimento
//DataHora Momento em que a medição foi registrada
