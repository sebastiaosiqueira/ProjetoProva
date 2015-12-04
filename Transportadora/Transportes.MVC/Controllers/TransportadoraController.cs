using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transportes.MVC.ViewModels;
using Transporte.Infra.Data.Contexto;
using Transportes.Application.Interface;
using AutoMapper;
using Transportes.Domain.Entities;
using Transportes.Service.Utility.Util;

namespace Transportes.MVC.Controllers
{
    public class TransportadoraController : Controller
    {
        private readonly ITransportadoraAppService _transportadoraApp;
        // GET: /Transportadora/

        public TransportadoraController(ITransportadoraAppService transportadoraApp)
        {
            _transportadoraApp = transportadoraApp;
        }
        // GET: Clientes
        public ActionResult Index()
        {
            try
            {
                var transportadoraViewModel = Mapper.Map<IEnumerable<Transportadora>, IEnumerable<TransportadoraViewModel>>(_transportadoraApp.GetAll());
                return View(transportadoraViewModel);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            
        }

       
        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var transportadora = _transportadoraApp.GetById(id);
                var transportadoraViewModel = Mapper.Map<Transportadora, TransportadoraViewModel>(transportadora);

                return View(transportadoraViewModel);
            }
            catch (Exception)
            {

                return View("Index");
            }

           
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransportadoraViewModel transportadora)
        {
            try
            {
                string msg = string.Empty;
                //variaveis iniciadas sempre para maiuscula para padronizaçao no banco
               transportadora.Bairro = transportadora.Bairro.ToUpper();
               transportadora.Cidade =transportadora.Cidade.ToUpper();
               transportadora.Endereco =transportadora.Endereco.ToUpper();
                transportadora.Nome= transportadora.Nome.ToUpper();
               transportadora.UF = transportadora.UF.ToString();
               transportadora.CNPJ = transportadora.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
               transportadora.IE =transportadora.IE.Replace(".", "").Replace("-", "");
                bool retcnpj = Funcoes.ValidarCnpj(transportadora.CNPJ);
                bool retie = Funcoes.Validar_IE_CPF_CNPJ(transportadora.IE, ref msg);
                if (retcnpj == true && retie == true)
                {
                    var jaexiste = _transportadoraApp.GetAll().Where(c => c.CNPJ.Equals(transportadora.CNPJ) || c.IE.Equals(transportadora.IE));
                    if (jaexiste.Count() > 0)
                        @ViewBag.Mensagem = "Já existe esta Transportadora cadastrada com CNPJ e IE";
                    if (ModelState.IsValid)
                    {
                        var transportadoraDomain = Mapper.Map<TransportadoraViewModel, Transportadora>(transportadora);
                        _transportadoraApp.Add(transportadoraDomain);

                        return RedirectToAction("Index");
                    }
                }
                @ViewBag.Mensagem = "CNPJ Inválido!/n"+msg;
                return View(transportadora);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
           
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var transportadora = _transportadoraApp.GetById(id);
                var transportadoraViewModel = Mapper.Map<Transportadora, TransportadoraViewModel>(transportadora);

                return View(transportadoraViewModel);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
           
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransportadoraViewModel transportadora)
        {
            try
            {
                string msg = string.Empty;
                //variaveis iniciadas sempre para maiuscula para padronizaçao no banco
                transportadora.Bairro = transportadora.Bairro.ToUpper();
                transportadora.Cidade = transportadora.Cidade.ToUpper();
                transportadora.Endereco = transportadora.Endereco.ToUpper();
                transportadora.Nome = transportadora.Nome.ToUpper();
                transportadora.UF = transportadora.UF.ToString();
                transportadora.CNPJ = transportadora.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
                transportadora.IE = transportadora.IE.Replace(".", "").Replace("-", "");
                bool retcnpj = Funcoes.ValidarCnpj(transportadora.CNPJ);
                bool retie = Funcoes.Validar_IE_CPF_CNPJ(transportadora.IE, ref msg);
                if (retcnpj == true && retie == true)
                {
                  
                    if (ModelState.IsValid)
                    {
                        var transportadoraDomain = Mapper.Map<TransportadoraViewModel, Transportadora>(transportadora);
                        _transportadoraApp.Update(transportadoraDomain);

                        return RedirectToAction("Index");
                    }

                    

                }
                @ViewBag.Mensagem = "CNPJ Inválido!/n" + msg;
                return View(transportadora);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var transportadora = _transportadoraApp.GetById(id);
                var transportadoraViewModel = Mapper.Map<Transportadora, TransportadoraViewModel>(transportadora);

                return View(transportadoraViewModel);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var transportadora = _transportadoraApp.GetById(id);
                _transportadoraApp.Remove(transportadora);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
           
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _transportadoraApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
