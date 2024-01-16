using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Comum.Excecoes;
using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using Infra.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes
{
    public class AlteraClassificacao : IAlteraClassificacao
    {
        private IClassificacaoRepositorio _classificacaoRepositorio;

        public AlteraClassificacao(IClassificacaoRepositorio classificacaoRepositorio)
        {
            _classificacaoRepositorio = classificacaoRepositorio;
        }

        public async Task Alterar(ClassificacaoDto classificacaoDto)
        {
            var classificacao = await _classificacaoRepositorio.ObterPorId(classificacaoDto.Id);
            ValidarSeAClassificacaoExiste(classificacao);

            AlterarNomeCasoNecessario(classificacao, classificacaoDto);
            AlterarCorCasoNecessario(classificacao, classificacaoDto);

            await _classificacaoRepositorio.Atualizar(classificacao);
        }

        private void AlterarNomeCasoNecessario(Classificacao classificacao, ClassificacaoDto classificacaoDto)
        {
            var nome = Nome.Criar(classificacaoDto.Nome);
            classificacao.AlterarNome(nome);
        }

        private void AlterarCorCasoNecessario(Classificacao classificacao, ClassificacaoDto classificacaoDto)
        {
            classificacao.AlterarCor(classificacaoDto.Cor);
        }

        private void ValidarSeAClassificacaoExiste(Classificacao classificacao)
        {
            new ExcecaoDeAplicacao()
                .QuandoEhNulo(classificacao, MensagensDeExcecao.ClassificacaoNaoEncontrada)
                .EntaoDispara();
        }
    }
}
