namespace PokerConsoleApp.Models
{
    public class ShowDownDto
    {
        public string Name { get; set; }
        public string Hand { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(Hand)) return false;
            var handCount = Hand.Split(',');
            if (handCount.Length != 5) return false;
            return true;
        }
    }
}
