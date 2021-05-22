using System;

namespace DIOBank.Projeto
{
    public class Conta
    {
        // Estrutura dos dados que serão contidos nas contas
        private string Nome { get; set; }
        private double Saldo { get; set; }
		private double Credito { get; set; }
		private OpcoesConta OpcoesConta { get; set; }

        // Método construtor, declaração de variaveis para modificação
        public Conta(string nome, double saldo, double credito, OpcoesConta opcoesConta)
		{   
            this.Nome = nome;
			this.Saldo = saldo;
			this.Credito = credito;
			this.OpcoesConta = opcoesConta;
		}
    
        // Funções atribuídas a classe conta, tipos que ações que poderão ocorrer
        public bool Sacar(double valorSaque)
		{
            // Validar se o saldo é passivel de manipulação
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            
            return true;
		}
    
        // Função simples que acrescenta o valor de deposito na conta selecionada 
        public void Depositar(double valorDeposito)
		{   
            // this.Saldo = this.Saldo + valorDeposito
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}
        // Efetua tranferencia de uma conta a outra usando atribuições dos próprios metodos
        public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }
        // Ainda não entendi muito bem pra que funciona o ToString()
        public override string ToString()
		{
            string retorno = "";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			retorno += "OpcoesConta " + this.OpcoesConta + " | ";
            return retorno;
		
        }
    }
}