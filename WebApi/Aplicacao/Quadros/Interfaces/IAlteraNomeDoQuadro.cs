﻿using System.Threading.Tasks;

namespace Aplicacao.Quadros.Interfaces;

public interface IAlteraNomeDoQuadro
{
    Task Alterar(string nome, int idDoQuadro);
}
