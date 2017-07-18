using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public enum CardType
  {
    UNIT,
    INSTANT
  }

  public abstract class Card
  {
    public int Cost { get; protected set; }
    public string CardName { get; protected set; } // This name must match card description in Resources.
    public string Description { get; protected set; }

    public CardType Type { get; protected set;} // This is used by UI to find out which card UI to add
    public abstract void OnCardPlayed();
    
    protected T LoadCardDescitpion<T>() where T : CardDescription
    {
      // Debug.Log("CardDescriptions/" + CardName);
      T desc = Resources.Load<T>("CardDescriptions/" + CardName);
      return desc;
    }

    protected abstract void SetupDescription(string cardDescriptionName);
  }
}