using System;

namespace DIO_BANCK
{
    class Program
    {

        static BanckRepositorio repositorio = new BanckRepositorio();
		static void Main(string[] args)
        {
			
        
            string opc = obterOpc();
                while (opc.ToUpper() != "X")
                {
                    switch (opc)
                    {   
                        case "1":
							Console.WriteLine();
                            Console.WriteLine("Cadastrando");
                            InserirCadastro();
							break;
                        case "2":
							Console.WriteLine();
                            Console.WriteLine("Listando");
                            ListarCadastros();
                            break;

                        case "3":
							Console.WriteLine();
                            Console.WriteLine("Excluindo");
                            ExcluirCadastro();
                            break;

                        case "4":
							Console.WriteLine();
                            Console.WriteLine("Pesquisando");
                            VisualizarCadastro();
                            break;

						case "5":
							Console.WriteLine();
                            Console.WriteLine("Atualizar");
                            AtualizarCadastro();
							break;

                        
                        default:
                                throw new ArgumentOutOfRangeException();
                    }

                    opc = obterOpc();
                    
                }

                Console.WriteLine("---");
			    Console.ReadLine();
            
            
        }



        private static void ExcluirCadastro()
		{	
			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma registro encontrado.");
				return;
			}{
				Console.Write("Digite o id do cadastro: ");
				int indiceCadastro = int.Parse(Console.ReadLine());

				repositorio.Exclui(indiceCadastro);
			}
		}



        private static void VisualizarCadastro()
		{
			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma registro encontrado.");
				return;
			}{
				Console.Write("Digite o id do cadastro: ");
			
				int indiceCadastro = int.Parse(Console.ReadLine());
				var banck = repositorio.RetornaPorId(indiceCadastro);


				Console.WriteLine(banck);
			}
		}



        private static void AtualizarCadastro()
		{

			
			Console.Write("Digite o id do cadastro: ");
			int indiceCadastro = int.Parse(Console.ReadLine());

			
			
			Console.Write("Digite o Nome para cadastrar: ");
			string entradaNome = Console.ReadLine();

			while (entradaNome == "")
			{
				Console.Write("Digite o Nome: ");
				entradaNome = Console.ReadLine();
			}
			


			Console.Write("Digite o CPF: ");
			string entradaCpf = Console.ReadLine();
			entradaCpf = entradaCpf.Replace("."," ").Replace("-"," ").Replace(" ","");
			var tam = 0;
			tam = entradaCpf.Length;
			while ( tam != 11 ){
				Console.WriteLine("CPF inválido");
				Console.WriteLine("Digite novamente o CPF: ");
				entradaCpf = Console.ReadLine();
				entradaCpf = entradaCpf.Replace("."," ").Replace("-"," ").Replace(" ","");
				tam = entradaCpf.Length;

			}


			Console.WriteLine("Deseja digitar atualizar o CNPJ [S/N] ?");
			string sncnpj = Console.ReadLine();

			string entradaCnpj = "";
			int entradaTipo = 0; 

			switch (sncnpj.ToUpper())
			{
				case "S":
					Console.Write("Digite CNPJ: ");
					entradaCnpj = Console.ReadLine();
					entradaCnpj = entradaCnpj.Replace("."," ").Replace("-"," ").Replace("/","").Replace(" ","");
					Console.WriteLine(entradaCnpj);
					tam = entradaCnpj.Length;
					Console.WriteLine(tam);
					while ( tam != 14 ){
						Console.Write("CNPJ inválido");
						Console.Write("Digite novamente o CNPJ: ");
						entradaCnpj = Console.ReadLine();
						entradaCnpj = entradaCnpj.Replace("."," ").Replace("-"," ").Replace("/","").Replace(" ","");
						Console.WriteLine(entradaCnpj);
						tam = entradaCnpj.Length;
						Console.WriteLine(tam);
					
					}
					entradaTipo = 2; 

					break;

				case "N":
					Console.Write("Sem registro de CNPJ");
					entradaTipo = 1;
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
			
			Banck atualizaCadastro = new Banck(id: indiceCadastro,
										tipo_Pessoa: (Tipo_Pessoa)entradaTipo,
										nome: entradaNome,
										cpf: entradaCpf,
										cnpj: entradaCnpj);

			repositorio.Atualiza(indiceCadastro, atualizaCadastro);
		}



        private static void ListarCadastros()
		{
			Console.WriteLine("Listar Cadastrados");



			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma registro encontrado.");
				return;
			}

			foreach (var banck in lista)
			{
                var excluido = banck.retornaExcluido();
                
				Console.WriteLine($"#ID {banck.retornaId()}: - {banck.retornaNome()} {(excluido ? "*Excluído*" : "")}");
			}
		}



        private static void InserirCadastro()
		{
			
			Console.WriteLine("Inserir um novo registro");

			
			Console.Write("Digite o Nome: ");
			string entradaNome = Console.ReadLine();

			while (entradaNome == "")
			{
				Console.Write("Digite o Nome: ");
				entradaNome = Console.ReadLine();
			}
            


			Console.Write("Digite o CPF: ");
			string entradaCpf = Console.ReadLine();
			var tam = 0;

			
			entradaCpf = entradaCpf.Replace("."," ").Replace("-"," ").Replace(" ","");
			tam = entradaCpf.Length;
			while ( tam != 11 ){
				Console.WriteLine("CPF inválido");
				Console.WriteLine("Digite novamente o CPF: ");
				entradaCpf = Console.ReadLine();
				entradaCpf = entradaCpf.Replace("."," ").Replace("-"," ").Replace(" ","");
				Console.WriteLine(entradaCpf);
				tam = entradaCpf.Length;
				Console.WriteLine(tam);
			}
	





			Console.WriteLine("Deseja digitar informar o CNPJ [S/N] ?");
			string sncnpj = Console.ReadLine();

			string entradaCnpj = "";
			int entradaTipo = 0; 

			switch (sncnpj.ToUpper())
			{
				case "S":
					Console.Write("Digite CNPJ: ");
					entradaCnpj = Console.ReadLine();
					entradaCnpj = entradaCnpj.Replace("."," ").Replace("-"," ").Replace("/","").Replace(" ","");
					Console.WriteLine(entradaCnpj);
					tam = entradaCnpj.Length;
					Console.WriteLine(tam);
					while ( tam != 14 ){
						Console.Write("CNPJ inválido");
						Console.Write("Digite novamente o CNPJ: ");
						entradaCnpj = Console.ReadLine();
						entradaCnpj = entradaCnpj.Replace("."," ").Replace("-"," ").Replace("/","").Replace(" ","");
						Console.WriteLine(entradaCnpj);
						tam = entradaCnpj.Length;
						Console.WriteLine(tam);
					
					}

					entradaTipo = 2; 

					break;

				case "N":
					Console.Write("Sem registro de CNPJ");




					entradaTipo = 1;
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}

			Banck novoCadastro = new Banck(id: repositorio.ProximoId(),
										tipo_Pessoa: (Tipo_Pessoa)entradaTipo,
										nome: entradaNome,
										cpf: entradaCpf,
										cnpj: entradaCnpj);




			repositorio.Insere(novoCadastro);
		}


        


        private static string obterOpc()
        {

            Console.WriteLine();
            Console.WriteLine("Sistema DIO BANCK, Online!");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar ");
            Console.WriteLine("2 - Listar cadastrados");
            Console.WriteLine("3 - Excluir cadastro");
            Console.WriteLine("4 - Pesquisar pessoa");
			Console.WriteLine("5 - Atualizar Registro");
			Console.WriteLine("X - Encerrar");


            string opc = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opc;
                
        }

        
    }
}
