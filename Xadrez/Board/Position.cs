namespace BoardNS {   
    public class Position{
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public void defineValues(int Linha,int Coluna){     
            this.Coluna= Coluna;
            this.Linha = Linha;
           
        }
        public Position(int Linha,int Coluna){
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
