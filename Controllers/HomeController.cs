using SiteGugu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;

namespace SiteGugu.Controllers
{
    public class HomeController : Controller
    {
        //Conexao com o banco
        private bdagrotopsEntities1 bd = new bdagrotopsEntities1();

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
                @ViewBag.Menssage = "login invalido";
                return View("login");

            }
            else
            {
                if (var.tipopessoa == "p")
                {
                    return View("homeProdutor", bd.Produto.ToList());
                }
                if ( var.tipopessoa == "f")
                {
                    return View("homeCliente", bd.Produto.ToList());
                }
                if (var.tipopessoa == "c")
                {
                    return View("homeCoop");
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


        //Cadastrar Pessoas Fisicas Post
        [HttpGet]
        public ActionResult cadastrarFisica()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult cadastrarFisica(string nome, int telefone, string email, string senha, long cpf, DateTime datanasc, string sexo)
        {

            Pessoa p = new Pessoa();
            p.nome = nome;
            p.telefone = telefone;
            p.email = email;
            p.senha = senha;
            p.tipopessoa = "f";

            bd.Pessoa.Add(p);

            PessoaFisica pf = new PessoaFisica();
            pf.cpf = cpf;
            pf.datanasc = (DateTime)datanasc;
            pf.sexo = sexo;

            bd.PessoaFisica.Add(pf);
            bd.SaveChanges();


            return View("login");
        }

        //Cadastrar Produtor Post
        [HttpGet]
        public ActionResult cadastrarProdutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadastrarProdutor(string nome, int telefone, string email, string senha, long cpf, DateTime datanasc, string sexo, int carteiraprod)
        {

            Pessoa p = new Pessoa();
            p.nome = nome;
            p.telefone = telefone;
            p.email = email;
            p.senha = senha;
            p.tipopessoa = "p";

            bd.Pessoa.Add(p);

            PessoaFisica pf = new PessoaFisica();
            pf.cpf = cpf;
            pf.datanasc = (DateTime)datanasc;
            pf.sexo = sexo;

            bd.PessoaFisica.Add(pf);

            Produtor prod = new Produtor();
            prod.carteiraprod = carteiraprod;

            bd.Produtor.Add(prod);

            bd.SaveChanges();


            return View("login");
        }


        //Cadastrar Coop Post
        [HttpGet]
        public ActionResult cadastrarCoop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadastrarCoop(string nomecoop, int telefone, string email, long cnpjcoop, string cidade, string estado, string regiao)
        {

            Cooperativa coop = new Cooperativa();
            coop.nomecoop = nomecoop;
            coop.telefone = telefone;
            coop.email = email;
            coop.cnpjcoop = cnpjcoop;
            coop.cidade = cidade;
            coop.estado = estado;
            coop.regiao = regiao;

            bd.Cooperativa.Add(coop);

            bd.SaveChanges();

            return View("login");
        }

        //Cadastrar pessoa juridica
        [HttpGet]
        public ActionResult cadastrarJuridica()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cadastrarJuridica(string nome, string nomefant, int telefone, string email, string senha, long cnpj)
        {
            Pessoa p = new Pessoa();
            p.nome = nome;
            p.telefone = telefone;
            p.email = email;
            p.senha = senha;
            p.tipopessoa = "j";

            bd.Pessoa.Add(p);

            PessoaJuridica pj = new PessoaJuridica();
            pj.cnpj = cnpj;
            pj.nomefant = nomefant;

            bd.PessoaJuridica.Add(pj);

            bd.SaveChanges();

            return View("login");
        }

        //pagina produtor

        [HttpGet]
        public ActionResult homeProdutor()
        {
            var estoque = from e in bd.Estoque select e;
            ViewBag.Estoque = estoque;
            var produto = from p in bd.Produto select p;
            ViewBag.Produto = produto;

            return View(bd.Estoque.ToList());
            
        }

        [HttpGet]
        public ActionResult adicionarProduto()
        {
            return View();
        }
        //pagina add produto
        [HttpPost]
        public ActionResult adicionarProduto(string descproduto, int quantestoque, decimal valorentrada, decimal valorsaida)
        {

            Produto p = new Produto();
            p.descproduto = descproduto;

            bd.Produto.Add(p);

            Estoque e = new Estoque();
            e.quantestoque = quantestoque;

            bd.Estoque.Add(e);

            ValorUnitario vu = new ValorUnitario();
            
            DateTime datavalorunit = DateTime.Now;
            
            vu.datavalorunit = (DateTime)datavalorunit;
            vu.valorentrada =  valorentrada;
            vu.valorsaida = valorsaida;
            vu.idcooperativa = 1;

            bd.ValorUnitario.Add(vu);

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

            Estoque e = new Estoque();
            prod.descproduto = descricao;
            
            bd.SaveChanges();

            return View("homeProdutor", bd.Estoque.ToList());
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

        public ActionResult homeCoop()
        {
            return View(bd.ValorUnitario.ToList());
        }
    }
}