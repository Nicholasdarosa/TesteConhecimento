using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace TesteConhecimento.Models;

public class Venda
{
    public Venda(int idCliente, int idProduto, int quantidade, float valorUnitario, DateTime dataVenda)
    {
        
        IdCliente = idCliente;
        IdProduto = idProduto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        DataVenda = dataVenda;
    }

    public Venda(int idVenda, int idCliente, int idProduto, int quantidade, float valorUnitario, DateTime dataVenda, float valorTotal)
    {
        IdVenda = idVenda;
        IdCliente = idCliente;
        IdProduto = idProduto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        DataVenda = dataVenda;
        ValorTotal = valorTotal;
    }



    [JsonProperty(PropertyName = "dscProduto")]
    [Key]
    public int IdVenda { get; set; }
    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }
    public int IdProduto { get; set; }
    public Produto Produto { get; set; }

    [JsonProperty(PropertyName = "qtdVenda")]
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }

    [JsonProperty(PropertyName = "dthVenda")]
    public DateTime DataVenda { get; set; }

    [JsonProperty(PropertyName = "vlrTotalVenda")]
    public float ValorTotal { get; set; }
}


public class VendaRequestDto
{
    public int IdCliente { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }
    public DateTime DataVenda { get; set; }
}

public class VendaResponseDto
{
    public int IdVenda { get; set; }
    public int IdCliente { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }
    public DateTime DataVenda { get; set; }
    public float ValorTotal { get; set; }

}
