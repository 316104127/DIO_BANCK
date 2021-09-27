using System;

namespace DIO_BANCK
{
    public class Banck : EntidadeBase
    {
        private Tipo_Pessoa Tipo_Pessoa{ get; set; }
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Cnpj { get; set; }
        private bool Excluido { get; set; }
       
    

        public Banck(int id, Tipo_Pessoa tipo_Pessoa,string nome, string cpf, string cnpj)
        {
            this.Id = id;
            this.Tipo_Pessoa = tipo_Pessoa;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cnpj = cnpj;
            this.Excluido = false;                
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Pessoa: " + this.Tipo_Pessoa + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "CPF: " + this.Cpf + Environment.NewLine;
            retorno += "CNPJ: " + this.Cnpj + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}