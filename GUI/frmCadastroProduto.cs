
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using DAL;
using Modelo;

namespace GUI //aula 29  4:20
{
    public partial class frmCadastroProduto : GUI.frmModeloDeFormularioDeCadastro
    {
        public string foto = ""; //Aula 35 - variavel publica, verifica se o usuario carregou uma foto, se em brando objeto foto esta vazio

        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        //========================================================================================================================================
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        //metodo para lipar campos:
        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();
            //limpara foto:
            this.foto = ""; // limpa o texto do caminho
            pbFoto.Image = null;//limpa a picture box 
        }

        //========================================================================================================================================
        private void frmCadastroProduto_Load(object sender, EventArgs e) //aula 33 1:20 - Como carregar os combobox
        {
            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das catagorias
            //--------------------------------------------------------------------------------------------------
            this.alteraBotoes(1);
            //combo da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//criar conexão
            BLLCategoria bll = new BLLCategoria(cx);//criar o objeto categoria
            cbCategoria.DataSource = bll.Localizar("");//localizar todas as catagorias cadastradas, e mostra a 1° da lista
            cbCategoria.DisplayMember = "cat_nome";//mostrar o nome (Indicar qual coluna é exibida para selecionar)
            cbCategoria.ValueMember = "cat_cod";//armazena o codigo do item selecionado

            //auto completar combobox: https://youtu.be/duG7x9KR4jA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=340
            cbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;

            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das subcatagorias
            //--------------------------------------------------------------------------------------------------            
            try// Tratar erro caso nao tenha catagoria cadastrado, ou campo esta vazio
            {   
                //so montrar a subcatagiria conforme a catagiria selecionada:
                //combo da subcategoria, que depende da catagoria selecionada A
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);//aula 33 7:00 
                cbSubCategoria.DisplayMember = "scat_nome"; //mostrar o nome (Indicar qual coluna é exibida para selecionar)
                cbSubCategoria.ValueMember = "scat_cod"; //armazena o codigo do item selecionado

                //auto completar combobox: https://youtu.be/duG7x9KR4jA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=340
                cbSubCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbSubCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria"); //https://youtu.be/rrHEAtoJSIs?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=182
            }

            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das unidades de medida
            //-------------------------------------------------------------------------------------------------- 
            //combo und medida aula 33  https://youtu.be/TUke-tVYFcw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=924
            BLLUnidadeDeMedida ubll = new BLLUnidadeDeMedida(cx);
            cbUnd.DataSource = ubll.Localizar("");
            cbUnd.DisplayMember = "umed_nome";//mostrar o nome (Indicar qual coluna é exibida para selecionar)
            cbUnd.ValueMember = "umed_cod"; //armazena o codigo do item selecionado

            //auto completar combobox: https://youtu.be/duG7x9KR4jA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=340
            cbUnd.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbUnd.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //========================================================================================================================================
        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        //========================================================================================================================================
        private void txtValorPago_Leave(object sender, EventArgs e) // ajustar pois desta forma nao converte em moeda
        {
            if (txtValorPago.Text.Contains(".") == false)
            {
                txtValorPago.Text += ".00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0.00";
            }
        }

