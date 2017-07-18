using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class BattleCruiserCard : UnitCard
  {
    // parameter passed to base must match card description ScriptableObject in Resourced 
    public BattleCruiserCard() : base("BattleCruiser")
    {
   
    }

    public override void OnCardPlayed()
    {
    }
  }
}