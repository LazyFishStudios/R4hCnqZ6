using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public abstract class Card
  {
    public int Cost { get; protected set; }
    protected string cardName;
    
    public abstract void OnCardPlayed();
    
    protected T LoadCardDescitpion<T>() where T : CardDescription
    {
      Debug.Log("CardDescriptions/" + cardName);
      T desc = Resources.Load<T>("CardDescriptions/" + cardName);
      return desc;
    }
  }
}