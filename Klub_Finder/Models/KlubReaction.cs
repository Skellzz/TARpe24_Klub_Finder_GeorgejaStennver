namespace Klub_Finder.Models
{
    public class KlubReaction
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int KlubId { get; set; }

        public string ReactionType { get; set; } // Like, Dislike, SuperLike
    }
}