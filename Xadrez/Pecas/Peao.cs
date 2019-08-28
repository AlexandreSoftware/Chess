namespace tabuleiro {
    class Peao : Peca {
        
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat= new bool[tab.linhas,tab.colunas];
            bool val=false;
            Posicao pos=new Posicao(0,0);
            if(cor==Cor.Branco){
                pos.definirValores(posicao.Linha-1,posicao.Coluna);
                if(tab.posicaoValida(pos)&&podeMover(pos)&&!tab.existePeca(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                    if(posicao.Linha==0){
                        tab.promocao=pos;
                        val=true;
                    }
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
                    }
                }            
                
            }
            else{
                pos.definirValores(posicao.Linha+1,posicao.Coluna);
                if(posicao.Linha==7){
                    tab.promocao=pos;
                    val=true;
                }
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
                     }
                }            
            }
            if(!val){
                tab.promocao=null;
            }
            return mat;
        }
        public override string ToString() {
            return "P";
        }
    }
}
