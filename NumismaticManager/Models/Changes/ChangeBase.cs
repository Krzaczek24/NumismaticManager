namespace NumismaticManager.Models.Changes
{
    abstract class ChangeBase : IUndoable
    {
        protected readonly int coinId;

        public ChangeBase(int coinId)
        {
            this.coinId = coinId;
        }

        public abstract void Undo();
    }
}
