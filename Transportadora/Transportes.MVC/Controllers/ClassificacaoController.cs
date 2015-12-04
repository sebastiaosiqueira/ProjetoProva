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

namespace Transportes.MVC.Controllers
{
    public class ClassificacaoController : Controller
    {
        private readonly IClassificacaoAppService _classificacaoApp;
        private readonly IUsuarioAppService _usuarioApp;
        private readonly ITransportadoraAppService _transportadoraApp;

        public ClassificacaoController(IClassificacaoAppService classificacaoApp, IUsuarioAppService usuarioApp, ITransportadoraAppService transportadoraApp)
        {
            _classificacaoApp = classificacaoApp;
            _usuarioApp = usuarioApp;
            _transportadoraApp = transportadoraApp;

        }


        // GET: /Classificacao/
        public ActionResult Index()
        {
            try
            {
                if (Session["Usuario"] == null)
                    return View("Logar");
                else
                {
                    var logado = (UsuarioViewModel)Session["Usuario"];
                    var classificacaoViewModel = Mapper.Map<IEnumerable<Classificacao>, IEnumerable<ClassificacaoViewModel>>(_classificacaoApp.GetAll());
                    return View(classificacaoViewModel.Where(c=> c.UsuarioId.Equals(logado.UsuarioId)));
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        // GET: /Classificacao/Details/5
        public ActionResult Details(int? id)
        {
            try
            {

                if (Session["Usuario"] == null)
                    return View("Logar");
                else
                {
                    var classificacao = _classificacaoApp.GetById(Convert.ToInt32(id));
                    var classificacaoViewModel = Mapper.Map<Classificacao, ClassificacaoViewModel>(classificacao);

                    return View(classificacaoViewModel);
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        // GET: /Classificacao/Create
        public ActionResult Create()
        {
            try
            {
                var logado = (UsuarioViewModel)Session["Usuario"];

                ViewBag.TransportadoraId = new SelectList(_transportadoraApp.GetAll(), "TransportadoraId", "Nome");
                var lista = _usuarioApp.GetAll().Where(u => u.UsuarioId.Equals(logado.UsuarioId));
                ViewBag.UsuarioId = new SelectList(lista, "UsuarioId", "Nome");
                
                return View();
            }
            catch (Exception)
            {

                return HttpNotFound();
            }


        }

        // POST: /Classificacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassificacaoViewModel classificacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var classificacaoDomain = Mapper.Map<ClassificacaoViewModel, Classificacao>(classificacao);
                    _classificacaoApp.Add(classificacaoDomain);

                    return RedirectToAction("Index");
                }
                return View(classificacao);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        // GET: /Classificacao/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var classificacao = _classificacaoApp.GetById(Convert.ToInt32(id));
                var classificacaoViewModel = Mapper.Map<Classificacao, ClassificacaoViewModel>(classificacao);
          

                ViewBag.TransportadoraId = new SelectList(_transportadoraApp.GetAll(), "TransportadoraId", "Nome");
                var logado = (UsuarioViewModel)Session["Usuario"];
                var lista = _usuarioApp.GetAll().Where(u => u.UsuarioId.Equals(logado.UsuarioId));
                ViewBag.UsuarioId = new SelectList(lista, "UsuarioId", "Nome");
                return View(classificacaoViewModel);

            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        // POST: /Classificacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassificacaoViewModel classificacaoviewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var classificacaoDomain = Mapper.Map<ClassificacaoViewModel, Classificacao>(classificacaoviewmodel);
                    _classificacaoApp.Update(classificacaoDomain);

                    return RedirectToAction("Index");
                }
                var logado = (UsuarioViewModel)Session["Usuario"];
                var lista = _usuarioApp.GetAll().Where(u => u.UsuarioId.Equals(logado.UsuarioId));
                ViewBag.UsuarioId = new SelectList(lista, "UsuarioId", "Nome",classificacaoviewmodel.UsuarioId);

                ViewBag.TransportadoraId = new SelectList(_transportadoraApp.GetAll(), "TransportadoraId", "Nome", classificacaoviewmodel.TransportadoraId);
                return View(classificacaoviewmodel);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: /Classificacao/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var classificacao = _classificacaoApp.GetById(Convert.ToInt32(id));
                var classificacaoViewModel = Mapper.Map<Classificacao, ClassificacaoViewModel>(classificacao);

                return View(classificacaoViewModel);

            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        // POST: /Classificacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var classificacao = _classificacaoApp.GetById(id);
                _classificacaoApp.Remove(classificacao);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }


        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(UsuarioViewModel usuario)
        {
            try
            {
                var logadolista = _usuarioApp.GetAll().Where(u => u.CPF == usuario.CPF && u.Email == usuario.Email);
                foreach (var item in logadolista)
                {
                    usuario.UsuarioId = item.UsuarioId;
                    usuario.Nome = item.Nome;
                    usuario.CPF = item.CPF;
                    
                }
               Session["Usuario"] = usuario;
               if (Session["Usuario"] != null)
                   return RedirectToAction("Index");
               else
                   Session["Usuario"] = null;
               return RedirectToAction("Logar");
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
                _classificacaoApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
