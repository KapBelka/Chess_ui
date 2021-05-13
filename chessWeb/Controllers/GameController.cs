using chessWeb.Chess;
using User = chessWeb.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chess;

namespace chessWeb.Controllers
{
    public class GameController : Controller
    {
        DataContext db;
        public GameController(DataContext context)
        {
            db = context;
            Game.db = context;
        }
        [Authorize]
        public IActionResult Start()
        {
            User user = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
            Game.AddUser(user);
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Play(int game_id)
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult End(int game_id)
        {
            return View();
        }
        [Authorize]
        [Route("api/game/[action]")]
        [HttpGet]
        public IActionResult GetEvent()
        {
            return Json(Game.GetEvent(User.Identity.Name));
        }
        [Authorize]
        [Route("api/game/[action]")]
        [HttpGet]
        public IActionResult GetGameData(int game_id)
        {
            Game g = Game.GetGameById(game_id);
            if (g != null)
            {
                List<JsonModel> data = new List<JsonModel>();
                g.GetGameData(ref data);
                return Json(data);
            }
            return NotFound();
        }
        [Authorize]
        [Route("api/game/[action]")]
        [HttpPost]
        public IActionResult DoMove(int game_id, int y_from, int x_from, int y_to, int x_to, int figure_type)
        {
            Game g = Game.GetGameById(game_id);
            if (g != null)
            {
                return Json(g.Move(User.Identity.Name, y_from, x_from, y_to, x_to, (Figures)figure_type));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [Route("api/game/[action]")]
        [HttpGet]
        public IActionResult StartGames()
        {
            Game.StartChessGames();
            return Ok();
        }
    }
}
