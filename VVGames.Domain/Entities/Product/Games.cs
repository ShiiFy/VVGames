namespace VVGames.Domain.Entities.Product
{
    public class Games
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public GameGenre Genres { get; set; }
        public int Price { get; set; }
    }
}
