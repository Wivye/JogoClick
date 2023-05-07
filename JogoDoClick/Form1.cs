using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDoClick
{
    public partial class Form1 : Form
    {
        //linha de alteração teste

        int clique = 1; //quantidade de cliques que vao precisar para o botao sumir
        int auxclique = 0; //var recebendo 0 para entrar na condicao do Timer1_tick
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; //habilita o timer do form
            timer1.Interval = 500; //define o intervalo -> a cada meio segundo
            timer1.Tick += new EventHandler(Timer1_Tick); //tick para criação de botao
            btnStart.Enabled = false; //desabilita o botao quando clicado
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            if (auxclique < 10) //condicao auxclique enquanto for menor que 0
            {
                Random random = new Random(Guid.NewGuid().GetHashCode()); //random com seed
                int numRandom = random.Next(0, 9) * 30; //numRandom serve para a posX
                GerarBotoes gb = new GerarBotoes(panel1, 30, numRandom, 0, 10, clique); //constr.
                auxclique++; //incremento auxclique com o objetivo de rodar 10 vezes aqui dentro
            }
            else //senao (se auxclique for igual ou maior a 10)
            {
                clique++;//incremento clique(mostrado dentro de cada botao, começado em 1)
                auxclique = 0; //auxclique passa a valer 0 novamente
            }
        }
    }
}
