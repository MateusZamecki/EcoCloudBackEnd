using Aplicacao.DTOs.Configuracao;

namespace Aplicacao.DTOs.Colunas;

public class AlteraColunaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ConfiguracaoDto Configuracao { get; set; }
    public int Tipo { get; set; }
}
