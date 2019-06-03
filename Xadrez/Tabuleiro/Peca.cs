using System.Collections.Generic;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        protected bool podeMover(Posicao pos){
            Peca p = tab.peca(pos);
            return p==null||p.cor!=cor;
        }
         public Peca(Cor cor){
            this.posicao =null;
            this.tab = null;
            this.cor = cor;
            this.qteMovimentos = 0;

        }
        public Peca(Tabuleiro tab,Cor cor){
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;

        }
        public abstract bool[,] movimentosPossiveis();
        
    }
}

