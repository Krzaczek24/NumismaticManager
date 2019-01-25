namespace NumismaticManager.Models.UndoAbleChanges
{
    abstract class ChangeBase : IUndoable
    {
        private int coinId;

        public ChangeBase(int coinId)
        {
            this.coinId = coinId;
        }

        public abstract void Undo();
    }
}
