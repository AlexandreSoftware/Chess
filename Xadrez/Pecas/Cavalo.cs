namespace tabuleiro {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new  bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            //ne
            pos.definirValores(posicao.Linha-2,posicao.Coluna-1);  
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //nw
            pos.definirValores(posicao.Linha-2,posicao.Coluna+1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //se
            pos.definirValores(posicao.Linha+2,posicao.Coluna-1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){ 
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sw
            pos.definirValores(posicao.Linha+2,posicao.Coluna+1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //en
            pos.definirValores(posicao.Linha+1,posicao.Coluna-2);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //es
            pos.definirValores(posicao.Linha+1,posicao.Coluna+2);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //wn
            pos.definirValores(posicao.Linha-1,posicao.Coluna-2);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //ws
            pos.definirValores(posicao.Linha-1,posicao.Coluna+2);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            return mat;
        }
        public override string ToString() {
            return "C";
        }
    }
}
