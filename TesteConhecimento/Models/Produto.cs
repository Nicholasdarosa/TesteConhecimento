using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace TesteConhecimento.Models;

public class Produto
{

    [JsonProperty(PropertyName = "dscProduto")]
    public string Nome { get; set; }
    [Key]
    public int IdProduto { get; set; }

    [JsonProperty(PropertyName = "vlrUnitario")]
    public float ValorUnitario { get; set; }


}
