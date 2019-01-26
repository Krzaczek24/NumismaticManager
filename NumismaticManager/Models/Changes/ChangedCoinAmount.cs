using NumismaticManager.Logics;

namespace NumismaticManager.Models.Changes
{
    class ChangedCoinAmount : ChangeBase
    {
        //private readonly int changedFrom;

        public int PreviousAmount { get; }
        public int TargetAmount { get; set; }

        public ChangedCoinAmount(int coinId, int changedFrom, int changedTo) : base(coinId)
        {
            PreviousAmount = changedFrom;
            TargetAmount = changedTo;
        }

        public override void Undo()
        {
            Database.SetCoinPreviousAmount(coinId, PreviousAmount);
        }
    }
}
