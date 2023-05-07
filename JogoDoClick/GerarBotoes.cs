using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace JogoDoClick
{
    class GerarBotoes
    {
        Button btnBotao;
        Timer t;
        public int tamanho, posx, posy, velocidade, numClique;
        static int parartimerdin = 0;
        Form1 frm1 = new Form1();
        //static int auxparar;
        static int pontos = 0;

        public GerarBotoes(Panel p, int tamanho, int posx, int posy, int velocidade, int numClique)
        {
            if (parartimerdin == 0) //condicao para fazer enquanto parartimerdin for 0
            {
                this.tamanho = tamanho;
                this.posx = posx;
                this.posy = posy;
                this.velocidade = velocidade;
                this.numClique = numClique;

                btnBotao = new Button(); //declara botao
                t = new Timer(); //declara timer

                btnBotao.Size = new Size(tamanho, tamanho); //define o tamanho do botao de acordo com os parametros
                btnBotao.Location = new Point(posx, posy); //define a pos de acordo com os parametros
                btnBotao.BackColor = Color.Red; //define a cor do botao
                btnBotao.Enabled = true; //deixa o botao enable
                btnBotao.Click += new EventHandler(Botao_Click); //chama funcao quando clica no botao
                btnBotao.Text = numClique.ToString(); //mostra o numero dentro do botao

                t.Tick += new EventHandler(tTick); //tick para o botao ir descendo
                t.Enabled = true; //habilita o timer
                t.Interval = velocidade; //define a velocidade de acordo com o parametro

                p.Controls.Add(btnBotao); //aa botao
            }
            else //se parartimerdinamico for dif. de 0
            {
                p.Enabled = false; //desabilida o painel
            }
        }

        public void tTick(object sender, EventArgs e)
        {
            if ((btnBotao.Location.Y >= 240) && (btnBotao.Enabled == true))//condicao para quando o botao tocar o chao do painel e o botao for enable
            {
                btnBotao.Enabled = false;//desabilita o botao
                t.Enabled = false; //desabilita o timer
                parartimerdin = 1; //parartimerdinamico recebe 1 (usado no constr.)
                MessageBox.Show("VOCE PERDEU\nPONTUAÇÃO: " + pontos); //msg
            }
            if(parartimerdin == 0) //condicao enquanto parartimer for igual 0
            {
                btnBotao.Location = new Point(btnBotao.Location.X, btnBotao.Location.Y + 1); //desce o botão1 pixel
            }
        }

        public void Botao_Click(object sender, EventArgs e)
        {
            int a = 0; //aux a recebe 0
            numClique = numClique - 1; //a cada clique no botao ele decrementa 1
            btnBotao.Text = numClique.ToString(); //atualiza o numero de clique dos botoes
            if (btnBotao.Text == a.ToString()) //condicao quando o valor do botao for igual a 0
            {
                Button b = (Button)sender; //armazena o botao clicado
                pontos++; // incremento dos pontos
                b.Visible = false; //botao fica inv.
                b.Enabled = false; //desativa o botao
            }
        }


        



    }
}
