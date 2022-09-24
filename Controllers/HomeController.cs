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

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string email, string senha)
        {
            Pessoa var = bd.Pessoa.ToList().Find(x => x.email == email);
            

            if(var == null) 
            {
                @ViewBag.Title = "login invalido";
                return View("login");

            }
            else
            {
                Session["sessaopessoa"] = "logado";
                if (var.tipopessoa == "f")
                {
                    return View("homeProdutor", bd.Produto.ToList());
                }
                else
                {
                    return View("login");
                }
            }
            
           
        }

        public ActionResult cadastro()
        {
            return View();
        }


        //Cadastrar Pessoas Post
        [HttpGet]
        public ActionResult cadastrarFisica()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult cadastrarFisica(string nome, int telefone, string email, string senha, 
            string tipoPessoa, long cpf, DateTime datanasc, string sexo)
        {

            Pessoa p = new Pessoa();
            p.nome = nome;
            p.telefone = Convert.ToInt32(telefone);
            p.email = email;
            p.senha = senha;
            p.tipopessoa = tipoPessoa;

            p.tipopessoa = "f";

            bd.Pessoa.Add(p);

            PessoaFisica pf = new PessoaFisica();
            pf.cpf = cpf;
            pf.datanasc = (DateTime)datanasc;
            pf.sexo = sexo;

            bd.PessoaFisica.Add(pf);
            bd.SaveChanges();


            return View("homeProdutor", bd.Produto.ToList());
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

        //metod editar

        [HttpGet]
        public ActionResult editProduto(int id)
        {
            Produto prod = bd.Produto.ToList().Find(x => x.idproduto == id);

            return View(prod);
        }

        [HttpPost]
        public ActionResult editProduto(int id, string descricao)
        {
            Produto prod = bd.Produto.ToList().Find(x => x.idproduto == id);
            prod.descproduto = descricao;
            //prod.Estoque = valor;

            bd.SaveChanges();

            return View("homeProdutor", bd.Produto.ToList());
        }

        //excluir prod

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