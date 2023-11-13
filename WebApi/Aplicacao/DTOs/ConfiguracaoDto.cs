using System;

namespace Aplicacao.DTOs;

public class ConfiguracaoDto
{
    public int Id { get; set; }
    public int IntervaloDeDias { get; set; }
    public DateTime Data { get; set; }
    public int ColunaId { get; set; }
}
