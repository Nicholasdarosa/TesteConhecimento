using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace TesteConhecimento.Models;



public class Cliente
{

    [JsonProperty(PropertyName = "nmCliente")]
    public string Nome { get; set; }
    [Key]
    public int IdCliente { get; set; }
    public string Cidade { get; set; }
}
