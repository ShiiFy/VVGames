﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.Core
{
    public class ProductApi
    {
        public void AddGameAction(DBGames game)
        {
            using (var db = new GameContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
        }
        public List<DBGames> GetAllGamesAction()
        {
            using (var db = new GameContext())
            {
                return db.Games.ToList();
            }
        }
        public DBGames GetGameByIdAction(int id)
        {
            using (var db = new GameContext())
            {
                return db.Games.FirstOrDefault(g => g.Id == id);
            }
        }
        public void SaveGameChangesAction(DBGames game)
        {
            using (var db = new GameContext())
            {
                try
                {
                    db.Entry(game).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = $"Свойство: {validationError.PropertyName}, Ошибка: {validationError.ErrorMessage}";
                            System.Diagnostics.Debug.WriteLine(message);
                        }
                    }

                    throw; // пробросить дальше, чтобы ты увидел оригинальное исключение
                }
            }
        }
        public bool ArticulExistsAction(string articul)
        {
            using (var db = new GameContext())
            {
                return db.Games.Any(g => g.Articul == articul);
            }
        }
        public void DeleteGameByIdAction(int id)
        {
            using (var db = new GameContext())
            {
                var game = db.Games.FirstOrDefault(g => g.Id == id);
                if (game != null)
                {
                    db.Games.Remove(game);
                    db.SaveChanges();
                }
            }
        }
        public List<DBGames> GetGamesPagedAction(int page, int pageSize)
        {
            using (var db = new GameContext())
            {
                return db.Games
                         .OrderBy(g => g.Id)
                         .Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();
            }
        }

        public List<DBGames> SearchGamesAction(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllGamesAction();   // показать всё при пустом запросе

            keyword = keyword.Trim().ToLower();

            using (var db = new GameContext())
            {
                // 1️⃣  Часть, которую EF умеет перевести в SQL
                var preliminary = db.Games
                                    .Where(g => g.Name.ToLower().Contains(keyword)
                                             || g.ShortDescription.ToLower().Contains(keyword))
                                    .ToList();               // ⚠️ выполняем запрос здесь!

                // 2️⃣  Дофильтровываем Genres уже в CLR
                return preliminary
                       .Where(g => g.Genres.ToString().ToLower().Contains(keyword)
                                || g.Name.ToLower().Contains(keyword)
                                || g.ShortDescription.ToLower().Contains(keyword))
                       .ToList();
            }
        }


        public int GetTotalGameCountAction()
        {
            using (var db = new GameContext())
            {
                return db.Games.Count();
            }
        }

    }
}
