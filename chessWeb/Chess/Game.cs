using chess;
using chessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chessWeb.Chess
{
    public class Game
    {
        public static DataContext db;
        public static List<Game> Games { get; set; } = new List<Game>();
        public static List<User> Enter_users { get; set; } = new List<User>();
        public static Dictionary<String, int> Events { get; set; } = new Dictionary<String, int>();
        public static int next_id { get; set; } = 1;
        private User white_player;
        private User black_player;
        private int id;
        private Board board = Board.CreateChessBoard();
        public static Game GetGameById(int id)
        {
            foreach (Game g in Games)
            {
                if (g.id == id)
                {
                    return g;
                }
            }
            return null;
        }
        public static void StartChessGames()
        {
            int max_i = Enter_users.Count()/2;
            for (int i = 0; i < max_i; i++)
            {
                User user_1 = Enter_users.First();
                Enter_users.Remove(user_1);
                User user_2 = Enter_users.First();
                Enter_users.Remove(user_2);
                Events.Add(user_1.Email, next_id);
                Events.Add(user_2.Email, next_id);
                Game.Games.Add(new Game(user_1, user_2));
            }
        }
        public static int GetEvent(string user)
        {
            if (Events.ContainsKey(user))
            {
                int gameevent = Events[user];
                Events.Remove(user);
                return gameevent;
            }
            return 0;
        }
        public Game(User wp, User bp)
        {
            white_player = wp;
            black_player = bp;
            id = next_id;
            next_id++;
        }
        public int Move(string user, int y_from, int x_from, int y_to, int x_to, Figures figure=Figures.NONE)
        {
            if (user == white_player.Email && board.GetColor() == Colors.WHITE)
            {
                if (Events.ContainsKey(black_player.Email)) Events.Remove(black_player.Email);
                Figure fig = board.GetFigure(y_from, x_from);
                if (fig != null)
                {
                    int code;
                    if (fig.GetType() == typeof(Pawn) && figure != Figures.NONE) code = ((Pawn)fig).Move(y_to, x_to, figure);
                    else code = fig.Move(y_to, x_to);
                    if (board.IsCheckMate())
                    {
                        EndGame(Colors.WHITE);
                    }
                    else Events.Add(black_player.Email, -1);
                    return code;
                }
                return 0;
            }
            else if (user == black_player.Email && board.GetColor() == Colors.BLACK)
            {
                if (Events.ContainsKey(white_player.Email)) Events.Remove(white_player.Email);
                Figure fig = board.GetFigure(y_from, x_from);
                if (fig != null)
                {
                    int code;
                    if (fig.GetType() == typeof(Pawn) && figure != Figures.NONE) code = ((Pawn)fig).Move(y_to, x_to, figure);
                    else code = fig.Move(y_to, x_to);
                    if (board.IsCheckMate())
                    {
                        Events.Add(white_player.Email, -2);
                        Events.Add(black_player.Email, -2);
                        EndGame(Colors.BLACK);
                    }
                    else Events.Add(white_player.Email, -1);
                    return code;
                }
                return 0;
            }
            return -2;
        }
        public void EndGame(Colors win)
        {
            Events.Add(black_player.Email, -2);
            Events.Add(white_player.Email, -2);
            Models.Game g1;
            Models.Game g2;
            if (win == Colors.WHITE)
            {
                g1 = new Models.Game() { PlayerId = white_player.Id, Date = DateTime.Now, OpponentPlayerId = black_player.Id, color = Colors.WHITE, Win = true };
                g2 = new Models.Game() { PlayerId = black_player.Id, Date = DateTime.Now, OpponentPlayerId = white_player.Id, color = Colors.BLACK, Win = false };
            }
            else
            {
                g1 = new Models.Game() { PlayerId = white_player.Id, Date = DateTime.Now, OpponentPlayerId = black_player.Id, color = Colors.WHITE, Win = false };
                g2 = new Models.Game() { PlayerId = black_player.Id, Date = DateTime.Now, OpponentPlayerId = white_player.Id, color = Colors.BLACK, Win = true };
            }
            db.Games.Add(g1);
            db.Games.Add(g2);
            db.SaveChanges();
            Games.Remove(this);
        }
        public void GetGameData(ref List<JsonModel> data)
        {
            board.GetFieldData(ref data);
        }
        public static void AddUser(User user)
        {
            if (!Enter_users.Contains(user)) Enter_users.Add(user);
        }
    }
}
