using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class BattleCruiserCard : UnitCard
  {
    [Inject] // This is PROBABLY after ctors()
    PlayerModel _playerModel;

    // parameter passed to base must match card description ScriptableObject in Resourced 
    public BattleCruiserCard() : base("BattleCruiser")
    {
   //   Debug.Log("BattleCruiser ctor()");
    }

    public override void OnCardPlayed()
    {
      _playerModel.Lives++;
    }
  }
}