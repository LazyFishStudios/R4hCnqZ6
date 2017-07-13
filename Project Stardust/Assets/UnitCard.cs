﻿using UnityEngine;

namespace StarDust
{
  public abstract class UnitCard : Card
  {
    public int Fuel { get; private set; }
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public GameObject Prefab { get; private set; }

    public UnitCard(string cardName)
    {
      this.CardName = cardName;
      Type = CardType.UNIT;
      SetupDescription(this.CardName);
    }

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
  }
}