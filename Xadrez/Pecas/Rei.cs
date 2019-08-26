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
            pos.definirValores(posicao.Linha,posicao.Coluna);
            if(qteMovimentos==0){
                bool validator=true;
                //East
                while(validator==true){
                    pos.definirValores(pos.Linha,pos.Coluna-1);
                    if(tab.posicaoValida(pos)&&tab.peca(pos) is Torre&&tab.peca(pos).qteMovimentos==0&&tab.peca(pos).cor==cor){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                    if(tab.posicaoValida(pos)&&!podeMover(pos)){
                        validator=false;
                    }
                    else if(!tab.posicaoValida(pos)==true){
                        validator=false;
                    }
                }
                validator=true;
                //WEST
                pos.definirValores(posicao.Linha,posicao.Coluna);
                while(validator==true){
                    pos.definirValores(pos.Linha,pos.Coluna+1);
                    if(tab.posicaoValida(pos)&&tab.peca(pos) is Torre&&tab.peca(pos).qteMovimentos==0&&tab.peca(pos).cor==cor){
                        mat[pos.Linha,pos.Coluna]=true;
                    }
                    if(tab.posicaoValida(pos)&&!podeMover(pos)){
                        validator=false;
                    }
                    else if(!tab.posicaoValida(pos)==true){
                        validator=false;
                    }
                }
            }
            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
