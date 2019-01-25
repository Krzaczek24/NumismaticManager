namespace NumismaticManager.Models.UndoAbleChanges
{
    class ChangedCoinAmount : ChangeBase
    {
        private int changedFrom;

        public ChangedCoinAmount(int coinId, int changedFrom) : base(coinId)
        {
            this.changedFrom = changedFrom;
        }

        public override void Undo()
        {
            //tutaj funkcja do bazy cofająca zmianę
        }
    }
}
