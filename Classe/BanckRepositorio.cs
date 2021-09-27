using System;
using System.Collections.Generic;
using DIO_BANCK.Interface;

namespace DIO_BANCK
{
    public class BanckRepositorio : IRepositorio<Banck>
    {
    	private List<Banck> ListaBanck = new List<Banck>();

        public void Atualiza (int id, Banck objeto)
        {
            ListaBanck[id] = objeto;
        }
			 
        public void Exclui(int id)
		{
			ListaBanck[id].Excluir();
		}

        public void Insere(Banck objeto)
		{
			ListaBanck.Add(objeto);
		}

        public List<Banck> Lista()
		{
			return ListaBanck;
		}

        public int ProximoId()
		{
			return ListaBanck.Count;
		}

        public Banck RetornaPorId(int id)
		{
			return ListaBanck[id];
		}
         
    }
    
}