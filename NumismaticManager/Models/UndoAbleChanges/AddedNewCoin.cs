namespace NumismaticManager.Models.UndoAbleChanges
{
    class AddedNewCoin : ChangeBase
    {
        public AddedNewCoin(int coinId) : base(coinId) { }

        public override void Undo()
        {
            //tutaj funkcja do bazy cofająca dodanie nowej monetki
        }
    }
}
