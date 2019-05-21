using tabuleiro;
namespace Xadrez {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat = new  bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            //ne
            pos.definirvalores(posicao.Linha-2,posicao.Coluna-1);  
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //nw
            pos.definirvalores(posicao.Linha-2,posicao.Coluna+1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                
                mat[pos.Linha,pos.Coluna]=true;
            }
            //se
            pos.definirvalores(posicao.Linha+2,posicao.Coluna-1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){ 
                mat[pos.Linha,pos.Coluna]=true;
            }
            //sw
            pos.definirvalores(posicao.Linha+2,posicao.Coluna+1);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //en
            pos.definirvalores(posicao.Linha+1,posicao.Coluna-2);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //es
            pos.definirvalores(posicao.Linha+1,posicao.Coluna+2);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //wn
            pos.definirvalores(posicao.Linha-1,posicao.Coluna-2);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            //ws
            pos.definirvalores(posicao.Linha-1,posicao.Coluna+2);
            if(tab.posicaovalida(pos)&&podeMover(pos)){
                mat[pos.Linha,pos.Coluna]=true;
            }
            return mat;
        }
        public override string ToString() {
            return "C";
        }
    }
}