        //========================================================================================================================================
        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e) //Aula 31 (Melhorar validar digitação somente de valor)
        {
            //so permite digitar numero, ponto ou virgula uma vez, 
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;//caso nao for . ou , 
            }
        }

        //========================================================================================================================================
        private void txtValorVenda_Leave(object sender, EventArgs e) // aula 31
        {
            //se contem um ponto adiciona casas desimais
            if (txtValorVenda.Text.Contains(".") == false)
            {
                txtValorVenda.Text += ".00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }
            try
            {
                //tenta converte texto em numero decimal: Aula 31
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                //caso der erro, adiciona 0,00
                txtValorVenda.Text = "0.00";
            }
        }

        //========================================================================================================================================
        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQtde.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        //========================================================================================================================================
        private void txtQtde_Leave(object sender, EventArgs e)
        {
            if (txtQtde.Text.Contains(".") == false)
            {
                txtQtde.Text += ".00";
            }
            else
            {
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 1)
                {
                    txtQtde.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtQtde.Text);
            }
            catch
            {
                txtQtde.Text = "0.00";
            }
        }

        //========================================================================================================================================
        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        //========================================================================================================================================
        private void btSalvar_Click(object sender, EventArgs e) //Aula 36
        {
            try //tratamento de erro
            {
                //leitura dos dados
                ModeloProduto modelo = new ModeloProduto();//cria uma objeto que representa os dados da tabela catagoria

                // passar o valor dos campos nome para as propriedades  ver -  aula 40
                modelo.ProNome = txtNome.Text;
                modelo.ProDescricao = txtDescricao.Text;

                //melhorar, pois na esta convertendo em moeda:
                modelo.ProValorPago =Convert.ToDouble(txtValorPago.Text);
                modelo.ProValorVenda = Convert.ToDouble(txtValorVenda.Text);

                modelo.ProQtde = Convert.ToDouble(txtQtde.Text);

                modelo.UmedCod = Convert.ToInt32(cbUnd.SelectedValue);//vai gravar somente o codigo ID do item selecionado
                modelo.CatCod = Convert.ToInt32(cbCategoria.SelectedValue);//vai gravar somente o codigo ID do item selecionado
                modelo.ScatCod = Convert.ToInt32(cbSubCategoria.SelectedValue);//vai gravar somente o codigo ID do item selecionado

                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                //bll possui os metodos para incluir e alterar
                BLLProduto bll = new BLLProduto(cx);//passa a string de conexao

                //verificar qual o tipo de operação que vai executar ao gravar
                if (this.operacao == "inserir")//valida se é um inserção, verificar o valro da variavel operação
                {
                    //cadastrar um produto
                    modelo.CarregaImagem(this.foto);//salva o arquivo da imagem selecionada -- corrigido na aula 40.2
                    bll.Incluir(modelo);//passa os dados para o metodo incluir
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ProCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                }
                else //caso for alterere
                {

                    //alterar um produto
                    modelo.ProCod = Convert.ToInt32(txtCodigo.Text);//alterar o produto correspondente ao codigo existente na tela
                    //validação do alterar foto: ver aula https://youtu.be/mmVyYniWetk?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=220
                    if (this.foto == "Foto Original")//confere se a foto foi alterada, coso for original
                    {                       
                        ModeloProduto mt = bll.CarregaModeloProduto(modelo.ProCod); //cria um modelo temporario
                        //carrega a foto do banco no modelo ... Profoto
                        modelo.ProFoto = mt.ProFoto;
                    }
                    else //se nao , quer dizer que é uma foto nova
                    {
                        modelo.CarregaImagem(this.foto);
                    }

                    bll.Alterar(modelo);//alterar conforme codigo da tela
                    MessageBox.Show("Cadastro alterado");//mostrar mensagem de confirmação
                }

                //em ambos os casos:
                this.LimpaTela();// limpar a tela 
                this.alteraBotoes(1);//volta os botoes para o estado padrão
            }
            catch (Exception erro) // caos der algum erro...(não limpa a tela)
            {
                MessageBox.Show(erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
            }

        }

        //========================================================================================================================================
        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e) // recarregar o combox da subcatagoria
        {
            //combo da categoria Aula 34 https://youtu.be/rrHEAtoJSIs?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=277
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                // trata se nao tiver nada cadastrado : Aula 33  10:00
                cbSubCategoria.Text = ""; //limpara a combox

                //--------------------------------------------------------------------------------------------------
                // Carragar o combobox das catagorias
                //-------------------------------------------------------------------------------------------------- 
                //combo da subcategoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria");
            }
        }

        //========================================================================================================================================
        private void btLoFoto_Click(object sender, EventArgs e) //abrir tela para buscar foto
        {
            OpenFileDialog od = new OpenFileDialog(); //Aula 35 https://youtu.be/_paS_LkurMQ?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=122
            od.ShowDialog();//manda abrir a tela de para selecionar o carquivo da foto

            if (!string.IsNullOrEmpty(od.FileName))//se o arquivo seleconado for diferente de vazio ou nao existir
            {
                this.foto = od.FileName; //recebe o caminho da foto selecionada
                pbFoto.Load(this.foto);//carregar a foto selecionada na propriedade foto (objeto picturebox)
            }

        }

        //========================================================================================================================================
        private void btRmFoto_Click(object sender, EventArgs e) //Aula 35 7:00
        {
            this.foto = ""; // limpa o texto do caminho
            pbFoto.Image = null;//limpa a picture box (Criar uma imagem garal - "Marca d'gua Sem imagem")
        }

        //========================================================================================================================================
        private void btCancelar_Click(object sender, EventArgs e) //Aula 36 5:00
        {
            this.alteraBotoes(1);
            this.LimpaTela();
        }

        //========================================================================================================================================
        private void btExcluir_Click(object sender, EventArgs e) //aula 37
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                //caso responder sim...
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

                    //bll possui o metodo para excluir
                    BLLProduto bll = new BLLProduto(cx); //passa a string de conexao

                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));//retorna erro se este codigo ja estiver sendo utilizado como chave em outra tabela
                    this.LimpaTela();
                    this.alteraBotoes(1);

                    MessageBox.Show("Cadastro excluido com sucesso!");
                }
            }
            catch // sem o Exception, qualquer tipo de erro
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        //========================================================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e) //aula 37
        {
            FrmConsultaProduto f = new FrmConsultaProduto();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);
                ModeloProduto modelo = bll.CarregaModeloProduto(f.codigo);
                //carregar os dados na tela:
                txtCodigo.Text = modelo.ProCod.ToString();
                txtDescricao.Text = modelo.ProDescricao;
                txtNome.Text = modelo.ProNome;
                txtQtde.Text = modelo.ProQtde.ToString();
                txtValorPago.Text = modelo.ProValorPago.ToString();
                txtValorVenda.Text = modelo.ProValorVenda.ToString();
                //carregar os combobox:
                cbCategoria.SelectedValue = modelo.CatCod;
                cbSubCategoria.SelectedValue = modelo.ScatCod;
                cbUnd.SelectedValue = modelo.UmedCod;

                //carregar a foto:
                try
                {
                    //guarda o codigo salvo no BD, no objeto ms:
                    MemoryStream ms = new MemoryStream(modelo.ProFoto);

                    //carrega a imagem no picturebox o codigo convertido em imagem:
                    pbFoto.Image = Image.FromStream(ms);

                    //https://youtu.be/mmVyYniWetk?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=175
                    //significa que a foto esta salvo na memoria e nao fisicamente no PC
                    this.foto = "Foto Original"; //Aula 40.2 - erro ao alterar um produto, foto se perde
                }
                catch { }//se der erro a picturebox fica vazio

                //implmentar formatação de muneros de qtd e valor de moeda: Aula 40.2
                //txtQtde_Leave(sender,e);
                //txtValorPago_Leave(sender,e);
                //txtValorVEnda_Leave(sender,e);

                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btAddCategoria_Click(object sender, EventArgs e)//adicionar catagoria aula 49
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();

            //combo da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//criar conexão
            BLLCategoria bll = new BLLCategoria(cx);//criar o objeto categoria
            cbCategoria.DataSource = bll.Localizar("");//localizar todas as catagorias cadastradas, e mostra a 1° da lista
            cbCategoria.DisplayMember = "cat_nome";//mostrar o nome (Indicar qual coluna é exibida para selecionar)
            cbCategoria.ValueMember = "cat_cod";//armazena o codigo do item selecionado

            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das subcatagorias
            //--------------------------------------------------------------------------------------------------            
            try// Tratar erro caso nao tenha catagoria cadastrado, ou campo esta vazio
            {
                //so montrar a subcatagiria conforme a catagiria selecionada:
                //combo da subcategoria, que depende da catagoria selecionada A
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);//aula 33 7:00 
                cbSubCategoria.DisplayMember = "scat_nome"; //mostrar o nome (Indicar qual coluna é exibida para selecionar)
                cbSubCategoria.ValueMember = "scat_cod"; //armazena o codigo do item selecionado
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria"); //https://youtu.be/rrHEAtoJSIs?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=182
            }
        }

        private void btAddSubCategoria_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria f = new frmCadastroSubCategoria();
            f.ShowDialog();
            f.Dispose();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//criar conexão

            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das subcatagorias
            //--------------------------------------------------------------------------------------------------            
            try// Tratar erro caso nao tenha catagoria cadastrado, ou campo esta vazio
            {
                //so montrar a subcatagiria conforme a catagiria selecionada:
                //combo da subcategoria, que depende da catagoria selecionada A                
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);//aula 33 7:00 
                cbSubCategoria.DisplayMember = "scat_nome"; //mostrar o nome (Indicar qual coluna é exibida para selecionar)
                cbSubCategoria.ValueMember = "scat_cod"; //armazena o codigo do item selecionado
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria"); // https://youtu.be/XtknKZ5JAeM?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=756
            }
        }

        private void btAddUnMed_Click(object sender, EventArgs e)
        {
            frmCadastrounidadeDeMedida f = new frmCadastrounidadeDeMedida();
            f.ShowDialog();
            f.Dispose();

            //--------------------------------------------------------------------------------------------------
            // Carragar o combobox das unidades de medida
            //-------------------------------------------------------------------------------------------------- 
            //combo und medida aula 33  https://youtu.be/TUke-tVYFcw?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=924
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//criar conexão
            BLLUnidadeDeMedida ubll = new BLLUnidadeDeMedida(cx);
            cbUnd.DataSource = ubll.Localizar("");
            cbUnd.DisplayMember = "umed_nome";//mostrar o nome (Indicar qual coluna é exibida para selecionar)
            cbUnd.ValueMember = "umed_cod"; //armazena o codigo do item selecionado
        }
    }
}
