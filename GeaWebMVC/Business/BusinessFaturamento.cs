using GeaWebMVC.Business.RepositoryInterfaces;
using GeaWebMVC.Models;
using GeaWebMVC.Utils;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GeaWebMVC.Business
{
    public class BusinessFaturamento : IBusinessFaturamento
    {
        private readonly IRepositoryFaturamento _repositoryFaturamento;
        private readonly IRepositoryRegistroDeFluxo _repositoryRegistroDeFluxo;

        public BusinessFaturamento(IRepositoryFaturamento repositoryFaturamento, IRepositoryRegistroDeFluxo repositoryRegistroDeFluxo)
        {
            _repositoryFaturamento = repositoryFaturamento;
            _repositoryRegistroDeFluxo = repositoryRegistroDeFluxo;
        }

        
        public IEnumerable<Faturamento> GetAll()
        {
            return _repositoryFaturamento.GetAll();
        }

        public Faturamento GetById(int? FaturamentoId)
        {
            return _repositoryFaturamento.GetById(FaturamentoId);
        }

        public void Update(Faturamento faturamento)
        {
            _repositoryFaturamento.Update(faturamento);
        }

        public void Create(Faturamento faturamento)
        {
            _repositoryFaturamento.Add(faturamento);
        }

        public void Remove(Faturamento faturamento)
        {
            _repositoryFaturamento.Remove(faturamento);
        }

        public Faturamento GerarFaturamento(Faturamento faturamento)
        {


            var registros = _repositoryRegistroDeFluxo.Find(r => r.ValorAPagar != null 
                            && r.DataSaida.Value.Year == faturamento.DataCompetencia.Year 
                            && r.DataSaida.Value.Month == faturamento.DataCompetencia.Month
                            && r.FaturamentoId == null).ToList<RegistroDeFluxo>();

            var faturamentoExistente = _repositoryFaturamento.FindSingle(f => f.DataCompetencia.Year == faturamento.DataCompetencia.Year 
                                        && f.DataCompetencia.Month == faturamento.DataCompetencia.Month 
                                        && f.EmpresaId == faturamento.EmpresaId);
            
            if(faturamentoExistente!= null)
            {
                faturamentoExistente.ValorCompetencia += registros.Sum(r => r.ValorAPagar);
                _repositoryFaturamento.Update(faturamentoExistente);
                faturamento = faturamentoExistente;
                
            }
            else
            {
                faturamento.ValorCompetencia = registros.Sum(r => r.ValorAPagar);

                _repositoryFaturamento.Add(faturamento);
            }
                 
            foreach (var registro in registros)
            {
                registro.FaturamentoId = faturamento.Id;
                _repositoryRegistroDeFluxo.Update(registro);
            }

            return faturamento;
        }

        public void SendEmail(Faturamento faturamento)
        {

            MailAddress to = new MailAddress(faturamento.Empresa.Email, faturamento.Empresa.Nome);
            MailMessage email = new MailMessage();
            
            email.SubjectEncoding = System.Text.Encoding.UTF8;            

            email.Subject = "Contato";
            email.Body = " Favor realizar o pagamento da competência<br/> Empresa:  " + faturamento.Empresa.Nome + "<br/> " +
                "Valor a pagar : R$:" + (faturamento.ValorCompetencia * 0.05) ;
            email.IsBodyHtml = true;
            email.BodyEncoding = System.Text.Encoding.UTF8;

            EmailUlts.SendEmail(email);


        }


    }
}