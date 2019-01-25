using NumismaticManager.Logics;

namespace NumismaticManager.Models.Changes
{
    class ChangedCoinAmount : ChangeBase
    {
        private readonly int changedFrom;

        public ChangedCoinAmount(int coinId, int changedFrom) : base(coinId)
        {
            this.changedFrom = changedFrom;
        }

        public override void Undo()
        {
            Database.SetCoinPreviousAmount(coinId, changedFrom);
        }
    }
}
