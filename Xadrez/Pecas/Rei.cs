using tabuleiro;

namespace Xadrez {
    class Rei : Peca{
        public Rei(Tabuleiro tab,Cor cor): base(tab,cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new  bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            //topo
            pos.definirValores(posicao.Linha-1,posicao.Coluna);  
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //esquerda
            pos.definirValores(posicao.Linha,posicao.Coluna-1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //direita
            pos.definirValores(posicao.Linha,posicao.Coluna+1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){ 
                mat[pos.Linha,pos.Coluna]=true;
            }
            //ne
            pos.definirValores(posicao.Linha-1,posicao.Coluna-1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //nw
            pos.definirValores(posicao.Linha-1,posicao.Coluna+1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sul
            pos.definirValores(posicao.Linha+1,posicao.Coluna);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //se
            pos.definirValores(posicao.Linha+1,posicao.Coluna-1);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sw
            pos.definirValores(posicao.Linha+1,posicao.Coluna+1); 
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            pos.definirValores(0,0);
            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
