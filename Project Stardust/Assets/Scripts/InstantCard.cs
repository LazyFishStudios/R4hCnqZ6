using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public abstract class InstantCard : Card
  {
    public InstantCard(string cardName)
    {
      this.CardName = cardName;
      Type = CardType.INSTANT;
      SetupDescription(this.CardName);
    }

    public override void OnCardPlayed()
    {
     
    }

    protected override void SetupDescription(string cardDescriptionName)
    {
      InstantCardDescription desc = LoadCardDescitpion<InstantCardDescription>();
      Cost = desc.Cost;
      Description = desc.Description;
      Thumbnail = desc.Thumbnail;
    }
  }
}