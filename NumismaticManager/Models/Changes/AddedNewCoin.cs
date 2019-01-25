using NumismaticManager.Logics;

namespace NumismaticManager.Models.Changes
{
    class AddedNewCoin : ChangeBase
    {
        public AddedNewCoin(int coinId) : base(coinId) { }

        public override void Undo()
        {
            Database.RemoveCoin(coinId);
        }
    }
}
