using System;
using ATV02.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ATV02.Controllers
{
    public class Pacotes_TuristicosController : Controller
    {

        public IActionResult Lista()
        {

            Pacotes_TuristicosRepository pr = new Pacotes_TuristicosRepository();
            List<Pacotes_Turisticos> Listagem = pr.listar();
            return View(Listagem);

        }
        public IActionResult Excluir(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUser")==null){
                return Redirect("/Usuario/Login");
            }


            Pacotes_TuristicosRepository pr = new Pacotes_TuristicosRepository();
            Pacotes_Turisticos pt = pr.searchId(Id);
            pr.excluir(pt);
            return Redirect("Lista");
        }

        public IActionResult CadastroPacotes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroPacotes(Pacotes_Turisticos package)
        {
            Pacotes_TuristicosRepository pr = new Pacotes_TuristicosRepository();
            pr.inserir(package);
            ViewBag.Mensagem = "Pacote cadastrado com sucesso";
            return View("CadastroPacotes");
        }

        public IActionResult Editar(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUser")==null){
                return RedirectToAction("Login" , "Usuario");
            }

            Pacotes_TuristicosRepository pr = new Pacotes_TuristicosRepository();
            Pacotes_Turisticos pt = pr.searchId(Id);
            return View(pt);
        }

        [HttpPost]
        public IActionResult Editar(Pacotes_Turisticos packageForm)
        {
            Pacotes_TuristicosRepository pr = new Pacotes_TuristicosRepository();
            pr.atualizar(packageForm);
            return Redirect("Lista");
        }

    }
}