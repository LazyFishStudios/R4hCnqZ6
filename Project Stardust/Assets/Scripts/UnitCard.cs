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

  //  [Inject]
  //  CardsModel _cardsModel;

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
      Thumbnail = desc.Thumbnail;
    }

    public void UpdateFuel(int value)
    {
      Fuel += value;
      Debug.Log("changed fuel for: " + CardName);
      
      if (OnCardValuesUpdated != null) OnCardValuesUpdated();
    }

    public void UpdateDefence(int value)
    {
      Defence += value;
      Debug.Log("changed defence for " + CardName+" by "+value);
      if (OnCardValuesUpdated != null) OnCardValuesUpdated();
    }

    // Here all events will be added
    // OnTurnStarted, finished, etc... This can be overwritten in child classes.

    public virtual void OnUnitAttacked()
    {
      UpdateFuel(-1);
    }

    public virtual void OnUnitHasBeenAttacked()
    {

    }
  }
}