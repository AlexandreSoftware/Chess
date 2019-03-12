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
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }
        public void Colocarpeca(Peca p, Posicao pos) {
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
            if (!posicaovalida(pos)) {
                throw new TabuleiroException
            }
        }
    }
}
