
using Microsoft.AspNetCore.Mvc;

namespace Autenticacaoefcookie.Controllers
{
    [Authorize(Roles="Financeiro")]
    public class FinanceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}