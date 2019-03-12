namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;
        public Tabuleiro(int linhas, int colunas){
            this.colunas = colunas;
            this.linhas = linhas;
            pecas = new Peca[linhas, colunas];
        }

    }
}
