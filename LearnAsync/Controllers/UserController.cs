using Microsoft.AspNetCore.Mvc;

namespace LearnAsync.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            int x = Sum().Result;
            return View();
        }


        public async Task<IActionResult> GetUserAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            return View("GetUserAsync");
        }

        public async Task<IActionResult> ListUserAsync()
        {
            int sum = 0;
            await Task.Run(() => {

                for (int i = 0; i < 10; i++) { 
                
                sum+= i;
                }
            });
            return View();
        }

        private async Task<int> Sum()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i;
                await Task.Delay(100);
            }
            return sum;
        }

    }
}
