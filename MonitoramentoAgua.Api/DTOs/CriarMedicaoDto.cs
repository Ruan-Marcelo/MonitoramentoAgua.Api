using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace MonitoramentoAgua.Api.DTOs
{
    public class CriarMedicaoDto
    {
        [Required]
        [Range(typeof(decimal), "2", "400")]
        public decimal DistanciaCm { get; set; }
    }

//- using System.ComponentModel.DataAnnotations: importa os recursos de validação.
//- Required: exige que a propriedade seja informada.
//- Range: limita a distância entre 2 e 400 cm, faixa nominal do HC-SR04 tradicional.
//- DistanciaCm: representa a distância recebida do ESP32.
}
