﻿using Aplicacao.DTOs.Configuracao;
using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IAlteraConfiguracao
{
    Task Alterar(ConfiguracaoDto configuracaoDto);
}
