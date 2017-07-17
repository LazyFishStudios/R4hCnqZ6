using System;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public abstract class UnitCard : Card
  {
    public int Fuel { get; private set; }
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public GameObject Prefab { get; private set; }

    [Inject]
    CardsModel cm;

    public UnitCard(string cardName)
    {
      this.CardName = cardName;
      Type = CardType.UNIT;
      SetupDescription(this.CardName);
    }

    public event Action OnCardValuesUpdated;

    protected override void SetupDescription(string cardNamep)
    {
      UnitCardDescription desc = LoadCardDescitpion<UnitCardDescription>();
      Cost = desc.Cost;
      Attack = desc.Attack;
      Defence = desc.Defence;
      Fuel = desc.Fuel;
      Description = desc.Description;
      Prefab = desc.ModelPrefab;
    }

    public void UpdateFuel(int value)
    {
      Fuel += value;
      Debug.Log("dddd: "+cm.LastFieldInteraction.ReleasedCard.CardName);
      if (OnCardValuesUpdated != null) OnCardValuesUpdated();
    }
  }
}