namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //Metodo para permitir que as "pecas" sejam acessadas por outra classe, pois "pecas" é private
        public Peca peca (int linhas, int colunas)
        {
            return pecas[linhas, colunas];
        }

        //Criando uma sobrecarga do metodo Peca()
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        //Verificando se existe uma peca em uma dada posição
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        //Colocando peça no tabuleiro a Função: colocarPeca() (dá a posição das peças)
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        //Funcao para retirar peca do tabuleiro
        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        //Funcao para testar se a posicao é válida
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna  >= colunas)
            {
                return false;
            }
            return true;
        }

        //Criando uma exceção para erro
        public void validarPosicao(Posicao pos)
        {
            if(!posicaoValida(pos)) //"!" quer dizer não, se a posição não for válida
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
