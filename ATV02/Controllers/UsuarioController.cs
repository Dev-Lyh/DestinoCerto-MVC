using System;
using ATV02.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ATV02.Controllers
{
    public class UsuarioController : Controller{
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.inserir(user);
            ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
            return Redirect("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario userForm)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario userSession = ur.Login(userForm);
            if(userSession != null)
            {
                ViewBag.Mensagem = "Você está logado";
                HttpContext.Session.SetInt32("IdUser", userSession.Id);
                HttpContext.Session.SetString("NomeUser", userSession.Nome);
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.MensagemFalha = "Falha no Login";
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}