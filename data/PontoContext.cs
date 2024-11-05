using SistemaDePonto.Models;
using System.Collections.Generic;

namespace SistemaDePonto.Data
{
    public class PontoContext
    {
        private static List<Ponto> pontos = new List<Ponto>();
        private static int nextId = 1;

        public List<Ponto> GetPontos() => pontos;
        
        public Ponto? GetById(int id) 
        { 
            return pontos.SingleOrDefault(p => p.Id == id);   
        }

        public Ponto AddPonto(Ponto ponto)
        {
            ponto.Id = nextId++;
            pontos.Add(ponto);
            return ponto;
        }

        public void UpdatePonto(int id, DateTime data)
        {
           Ponto? ponto = GetById(id);
           if (ponto is null)
           {
               return;
           }

           ponto.Data = data;
        }

        public void DeletePonto(int id)
        {
            pontos = pontos.Where(p => p.Id != id).ToList();
        }
    }
}