using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Auth.Controllers;

[Authorize(Roles = "admin")]
public class FornecedorController : Controller
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public FornecedorController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var fornecedores = _db.Fornecedores
            .Include(p => p.Categoria)
            .AsNoTracking()
            .OrderBy(p => p.Nome)
            .ToList();
        return View(fornecedores);
    }

    private void CarregarCategorias(int? idCategoria = null)
    {
        var categorias = _db.Categorias.OrderBy(c => c.Nome).ToList();
        var categoriasSelectList = new SelectList(
            categorias, "Id", "Nome", idCategoria);
        ViewBag.Categorias = categoriasSelectList;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Cadastrar()
    {
        CarregarCategorias();
        var fornecedor = new FornecedorModel();
        return View(fornecedor);
    }

    [AllowAnonymous]
    [Authorize]
    [HttpPost]
    public IActionResult Cadastrar(FornecedorModel fornecedor)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(fornecedor.IdCategoria);
            return View(fornecedor);
        }
        _db.Fornecedores.Add(fornecedor);
        if (_db.SaveChanges() > 0)
        {
            var caminhoImagem = $"{_env.WebRootPath}//img//fornecedor//{fornecedor.Id.ToString("D6")}.jpg";
            SalvarUploadImagemAsync(caminhoImagem, fornecedor.ArquivoImagem).Wait();
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Alterar(int id)
    {
        var fornecedor = _db.Fornecedores.Find(id);
        if (fornecedor is null)
        {
            return RedirectToAction("Index");
        }
        CarregarCategorias(fornecedor.IdCategoria);
        return View(fornecedor);
    }

    [HttpPost]
    public IActionResult Alterar(int id, FornecedorModel fornecedor)
    {
        var fornecedorOriginal = _db.Fornecedores.Find(id);
        if (fornecedorOriginal is null)
        {
            return RedirectToAction("Index");
        }

        CarregarCategorias(fornecedor.IdCategoria);
        fornecedorOriginal.Nome = fornecedor.Nome;
        fornecedorOriginal.Email = fornecedor.Email;
        fornecedorOriginal.Telefone = fornecedor.Telefone;
        fornecedorOriginal.IdCategoria = fornecedor.IdCategoria;
        fornecedorOriginal.Cidade = fornecedor.Cidade;
        fornecedorOriginal.UF = fornecedor.UF;
        fornecedorOriginal.aPartir = fornecedor.aPartir;
        fornecedorOriginal.ValorPessoa = fornecedor.ValorPessoa;
        fornecedorOriginal.Caracteristicas = fornecedor.Caracteristicas;
        fornecedorOriginal.IsPremium = fornecedor.IsPremium;
        _db.SaveChanges();
        if (fornecedor.ArquivoImagem is not null)
        {
            var caminhoImagem = $"{_env.WebRootPath}//img//fornecedor//{fornecedor.Id.ToString("D6")}.jpg";
            SalvarUploadImagemAsync(caminhoImagem, fornecedor.ArquivoImagem).Wait();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        var fornecedor = _db.Fornecedores.Find(id);
        if (fornecedor is null)
        {
            return RedirectToAction("Index");
        }
        return View(fornecedor);
    }

    [HttpPost]
    public IActionResult ProcessarExclusao(int id)
    {
        var fornecedorOriginal = _db.Fornecedores.Find(id);
        if (fornecedorOriginal is null)
        {
            return RedirectToAction("Index");
        }
        _db.Fornecedores.Remove(fornecedorOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public async Task<bool> SalvarUploadImagemAsync(
       string caminhoArquivoImagem, IFormFile imagem,
       bool salvarQuadrada = true)
    {
        if (imagem is null)
        {
            return false;
        }
        var ms = new MemoryStream();
        await imagem.CopyToAsync(ms);
        ms.Position = 0;
        var img = await Image.LoadAsync(ms);

        if (salvarQuadrada)
        {
            var tamanho = img.Size();
            var ladoMenor = (tamanho.Height < tamanho.Width) ? tamanho.Height : tamanho.Width;
            img.Mutate(i =>
                i.Resize(new ResizeOptions()
                {
                    Size = new Size(ladoMenor, ladoMenor),
                    Mode = ResizeMode.Crop
                })
            );
        }

        await img.SaveAsJpegAsync(caminhoArquivoImagem);
        return true;
    }
}