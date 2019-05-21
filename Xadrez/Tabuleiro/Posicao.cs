namespace tabuleiro {   
    public class Posicao{
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public void definirvalores(int Linha,int Coluna){     
            this.Coluna= Coluna;
            this.Linha = Linha;
           
        }
        public Posicao(int Linha,int Coluna){
            this.Coluna = Coluna;
            this.Linha = Linha;
        }
        public override string ToString()
        {
            return Linha
                +","
                +Coluna;
        }

    }
}
