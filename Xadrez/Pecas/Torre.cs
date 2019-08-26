using tabuleiro;

namespace Xadrez {
    class Torre : Peca{
        public Torre(Tabuleiro tab,Cor cor): base(tab,cor) {

        }
        public override bool[,] movimentosPossiveis(){
            bool validator=true;
            bool[,] mat=new bool[tab.linhas,tab.colunas];
            Posicao pos= new Posicao(posicao.Linha,posicao.Coluna);
            //East
            while(validator==true){
                pos.definirValores(pos.Linha,pos.Coluna-1);
                if(tab.posicaoValida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaoValida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            validator=true;
            //WEST
            pos.definirValores(posicao.Linha,posicao.Coluna);
            while(validator==true){
                pos.definirValores(pos.Linha,pos.Coluna+1);
                if(tab.posicaoValida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaoValida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //North
            validator=true;
            pos.definirValores(posicao.Linha,posicao.Coluna);
            while(validator==true){
                pos.definirValores(pos.Linha-1,pos.Coluna);
                if(tab.posicaoValida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaoValida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //South
            validator=true;
            pos.definirValores(posicao.Linha,posicao.Coluna);
            while(validator==true){
                pos.definirValores(pos.Linha+1,pos.Coluna);
                if(tab.posicaoValida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaoValida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            
            
            return mat;
        }
        public override string ToString() {
            return "T";
        }
    }
}
