﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public abstract class InstantCard : Card
  {
    public InstantCard(string cardName)
    {
      this.cardName = cardName;
      Type = CardType.INSTANT;
      SetupDescription(this.cardName);
    }

    public override void OnCardPlayed()
    {
      Debug.Log("Heal planet +1");
    }

    protected override void SetupDescription(string cardDescriptionName)
    {
      InstantCardDescription desc = LoadCardDescitpion<InstantCardDescription>();
      Cost = desc.Cost;
      Description = desc.Description;
    }
  }
}