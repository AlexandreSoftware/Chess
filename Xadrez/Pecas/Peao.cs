using tabuleiro;
namespace Xadrez {
    class Peao : Peca {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {
            qteMovimentos=2;
        }
        public override bool[,] movimentosPossiveis(){
            bool[,] mat= new bool[tab.linhas,tab.colunas];
            Posicao pos=new Posicao(0,0);
            if(qteMovimentos==2){
                if(cor==Cor.Branco){
                    pos.definirValores(posicao.Linha-1,posicao.Coluna);
                    
                    if(tab.posicaoValida(pos)&&podeMover(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                    pos.definirValores(pos.Linha-1,pos.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                }
                else{
                    pos.definirValores(posicao.Linha+1,posicao.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                    pos.definirValores(pos.Linha+1,posicao.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                }
            }
            else{
                if(cor==Cor.Branco){
                pos.definirValores(posicao.Linha-1,posicao.Coluna);
                
                if(tab.posicaoValida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                }
                else{
                    pos.definirValores(posicao.Linha+1,posicao.Coluna);
                    if(tab.posicaoValida(pos)&&podeMover(pos)){
                        mat[pos.Linha,pos.Coluna]=true;
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
