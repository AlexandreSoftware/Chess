namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;
        public Tabuleiro(int linhas, int colunas) {
            this.colunas = colunas;
            this.linhas = linhas;
            pecas = new Peca[linhas, colunas];
        }

        public bool existepeca(Posicao pos) {
            return peca(pos) != null;
        }
        public Peca peca(Posicao pos) {
            return pecas[pos.Linha,pos.Coluna];
        }
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }
        public void Colocarpeca(Peca p, Posicao pos) {
            if(existepeca(pos)){
                throw new TabuleiroException("Ja existe uma peça nessa posiçao");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
        public bool posicaovalida(Posicao pos) {
            if (pos.Linha<0||pos.Linha>=linhas||pos.Coluna<0||pos.Coluna>=colunas) {
                return false;
            }
            return true;
        }
        public void validarposicao(Posicao pos) {
            if (!posicaovalida(pos)&&!existepeca(pos)==false) {
                throw new TabuleiroException("Posição Invalida!"); 
            }
        }
    }
}
