namespace tabuleiro {
    class Peao : Peca {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat= new bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            pos.definirValores(posicao.Linha,posicao.Coluna);
            if(tab.emPassant!=null){
                pos.definirValores(posicao.Linha,posicao.Coluna-1);
                if(pos.Linha==tab.emPassant.Linha&&pos.Coluna==tab.emPassant.Coluna){
                    Posicao posa = tab.casaAtraz(tab.emPassant);
                    mat[posa.Linha,posa.Coluna]=true;
                }
                pos.definirValores(posicao.Linha,posicao.Coluna+1);
                if(pos.Linha==tab.emPassant.Linha&&pos.Coluna==tab.emPassant.Coluna){
                    Posicao posa = tab.casaAtraz(tab.emPassant);
                    mat[posa.Linha,posa.Coluna]=true;
                }
            }
            pos.definirValores(posicao.Linha,posicao.Coluna);            
            if(cor==Cor.Branco){
                pos.definirValores(posicao.Linha-1,posicao.Coluna);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&!tab.existePeca(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                pos.definirValores(pos.Linha,pos.Coluna-1);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&tab.existePeca(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                }
                pos.definirValores(pos.Linha,pos.Coluna+2);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&tab.existePeca(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                }
                if(qteMovimentos==0){
                    pos.definirValores(posicao.Linha-2,posicao.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)&&!tab.existePeca(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                        tab.potentialEmPassant=new Posicao(pos.Linha,pos.Coluna);
                    }
                }            
                
            }
            else{
                pos.definirValores(posicao.Linha+1,posicao.Coluna);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&!tab.existePeca(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                pos.definirValores(pos.Linha,pos.Coluna-1);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&tab.existePeca(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                pos.definirValores(pos.Linha,pos.Coluna+2);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&tab.existePeca(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                if(qteMovimentos==0){
                    pos.definirValores(posicao.Linha+2,posicao.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)&&!tab.existePeca(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                        tab.potentialEmPassant=new Posicao(pos.Linha,pos.Coluna);
                    }
                }
            }
            return mat;
        }
        public override string ToString() {
            return "P";
        }
    }
}
