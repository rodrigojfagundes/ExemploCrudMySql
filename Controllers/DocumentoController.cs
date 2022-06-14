using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ExemploCrudMySql.Models;
using ExemploCrudMySql.Repository;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class DocumentoController : Controller
    {
        IHostingEnvironment _appEnvironment;

        public DocumentoController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Lista()
        {
            DocumentoBanco documentoBanco = new DocumentoBanco();
            List<Documento> Lista = documentoBanco.Listar();
            return View(Lista);
        }
        public IActionResult Cadastro()
       {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Documento documento)
        {
            DocumentoBanco documentoBanco = new DocumentoBanco();
            //salvar o arquivo.
            //verifica se existem arquivos 
            if (documento.file == null || documento.file.Length == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }
            string nomeArquivo = "Usuario_arquivo_" + DateTime.Now.Millisecond.ToString();

            if (documento.file.FileName.Contains(".pdf"))
                nomeArquivo += ".pdf";
            else if (documento.file.FileName.Contains(".doc"))
                nomeArquivo += ".doc";
            else if (documento.file.FileName.Contains(".xls"))
                nomeArquivo += ".xls";
            else if (documento.file.FileName.Contains(".docx"))
                nomeArquivo += ".docx";
            else if (documento.file.FileName.Contains(".xlsx"))
                nomeArquivo += ".xlsx";
            else{
                ViewBag.Mensagem = "Ops! Erro no cadastro";
                return View();
            }
            string caminho_WebRoot = _appEnvironment.WebRootPath;

            string caminhoDestinoArquivo = caminho_WebRoot + "\\Arquivos\\Arquivos_Usuario\\Recebidos\\";
           
            string caminhoDestinoArquivoOriginal = Path.Combine($"{caminhoDestinoArquivo}\\{nomeArquivo}");
            documento.Arquivo = ($"localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/{nomeArquivo}");

            bool exists = System.IO.Directory.Exists(caminhoDestinoArquivo);
            if (!exists)
                System.IO.Directory.CreateDirectory(caminhoDestinoArquivo);

            using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
            {
               documento.file.CopyTo(stream);
            }
            documentoBanco.Inserir(documento);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
    }
}
