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
using Transportes.Domain.Entities;
using AutoMapper;
using Transportes.Service.Utility;
using Transportes.Service.Utility.Util;
using Transportes.MVC.Helper;

namespace Transportes.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;
        private readonly Mensagem _mensagem;
        public UsuarioController(IUsuarioAppService usuarioService)
        {
            _usuarioApp = usuarioService;
      

        }

        // GET: Clientes
        public ActionResult Index()
        {
            try
            {
                
                var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioApp.GetAll());
                return View(usuarioViewModel);
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
                var usuario = _usuarioApp.GetById(id);
                var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

                return View(usuarioViewModel);
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
        public ActionResult Create(UsuarioViewModel usuario)
        {
           
            try
            {
               string msg=string.Empty;
                //alteração para as variaveis sempre ficarem com letras maiusculas para padronização
               usuario.Bairro = usuario.Bairro.ToUpper();
                usuario.Cidade = usuario.Cidade.ToUpper();
                usuario.Cidade =usuario.Endereco.ToUpper();
                usuario.Cidade =usuario.Nome.ToUpper();
                usuario.Cidade =usuario.UF.ToUpper();
               usuario.CPF =  usuario.CPF.Replace(".", "").Replace("-", "");
             bool ret = Funcoes.ValidarCpf(usuario.CPF);
             if (ret == true) {
                 var jaexiste = _usuarioApp.GetAll().Where(u => u.CPF.Equals(usuario.CPF));
                 if(jaexiste.Count()>0)
                 {
                     @ViewBag.Mensagem = "Já existe esse usuario cadastrado com este CPF!";
                     return View(usuario);

                 }
                if (ModelState.IsValid)
                {
                    var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                    _usuarioApp.Add(usuarioDomain);
                    @ViewBag.Mensagem = "Usuario incluido com sucesso!";
                    return RedirectToAction("Index");
                }
             }

             @ViewBag.Mensagem = "CPF Inválido!";
                return View(usuario);
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
                var usuario = _usuarioApp.GetById(id);
                var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

                return View(usuarioViewModel);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
           
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                ///alteração para as variaveis sempre ficarem com letras maiusculas para padronização
                usuario.Bairro= usuario.Bairro.ToUpper();
               usuario.Cidade = usuario.Cidade.ToUpper();
               usuario.Endereco = usuario.Endereco.ToUpper();
               usuario.Nome =usuario.Nome.ToUpper();
               usuario.UF =usuario.UF.ToUpper();
               usuario.CPF =usuario.CPF.Replace(".", "").Replace("-", "");
                 bool ret = Funcoes.ValidarCpf(usuario.CPF);
                 if (ret == true)
                 {
                    
                   
                         var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                         _usuarioApp.Update(usuarioDomain);
                         @ViewBag.Mensagem = "Usuario incluido com sucesso!";
                         return RedirectToAction("Index");
                     }
                 }
                 @ViewBag.Mensagem = "CPF Inválido!";
                return View(usuario);

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
                var usuario = _usuarioApp.GetById(id);
                var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

                return View(usuarioViewModel);
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
                var usuario = _usuarioApp.GetById(id);
                _usuarioApp.Remove(usuario);

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
                _usuarioApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
