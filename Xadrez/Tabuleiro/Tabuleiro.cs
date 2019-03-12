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
    }
}
