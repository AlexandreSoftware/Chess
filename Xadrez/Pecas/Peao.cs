using tabuleiro;
namespace Xadrez {
    class Peao : Peca {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat= new bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            if(cor==Cor.Branco){
                pos.definirvalores(posicao.Linha+1,posicao.Coluna);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
            }
            else{
                pos.definirvalores(posicao.Linha-1,posicao.Coluna);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
            }
            return mat;
        }
        public override string ToString() {
            return "P";
        }
    }
}
