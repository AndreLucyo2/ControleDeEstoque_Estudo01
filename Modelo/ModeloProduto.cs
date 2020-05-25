using System;
using System.IO;

namespace Modelo //aula 24
{
    public class ModeloProduto
    {
        public ModeloProduto() // construtor com propriedades conforme campos criados na tabela do BD
        {
            this.ProCod = 0;
            this.ProNome = "";
            this.ProDescricao = "";
            //null - campo ProFoto nao exixte aula 25 10:07
            this.ProValorPago = 0;
            this.ProValorVenda = 0;
            this.ProQtde = 0;
            this.UmedCod = 0;
            this.CatCod = 0;
            this.ScatCod = 0;
        }

        // construtor com parametros conforme campos criados na tabela do BD, recebando caminho da foto  -  aula 29 3:50 ver metodo carrega imagem
        public ModeloProduto(int pro_cod, String pro_nome, String pro_descricao, 
            String pro_foto, Double pro_valorpago, Double pro_valorvenda, Double pro_qtde,
            int umed_cod, int cat_cod, int scat_cod)
        {
            this.ProCod = pro_cod;
            this.ProNome = pro_nome;
            this.ProDescricao = pro_descricao;
            this.CarregaImagem(pro_foto); //Recebe o caminhoa da foto , eutilizar o metodo carregar imagem (aula 25 3:40 ) grava a imagem do disco e converter , e armazena no BD  https://www.youtube.com/watch?v=Y4z8kYPeZqY&feature=youtu.be&list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=208
            this.ProValorPago = pro_valorpago;
            this.ProValorVenda = pro_valorvenda;
            this.ProQtde = pro_qtde;
            this.UmedCod = umed_cod;
            this.CatCod = cat_cod;
            this.ScatCod = scat_cod;
        }

        // neste metodo so fifere que recebe a foto como vetor
        public ModeloProduto(int pro_cod, String pro_nome, String pro_descricao, 
            Byte[] pro_foto, Double pro_valorpago, Double pro_valorvenda, Double pro_qtde,
            int umed_cod, int cat_cod, int scat_cod)
        {
            this.ProCod = pro_cod;
            this.ProNome = pro_nome;
            this.ProDescricao = pro_descricao;
            this.ProFoto = pro_foto;//Recebe um vetor pronto, grava um vetor de imagem direto em Byte aula 25
            this.ProValorPago = pro_valorpago;
            this.ProValorVenda = pro_valorvenda;
            this.ProQtde = pro_qtde;
            this.UmedCod = umed_cod;
            this.CatCod = cat_cod;
            this.ScatCod = scat_cod;
        }

        private int _pro_cod;//cria uma dado privado, que armazena informação
        public int ProCod // toda a propriedade para padronizar, deve comessar com letra maiuscula
        {
            get
            {
                return this._pro_cod;
            }
            set
            {
                this._pro_cod = value;
            }
        }

        private String _pro_nome;
        public String ProNome
        {
            get
            {
                return this._pro_nome;
            }
            set
            {
                this._pro_nome = value;
            }
        }

        private String _pro_descricao;
        public String ProDescricao
        {
            get
            {
                return this._pro_descricao;
            }
            set
            {
                this._pro_descricao = value;
            }
        }

        //pripriedade que carrega o caminhoa da foto aula 24  9:10 ref: https://youtu.be/B_nlsDPOL0Y?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=568
        private byte[] _pro_foto; // representa um vetor de byte https://youtu.be/Y4z8kYPeZqY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=42
        public byte[] ProFoto // propriedade vai gravar a foto na banco em binario
        {
            get { return this._pro_foto; }
            set { this._pro_foto = value; }
        }

        // https://youtu.be/Y4z8kYPeZqY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=208
        //https://www.youtube.com/watch?v=Y4z8kYPeZqY&feature=youtu.be&list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=208
        // no sqlserver o tipo de dado da coluna deve ser image. no power architect escolher LONGVARBINARY
        public void CarregaImagem(String imgCaminho) //vai carregar uma imgem no banco em forma bruta, bits - aula 25 3:00
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho))
                    return;
                //fornece propriedadese métodos de instância para criar, copiar,
                //excluir, mover, e abrir arquivos, e ajuda na criação de objetos FileStream
                FileInfo arqImagem = new FileInfo(imgCaminho);
                //Expõe um Stream ao redor de um arquivo de suporte
                //síncrono e assíncrono operações de leitura e gravar. ref: https://youtu.be/Y4z8kYPeZqY?list=PLfvOpw8k80Wqj1a66Qsjh8jj4hlkzKSjA&t=309
                FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);//representa a foto em bits, de maneira bruta na memoria do computador
                //aloca memória para o vetor
                this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];//alocar memoria para alocar a foto
                //Lê um bloco de bytes do fluxo e grava os dados em um buffer fornecido.
                int iBytesRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));//vai ler todo o conteudo de fs e atmazenar em ProFoto
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        private Double _pro_valorpago;
        public Double ProValorPago
        {
            get
            {
                return this._pro_valorpago;
            }
            set
            {
                this._pro_valorpago = value;
            }
        }

        private Double _pro_valorvenda;
        public Double ProValorVenda
        {
            get
            {
                return this._pro_valorvenda;
            }
            set
            {
                this._pro_valorvenda = value;
            }
        }

        private Double _pro_qtde;
        public Double ProQtde
        {
            get
            {
                return this._pro_qtde;
            }
            set
            {
                this._pro_qtde = value;
            }
        }

        private int _umed_cod;
        public int UmedCod
        {
            get
            {
                return this._umed_cod;
            }
            set
            {
                this._umed_cod = value;
            }
        }

        private int _cat_cod;
        public int CatCod
        {
            get
            {
                return this._cat_cod;
            }
            set
            {
                this._cat_cod = value;
            }
        }

        private int _scat_cod;
        public int ScatCod
        {
            get
            {
                return this._scat_cod;
            }
            set
            {
                this._scat_cod = value;
            }
        }
    }
}
