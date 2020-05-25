using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//este formulario é usado de base tamplate para criar outros a partir deste

namespace GUI
{
    public partial class frmModeloDeFormularioDeCadastro : Form //aula 07
    {
        //criar propriedades que captura o tipo da operação:
        public String operacao;

        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        //Metodo para controlar o que vem ativo ao inicicar o form
        public void alteraBotoes(int op)
        {
            // op = operaçoes que serao feitas com os botoes
            // 1  = Preparar os botoes para inserir e localizar
            // 2  = preparar os para inserir/alterar um registro
            // 3  = preparar a tela para excluir ou alterar

            //Desabilitar todos os objetos, inicialmente
            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;

            //1  = Preparar os botoes para inserir e localizar
            if (op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }
            //2  = preparar os para inserir/alterar um registro
            if (op == 2)
            {
                pnDados.Enabled = true; //ativa os campos que estiverm no painel
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;
            }
            //3  = preparar a tela para excluir ou alterar
            if (op == 3)
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }
        }

        private void frmModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            //indicar quais botoes vem ativos ao iniciar o form:
            alteraBotoes(1);
        }

        //usa a tecla enter com tab: para pular para o proximo campo
        private void frmModeloDeFormularioDeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            //1° = setar propriedade do formulario KeyPreview = true
            //se o codigo da tekla precionada for igual ao enter : 
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
