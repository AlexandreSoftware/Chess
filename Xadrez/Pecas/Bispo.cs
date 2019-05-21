using System.Collections.Generic;
using tabuleiro;

namespace Xadrez {
    class Bispo : Peca{
        public Bispo(Tabuleiro tab,Cor cor): base(tab,cor) {
            
        }
        public override bool[,] movimentosPossiveis(){
            bool validator=true;
            bool[,] mat=new bool[tab.linhas,tab.colunas];
            Posicao pos= new Posicao(posicao.Linha,posicao.Coluna);
            //NE
            validator=true;
            pos.definirvalores(posicao.Linha,posicao.Coluna);
            while(validator==true){
                pos.definirvalores(pos.Linha-1,pos.Coluna-1);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaovalida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //NW
            validator=true;
            pos.definirvalores(posicao.Linha,posicao.Coluna);
            while(validator==true){
                pos.definirvalores(pos.Linha-1,pos.Coluna+1);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaovalida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //SE
            pos.definirvalores(posicao.Linha,posicao.Coluna);
            validator=true;
            while(validator==true){
                pos.definirvalores(pos.Linha+1,pos.Coluna-1);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaovalida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //SW
            pos.definirvalores(posicao.Linha,posicao.Coluna);
            validator=true;
            while(validator==true){
                
                
                pos.definirvalores(pos.Linha+1,pos.Coluna+1);
                if(tab.posicaovalida(pos)&&podeMover(pos)){
                    mat[pos.Linha,pos.Coluna]=true;
                }
                else if(tab.posicaovalida(pos)==true&&podeMover(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            
            return mat;
        }
        public override string ToString() {
                return "B";
            }
        }
}
