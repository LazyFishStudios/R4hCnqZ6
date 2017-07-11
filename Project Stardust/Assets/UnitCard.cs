using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public abstract class UnitCard : Card
  {
    public int Fuel { get; protected set; }
    public int Attack { get; protected set; }
    public int Defence { get; protected set; }
    public string Description { get; protected set; }

    public UnitCard(string cardName)
    {
      this.cardName = cardName;
      SetupDescription(this.cardName);
    }

    private void SetupDescription(string cardNamep)
    {
      UnitCardDescription ucd = LoadCardDescitpion<UnitCardDescription>();
      Cost = ucd.Cost;
      Attack = ucd.Attack;
      Defence = ucd.Defence;
      Fuel = ucd.Fuel;
      Description = ucd.Description;
    }
  }
}