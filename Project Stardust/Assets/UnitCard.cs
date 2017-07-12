namespace StarDust
{
  public abstract class UnitCard : Card
  {
    public int Fuel { get; protected set; }
    public int Attack { get; protected set; }
    public int Defence { get; protected set; }

    public UnitCard(string cardName)
    {
      this.cardName = cardName;
      Type = CardType.UNIT;
      SetupDescription(this.cardName);
    }

    protected override void SetupDescription(string cardNamep)
    {
      UnitCardDescription desc = LoadCardDescitpion<UnitCardDescription>();
      Cost = desc.Cost;
      Attack = desc.Attack;
      Defence = desc.Defence;
      Fuel = desc.Fuel;
      Description = desc.Description;
    }
  }
}