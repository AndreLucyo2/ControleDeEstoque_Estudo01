using BLL;
using DAL;
using Modelo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMovimentacaoCompra : GUI.frmModeloDeFormularioDeCadastro //https://youtu.be/VOjVYzRZk50?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=623
    {
        //representa o total da compra:
        public double totalCompra = 0;

        public frmMovimentacaoCompra()
        {
            InitializeComponent();
        }

        //=============================================================================================================
        private void frmMovimentacaoCompra_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------------------------------------------------
            //CONEXAO:
            //-----------------------------------------------------------------------------------------------------------------------
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

            try
            {

                // ajustar o tamanho do form ao iniciar 590; 575
                //this.Size = 590 , 575;

                //indicar qual botão inicia ativo ou desativo:
                this.alteraBotoes(1);

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: INCIAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                cx.Conectar();//CONECTAR NO BANCO - para poder usar a transação, tem que ser usado aénas uma conexao, antes cada tabela teinha seu conetar
                cx.IniciarTransacao();//inicia transação no banco SQL - Feito para acoes que envolvem mais de uma tabela https://youtu.be/fA_T1ywEXqw

                BLLTipoPagamento bll = new BLLTipoPagamento(cx);

                //carregar o combobox: DataSource indica a origem dos dados
                cbTPagto.DataSource = bll.Localizar("");//retornar um datatable com todas as catagorias
                cbTPagto.DisplayMember = "tpa_nome"; //qual campo sera monstrado, (Fica Visivel)
                cbTPagto.ValueMember = "tpa_cod"; // indicar qual campo vai ser guardado como codigo...este que vai ser gravado no BD

                //auto completar combobox: https://youtu.be/duG7x9KR4jA?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=340
                cbTPagto.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbTPagto.AutoCompleteSource = AutoCompleteSource.ListItems;

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: TERMINAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++                    
                //so vai gravar, se for nas tres tabelas
                cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                cx.Desconectar();//desconetar do banco

                //ajusta o tamanho:
                this.Size = new Size(595, 600);
                //this.StartPosition = FormStartPosition.CenterScreen;
                pnFinalizaCompra.Location = new Point(12, 12);

            }
            catch (Exception erro) // caso der algum erro...(não limpa a tela)
            {
                MessageBox.Show("Erro ao gravar dados da Compra : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario  
                cx.CancelarTransacao();//caso de erro desfaz todas as ações
                cx.Desconectar();//desconetar do banco
            }
        }

        //=============================================================================================================
        public void LimpaTela()
        {
            txtComCod.Clear();
            txtNFiscal.Clear();
            txtForCod.Clear();
            txtProdCod.Clear();
            lbNomeFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
            lbProduto.Text = "Informe o código do produto ou clique em localizar";
            txtQtd.Clear();
            txtValorUnit.Clear();
            txtTotalCompra.Clear();

            //limpar lista de intes:
            dgvItens.Rows.Clear();
        }

        //=============================================================================================================
        private void btInserir_Click(object sender, EventArgs e)
        {
            //Variavel fo form modelo indica qual ação sera feita ao clicar neste botão:
            this.operacao = "inserir";//usado em condições porteriormente - aula 08 metodo gravar

            //zera valor para iniciar uma nova compra:
            this.totalCompra = 0;

            //inicia com pelo menos uma parcela
            cbNParcela.Text = "1";
            txtNFiscal.Text = "0";

            //indicar qual botão inicia ativo ou desativo:
            this.alteraBotoes(2);//aqui ja ativa os campos que estiverem no painel pnDados...
        }

        //=============================================================================================================
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela(); // limpar a tela 

            //mostra o painel de finalização:
            pnFinalizaCompra.Visible = false;

            this.alteraBotoes(1);//volta os botoes para o estado original
            //zera valor para iniciar uma nova compra:
            this.totalCompra = 0;
        }

        //=============================================================================================================
        private void btSalvar_Click(object sender, EventArgs e) // ver arredondamento das parcelas:  https://youtu.be/zQNqNjFuX8c?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA
        {
            //limpar dados anteriores
            dgvParcelas.Rows.Clear();

            //passa o numero de parcelas para uma variavel
            int parcelas = Convert.ToInt32(cbNParcela.Text);//numero de parcelas selecionada

            //Double totallocal = Convert.ToDouble(txtTotalCompra.Text);//pega o valor total da tela
            Double totallocal = this.totalCompra; //ou pega o  valor ja armazenado na vairiavel 
            double valor = totallocal / parcelas; // obtem o valor de cada parcela, divide o valor pelo numero de parcela

            DateTime dt = new DateTime();//cria um objeto data https://youtu.be/8FobGaSRB8A?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1175
            dt = dtDataIniPgt.Value;//captura a data inicial do pagamento

            //mostra o total da compra no label:
            lbValorTotal.Text = this.totalCompra.ToString();

            //vai gerar o numero de parcelas com datas e valor
            for (int i = 1; i <= parcelas; i++) // laço pelo numero de parcelas https://youtu.be/TfnIBSay0L0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=76
            {
                //a cada laço, cria uma vetor i=numero da parcela, valor= valor da parcela
                String[] k = new String[] { i.ToString(), valor.ToString(), dt.Date.ToString() };

                //adiciona a linha no datagrid
                this.dgvParcelas.Rows.Add(k);

                if (dt.Month != 12)//se o mes da data é diferente de 12, ou seja ainda possui meses para acabar o ano
                {
                    //dt = new DateTime(dt.Year, dt.Month + 1, dt.Day);//encrementa o mes  
                    dt = dt.AddMonths(1);  // adiciona 01 mês na data automaticamente﻿

                }
                else
                {
                    //se o mes for 12 , altera o ano da parcela e o mes para 1
                    dt = new DateTime(dt.Year + 1, 1, dt.Day); // https://youtu.be/TfnIBSay0L0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=332
                }

                //ocultar dados da compra:
                pnDados.Visible = false;
                pnBotoes.Visible = false;

                //mostra o painel de finalização:
                pnFinalizaCompra.Visible = true;
            }
        }

        //=============================================================================================================
        private void btAlterar_Click(object sender, EventArgs e) //https://youtu.be/NRKmeODwsB4?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=277
        {
            //-----------------------------------------------------------------------------------------------------------------------
            //CONEXAO:
            //-----------------------------------------------------------------------------------------------------------------------
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

            try //CONEXAO:
            {
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: INCIAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                cx.Conectar();//CONECTAR NO BANCO - para poder usar a transação, tem que ser usado aénas uma conexao, antes cada tabela teinha seu conetar
                cx.IniciarTransacao();//inicia transação no banco SQL - Feito para acoes que envolvem mais de uma tabela https://youtu.be/fA_T1ywEXqw

                //nao deixar alterar compra se ja tiver sido efetuado alguma pagamento:
                try
                {
                    //pega o codigo da compra:
                    int CodigoCompra = Convert.ToInt32(txtComCod.Text);

                    //criar objetos BLL:
                    BLLCompra bllCP = new BLLCompra(cx); //passa a string de conexao

                    //Validar se tem parcelas pagas:
                    int Qtde = bllCP.QuantidadeParcePagas(CodigoCompra);
                    //se tiver parcelas pagas
                    if (Qtde > 0)
                    {
                        DialogResult g = MessageBox.Show("Esta Compra possui Parcelas Pagas! \n Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                        //caso responder sim...
                        if (g.ToString() == "No")
                        {
                            cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                            cx.Desconectar();//desconetar do banco
                            return;
                        }
                    }
                }
                catch // sem o Exception, qualquer tipo de erro
                {
                    MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                    this.alteraBotoes(3);
                }

                //Liberar alterar
                this.operacao = "alterar";
                this.alteraBotoes(2);

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: TERMINAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++                    
                //so vai gravar, se for nas tres tabelas
                cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                cx.Desconectar();//desconetar do banco
            }
            catch (Exception erro) // caso der algum erro...(não limpa a tela)
            {
                MessageBox.Show("Erro ao gravar dados da Compra : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario  
                cx.CancelarTransacao();//caso de erro desfaz todas as ações
                cx.Desconectar();//desconetar do banco
            }
        }

        //=============================================================================================================
        private void btExcluir_Click(object sender, EventArgs e) // https://youtu.be/U_JhTWIVRro?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA
        {
            //tem que excluir os itens relacionados em todas as tabelas em um sequencia logica:
            //tem que excluir na sequencia inversa em que se gravou a compra

            //-----------------------------------------------------------------------------------------------------------------------
            //CONEXAO:
            //-----------------------------------------------------------------------------------------------------------------------
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

            try //CONEXAO:
            {
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: INCIAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                cx.Conectar();//CONECTAR NO BANCO - para poder usar a transação, tem que ser usado aénas uma conexao, antes cada tabela teinha seu conetar
                cx.IniciarTransacao();//inicia transação no banco SQL - Feito para acoes que envolvem mais de uma tabela https://youtu.be/fA_T1ywEXqw

                //Validar, excluir compra se ja tiver sido efetuado alguma pagamento:
                try
                {
                    DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                    //caso responder sim...
                    if (d.ToString() == "Yes")
                    {
                        //pega o codigo da compra:
                        int CodigoCompra = Convert.ToInt32(txtComCod.Text); 

                        //criar objetos BLL:
                        BLLParcelasCompra bllPar = new BLLParcelasCompra(cx);
                        BLLItensCompra bllITen = new BLLItensCompra(cx);
                        BLLCompra bllCP = new BLLCompra(cx); //passa a string de conexao

                        //verificar se tem parcelas pagas:
                        int Qtde = bllCP.QuantidadeParcePagas(CodigoCompra);

                        if (Qtde > 0)//se tiver parcelas pagas
                        {
                            DialogResult g = MessageBox.Show("Esta Compra possui Parcelas Pagas Deseja! \n Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);//confirmar antes de excluir
                            //caso responder sim...
                            if (g.ToString() == "No")
                            {
                                //cancela esta ação:
                                cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                                cx.Desconectar();//desconetar do banco
                                return;
                            }
                        }

                        //---------------------------------------------------------------------------------------------------------------------------
                        //03 - Excluir as parcelas da compra:
                        //---------------------------------------------------------------------------------------------------------------------------                    
                        bllPar.ExcluirTodasAsParcelas(CodigoCompra);

                        //---------------------------------------------------------------------------------------------------------------------------
                        //02 - Excluir itens da compra:
                        //---------------------------------------------------------------------------------------------------------------------------                    
                        bllITen.ExcluirTodosOsItens(CodigoCompra);

                        //---------------------------------------------------------------------------------------------------------------------------
                        //01 - Excluir compra:
                        //---------------------------------------------------------------------------------------------------------------------------                    
                        bllCP.Excluir(Convert.ToInt32(txtComCod.Text));//retorna erro se este codigo ja estiver sendo utilizado como chave em outra tabela

                        //Mensagem de sucesso:
                        MessageBox.Show("Cadastro excluido com sucesso!");
                    }

                }
                catch // sem o Exception, qualquer tipo de erro
                {
                    MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                    this.alteraBotoes(3);
                    cx.CancelarTransacao();//caso de erro desfaz todas as ações
                    cx.Desconectar();//desconetar do banco
                }                   

                this.LimpaTela();
                this.alteraBotoes(1);

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: TERMINAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++                    
                //so vai gravar, se for nas tres tabelas
                cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                cx.Desconectar();//desconetar do banco
            }
            catch (Exception erro) // caso der algum erro...(não limpa a tela)
            {
                MessageBox.Show("Erro ao gravar dados da Compra : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario  
                cx.CancelarTransacao();//caso de erro desfaz todas as ações
                cx.Desconectar();//desconetar do banco
            }
        }

        //=============================================================================================================
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //exiber o formulario de consulta compra:
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCompra bll = new BLLCompra(cx);
                ModeloCompra modelo = bll.CarregaModeloCompra(f.codigo);//carrega o modelo da comprea pelo codigo
                //--------------------------------------------------------------------------------------------------------
                //  CARREGAR OS DADOS DA COMPRA
                //--------------------------------------------------------------------------------------------------------
                txtComCod.Text = modelo.ComCod.ToString();
                txtNFiscal.Text = modelo.ComNfiscal.ToString();
                dtDataCompra.Value = modelo.ComData;
                txtForCod.Text = modelo.ForCod.ToString();
                txtForCod_Leave(sender, e);//evento escrever o nome do fornecedor
                //rodapé:
                cbNParcela.Text = modelo.ComNparcelas.ToString();
                txtTotalCompra.Text = modelo.ComValorTotal.ToString();//VALOR TOTAL
                this.totalCompra = modelo.ComValorTotal;//armazena o total na variavel

                //fazer um LOCALIZAR - select para trazer o numero de parcela
                //fazer um LOCALIZAR - select para trazer a data da primeira parcela

                //TIPO DE PAGAMENTO.
                cbTPagto.SelectedValue = modelo.TpaCod;


                //carregar itens da compra: https://youtu.be/rMOyapoHTx0?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=204
                BLLItensCompra bLLIt = new BLLItensCompra(cx);
                DataTable tabelaIt = bLLIt.Localizar(modelo.ComCod);//passa os itens da compra para uma tabela:
                for (int i = 0; i < tabelaIt.Rows.Count; i++)//enquanto i for menos que o numero de linhas retornodo
                {
                    //pega os valores: cada loop vai para a prox. linha = i
                    string icod = tabelaIt.Rows[i]["pro_cod"].ToString();
                    string inome = tabelaIt.Rows[i]["pro_nome"].ToString();
                    string iqtd = tabelaIt.Rows[i]["itc_qtde"].ToString();
                    string ivund = tabelaIt.Rows[i]["itc_valor"].ToString();

                    //calcula o valor total de cada intem:
                    Double TotalLocalx = Convert.ToDouble(tabelaIt.Rows[i]["itc_qtde"]) * Convert.ToDouble(tabelaIt.Rows[i]["itc_valor"]);

                    //monta uma matriz da linha com os calores de cada coluna:
                    String[] iten = new String[] { icod, inome, iqtd, ivund, txtTotalCompra.Text, TotalLocalx.ToString() };
                    this.dgvItens.Rows.Add(iten);//adicoina os itens da linha no datagrdi...


                }

                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }

            //destroi o obejto
            f.Dispose();
        }

        private void btLocFor_Click(object sender, EventArgs e)
        {
            FrmConsultaFornecedor f = new FrmConsultaFornecedor();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                //passa o codigo para a tela de compra:
                txtForCod.Text = f.codigo.ToString();
                //chama o evendo para carregar o nome do fornecedor
                txtForCod_Leave(sender, e);


            }
        }

        private void txtForCod_Leave(object sender, EventArgs e)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);
                ModeloFornecedor modelo = bll.CarregaModeloFornecedor(Convert.ToInt32(txtForCod.Text));

                //passar os valores do campo nome:
                lbNomeFornecedor.Text = modelo.ForNome;

            }
            catch (Exception)
            {
                txtForCod.Clear();//limpa o campo
                lbNomeFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
           
            }

        }

        //===============================================================================================================================================
        private void btLocProd_Click(object sender, EventArgs e)
        {
            FrmConsultaProduto f = new FrmConsultaProduto();
            f.ShowDialog();

            //verificar se tem um codigo carregado:{diferente de zero}
            if (f.codigo != 0)
            {
                //passa o codigo para a tela de compra:
                txtProdCod.Text = f.codigo.ToString();

                //chama o evendo para carregar o nome do fornecedor
                txtProdCod_Leave(sender, e);


            }
        }

        //================================================================================================================================================
        private void txtProdCod_Leave(object sender, EventArgs e)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);
                ModeloProduto modelo = bll.CarregaModeloProduto(Convert.ToInt32(txtProdCod.Text));//no modelo ja tenho todas as informações
                txtQtd.Text = "1"; //vai dar entrada de pelo monos 1 qtd
                txtValorUnit.Text = modelo.ProValorPago.ToString();//mostra valor que foi pago, conforme cadastro

                //passar os valores do campo nome:
                lbProduto.Text = modelo.ProNome;

            }
            catch (Exception)
            {
                txtProdCod.Clear();//limpa o campo
                lbProduto.Text = "Informe o código do fornecedor ou clique em localizar";

            }
        }

        private void btAddProd_Click(object sender, EventArgs e) // https://youtu.be/5Edv-EPWX18?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=492
        {
            //VERIFICAR SE OS CAMPOS DO PRODUTO ESTA PREENCHIDO
            if ((txtForCod.Text != "") && (txtProdCod.Text != "") && (txtQtd.Text != "") && (txtValorUnit.Text != ""))
            {
                //CALCULAR O VALOR TOTAL DO ITEM:
                Double TotalLocal = Convert.ToDouble(txtQtd.Text) * Convert.ToDouble(txtValorUnit.Text);

                //atualiza o total geral da compra na tela:
                this.totalCompra = this.totalCompra + TotalLocal;

                //inserir o produto na GRID:
                //criar um VETOR de string, a ordem das string deve ser a mesma das colunas da GRid
                String[] i = new string[] { txtProdCod.Text, lbProduto.Text, txtQtd.Text,txtValorUnit.Text, TotalLocal.ToString() };
                //inserir linha com os dados armazenados no vetor:  https://youtu.be/5Edv-EPWX18?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=834
                this.dgvItens.Rows.Add(i);

                //limpar os campos para uma novo intem:
                txtProdCod.Clear();
                //lbNomeFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
                lbProduto.Text = "Informe o código do produto ou clique em localizar";
                txtQtd.Clear();
                txtValorUnit.Clear();

                //atualizar o total da compra na tela:
                txtTotalCompra.Text = this.totalCompra.ToString();
            }
        }

        //ação de remover algum item da lista:
        private void dgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ao selecionar a linha os dados dos itens vão para os seus campos correspondente:
            if (e.RowIndex >= 0)//se maior que zero, significa que foi clicado
            {
                //joga os dados de cada coluna em seus campos respstivamente:
                txtProdCod.Text = dgvItens.Rows[e.RowIndex].Cells[0].Value.ToString();
                lbProduto.Text = dgvItens.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQtd.Text = dgvItens.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtValorUnit.Text = dgvItens.Rows[e.RowIndex].Cells[3].Value.ToString();
                Double valor =Convert.ToDouble(dgvItens.Rows[e.RowIndex].Cells[4].Value.ToString());//guarda o valor do item em uma variavel, para descontar do total da tela
                //atualiza o total geral da compra na tela:
                this.totalCompra = Math.Abs( this.totalCompra - valor);//diminui o valor do item retirado Sempre retorna positivo               

                //Remove o item da grid:
                dgvItens.Rows.RemoveAt(e.RowIndex);//vai remover o item selecionado na grid

                //atualizar o total da compra na tela:
                txtTotalCompra.Text = this.totalCompra.ToString();

            }
        }

        //cancelar o fechamento das parcelas
        private void btCancelarFechamento_Click(object sender, EventArgs e)
        {
            //ocultar o painel de finalização:
            pnFinalizaCompra.Visible =false;

            //Mostrar dados da compra:
            pnDados.Visible = true;
            pnBotoes.Visible = true;
        }

        //Salvar compra:
        //Vai movimentar dados nas 4 tabelas:
        //select* from compra
        //select* from itenscompra
        //select* from parcelascompra
        //select* from produto -- atualiza Qtd. através de um tigger
        private void btSalvarCompra_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------------------------------------------------
            //CONEXAO:
            //-----------------------------------------------------------------------------------------------------------------------
            //Conexão - obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);//Recebe a string da conexão da classe DadosDaConexão

            try // conexao:
            {
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                //CONEXAO: INCIAR TRANSAÇÃO
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                cx.Conectar();//CONECTAR NO BANCO - para poder usar a transação, tem que ser usado aénas uma conexao, antes cada tabela teinha seu conetar
                cx.IniciarTransacao();//inicia transação no banco SQL - Feito para acoes que envolvem mais de uma tabela https://youtu.be/fA_T1ywEXqw

                //-----------------------------------------------------------------------------------------------------------------------
                //SALVAMENTO PROCESSO DA COMPRA:
                //-----------------------------------------------------------------------------------------------------------------------
                try //tratamento de erro
                {
                    //------------------------------------------------------------------------------------------------------------
                    //01 - COMPRA:
                    //------------------------------------------------------------------------------------------------------------
                    //criar o modelo compra:
                    ModeloCompra modeloCompra = new ModeloCompra();//cria uma objeto que representa os dados da tabela catagoria
                    //Criar um BLL DA COMPRA
                    BLLCompra bll = new BLLCompra(cx);
                    //Carregar os campos da compra:
                    modeloCompra.ComData = dtDataCompra.Value;
                    modeloCompra.ComNfiscal = Convert.ToInt32(txtNFiscal.Text);
                    modeloCompra.ComNparcelas = Convert.ToInt32(cbNParcela.Text);
                    modeloCompra.ComStatus = "ativa";//pode controlar como pedito, e ainda nao finalizou a compra.. ver!!
                    modeloCompra.ComValorTotal= Convert.ToDouble(txtTotalCompra.Text);
                    modeloCompra.ForCod = Convert.ToInt32(txtForCod.Text);
                    modeloCompra.TpaCod = Convert.ToInt32(cbTPagto.SelectedValue);                    

                    //------------------------------------------------------------------------------------------------------------
                    // 02 - ITENS DA COMPRA:
                    //------------------------------------------------------------------------------------------------------------
                    //criar o modelo itens compra:
                    ModeloItensCompra ModItens = new ModeloItensCompra();
                    //Criar um BLL Itens
                    BLLItensCompra bllItensc = new BLLItensCompra(cx);

                    //------------------------------------------------------------------------------------------------------------
                    // 03 - PARCELAS COMPRA:
                    //------------------------------------------------------------------------------------------------------------
                    //criar o modelo itens compra: https://youtu.be/oP5-jHpOhwE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=255
                    ModeloParcelasCompra ModParcelas = new ModeloParcelasCompra();
                    //Criar um BLL Itens
                    BLLParcelasCompra bllParcelas = new BLLParcelasCompra(cx);

                    //------------------------------------------------------------------------------------------------------------
                    //verificar qual o tipo de operação que vai executar ao gravar
                    if (this.operacao == "inserir")//valida se é um inserção, verificar o valor da variavel operação
                    {
                        //------------------------------------------------------------------------------------------------------------
                        //01 - cadastrar onformações da Compra - ok
                        //------------------------------------------------------------------------------------------------------------
                        bll.Incluir(modeloCompra);//passa o nome para o metodo incluir // https://youtu.be/C6qCveils_o?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=1078

                        //------------------------------------------------------------------------------------------------------------
                        //02 - cadastrar os intens da compra 
                        //------------------------------------------------------------------------------------------------------------
                        for (int i = 0; i < dgvItens.RowCount; i++)//pelo numero de linhas de itens //https://youtu.be/TJ_jhtk1yN8?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=395
                        {
                            //Carregar os campos dos iten compra  https://youtu.be/NStzTZnp4nU?t=168                        
                            ModItens.ItcCod = i + 1;
                            ModItens.ComCod = modeloCompra.ComCod;//retorna do Dall
                            ModItens.ProCod = Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value);
                            ModItens.ItcQtde = Convert.ToDouble(dgvItens.Rows[i].Cells[2].Value);
                            ModItens.ItcValor = Convert.ToDouble(dgvItens.Rows[i].Cells[3].Value);
                            //incluir itens da compra: 
                            bllItensc.Incluir(ModItens);

                            //atualizar a qtd de produtos na tabela de produtos VIA SQL // https://youtu.be/NStzTZnp4nU  +  https://youtu.be/yhWGaBku24U?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=405
                            //trigger:gatilho no Banco, tabela itenscompra Nome: tgiIncrementarEstoqueProduto                    
                        }

                        //------------------------------------------------------------------------------------------------------------
                        //03 - cadastrar as parcelas da compra https://youtu.be/oP5-jHpOhwE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=264
                        //------------------------------------------------------------------------------------------------------------
                        for (int i = 0; i < dgvParcelas.RowCount; i++)//pelo numero de linhas das parcelas
                        {
                            //Carregar os campos da parcelas
                            ModParcelas.ComCod = modeloCompra.ComCod;
                            ModParcelas.PcoCod = Convert.ToInt32(dgvParcelas.Rows[i].Cells[0].Value);
                            ModParcelas.PcoValor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                            ModParcelas.PcoDatavecto = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);
                            //incluir parcelas:
                            bllParcelas.Incluir(ModParcelas);
                        }
                    
                        //MENSAGEM DE SUCESSO:
                        MessageBox.Show("Compra efetuada: Código " + modeloCompra.ComCod.ToString());//retorna a mensagem como o codigo do item que foi gerado
                    
                    }
                    else //alterar uma Compra
                    {

                        //------------------------------------------------------------------------------------------------------------
                        //Alterar compra 
                        //------------------------------------------------------------------------------------------------------------
                        modeloCompra.ComCod = Convert.ToInt32(txtComCod.Text);//alterar a Compra correspondente ao codigo exixtente na tela
                        bll.Alterar(modeloCompra);//alterar conforme codigo da compra na tela

                        //------------------------------------------------------------------------------------------------------------
                        //Alterar os intens da compa 
                        //------------------------------------------------------------------------------------------------------------
                        bllItensc.ExcluirTodosOsItens(modeloCompra.ComCod);//excluir todos os itens
                        for (int i = 0; i < dgvItens.RowCount; i++)//cadastra novamente as parcelas
                        {
                            //inserir os itens da compra na tabela  https://youtu.be/NStzTZnp4nU?t=168                        
                            ModItens.ItcCod = i + 1;
                            ModItens.ComCod = modeloCompra.ComCod;//retorna do Dall
                            ModItens.ProCod = Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value);
                            ModItens.ItcQtde = Convert.ToDouble(dgvItens.Rows[i].Cells[2].Value);
                            ModItens.ItcValor = Convert.ToDouble(dgvItens.Rows[i].Cells[3].Value);
                            //incluir dados: 
                            bllItensc.Incluir(ModItens);

                            //atualizar a qtd de produtos na tabela de produtos VIA SQL // https://youtu.be/NStzTZnp4nU  +  https://youtu.be/yhWGaBku24U?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=405
                            //trigger:gatilho no Banco, tabela itenscompra Nome: tgiIncrementarEstoqueProduto                    
                        }

                        //------------------------------------------------------------------------------------------------------------
                        //Alterar as parcelas da compra https://youtu.be/oP5-jHpOhwE?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=264
                        //------------------------------------------------------------------------------------------------------------
                        bllParcelas.ExcluirTodasAsParcelas(modeloCompra.ComCod);//excluir todos as parcelas
                        for (int i = 0; i < dgvParcelas.RowCount; i++)//cadastra novamente as parcelas
                        {
                            ModParcelas.ComCod = modeloCompra.ComCod;
                            ModParcelas.PcoCod = Convert.ToInt32(dgvParcelas.Rows[i].Cells[0].Value);
                            ModParcelas.PcoValor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                            ModParcelas.PcoDatavecto = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);
                            //incluir:
                            bllParcelas.Incluir(ModParcelas);
                        }
                        MessageBox.Show("Cadastro alterado");//mostrar mensagem de confirmação
                    }

                    // limpar a tela 
                    this.LimpaTela();

                    //ocultar o painel de finalização:
                    pnFinalizaCompra.Visible = false;

                    //Mostrar dados da compra:
                    pnDados.Visible = true;

                    //Mostrar botoes:
                    pnBotoes.Visible = true;

                    this.alteraBotoes(1);//volta os botoes para o estado padrão

                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //CONEXAO: TERMINAR TRANSAÇÃO
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++                    
                    //so vai gravar, se for nas tres tabelas
                    cx.TerminarTransacao();//Efetua um comit, confirmar as alterações no banco
                    cx.Desconectar();//desconetar do banco
                }
                catch (Exception erro) // caso der algum erro...(não limpa a tela)
                {
                    MessageBox.Show("Erro ao gravar dados da Compra : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario  
                    cx.Desconectar();//desconetar do banco
                }
            }
            catch (Exception erro) // casa der algum erro na conexao
            {
                MessageBox.Show("Erro ao conectar no Banco SQL : \n" + erro.Message);//retorna mensagem do sistema, melhorar mensagem para o usuario
                cx.CancelarTransacao();//caso de erro desfaz todas as ações
                cx.Desconectar();//desconetar do banco se der erro
            }
        }
    }
}
