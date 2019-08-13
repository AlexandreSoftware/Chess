using tabuleiro;

namespace Xadrez {
    class Rei : Peca{
        public Rei(Tabuleiro tab,Cor cor): base(tab,cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new  bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            //topo
            pos.definirvalores(posicao.Linha-1,posicao.Coluna);  
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //esquerda
            pos.definirvalores(posicao.Linha,posicao.Coluna-1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //direita
            pos.definirvalores(posicao.Linha,posicao.Coluna+1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){ 
                mat[pos.Linha,pos.Coluna]=true;
            }
            //ne
            pos.definirvalores(posicao.Linha-1,posicao.Coluna-1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //nw
            pos.definirvalores(posicao.Linha-1,posicao.Coluna+1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sul
            pos.definirvalores(posicao.Linha+1,posicao.Coluna);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //se
            pos.definirvalores(posicao.Linha+1,posicao.Coluna-1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sw
            pos.definirvalores(posicao.Linha+1,posicao.Coluna+1); 
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            pos.definirvalores(0,0);
            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
