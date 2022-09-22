using SiteGugu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteGugu.Controllers
{
    public class HomeController : Controller
    {
        //Conexao com o banco
        private bdagrotopsEntities bd = new bdagrotopsEntities();

        public ActionResult login()
        {
            return View();
        }

        /*Pagina inicial listar pessoa e veiculos Get:
        public ActionResult caixa()
        {
            //return View(bd.mesa.ToList());
        }

        //Cadastrar Pessoas /View Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
         */

        //Cadastrar Pessoas Post
        [HttpPost]
        public ActionResult login(string nome, int telefone, string email, string senha, string tipoPessoa)
        {

            Pessoa p = new Pessoa();
            p.nome = nome;
            p.telefone = Convert.ToInt32(telefone);
            p.email = email;
            p.senha = senha;
            p.tipopessoa = tipoPessoa;

            bd.Pessoa.Add(p);


            return View("homeProdutor");
        }

        [HttpGet]
        public ActionResult homeProdutor()
        {
            return View(bd.Produto.ToList());
        }

        [HttpGet]
        public ActionResult adicionarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adicionarProduto(string descproduto)
        {
            Produto p = new Produto();
            p.descproduto = descproduto;

            bd.Produto.Add(p);
            bd.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult entrarCoop()
        {
            return View(bd.Cooperativa.ToList());
        }

        [HttpGet]
        public ActionResult editPerfil()
        {
            return View(bd.Pessoa.ToList());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Produto prod = bd.Produto.ToList().Find(x => x.idproduto == id);

            return View(prod);
        }

        [HttpPost]
        public ActionResult Editar(int id, string descricao, decimal valor)
        {
            Produto prod = bd.Produto.ToList().Find(x => x.idproduto == id);
            prod.descricaoproduto = descricao;
            prod.valorunitario = valor;

            bd.SaveChanges();

            return View("Index", bd.Produto.ToList());
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Produto prod = bd.Produto.ToList().Find(x => x.idproduto == id);

            bd.Produto.Remove(prod);
            bd.SaveChanges();

            return View("Index", bd.Produto.ToList());

        }
    }
}