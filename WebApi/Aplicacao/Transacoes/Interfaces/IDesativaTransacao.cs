using Aplicacao.DTOs;
using Aplicacao.DTOs.Colunas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Transacoes.Interfaces;

public interface IDesativaTransacao
{
    Task<List<TransacaoDto>> Desativar(int id, int idDaColuna);
}
