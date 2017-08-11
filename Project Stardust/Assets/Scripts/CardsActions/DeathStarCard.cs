using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class DeathStarCard : UnitCard
  {
    //[Inject] // This is PROBABLY after ctors()
  //  PlayerModel _playerModel;

  //  [Inject]
   // CardsModel _cardsModel;

    // parameter passed bo base must match card description ScriptableObject in Resourced 
    public DeathStarCard() : base("DeathStar")
    {
      // Debug.Log("DeathStar ctor()");
    }

    public override void OnCardPlayed()
    {
      Debug.Log("Destroy planet...");
    }

    public override void OnUnitAttacked()
    {
      base.OnUnitAttacked();
      // Some test attack action: "Whenever DeathStar attacks, player gains +2 energy"
    //  _playerModel.AddEnergy(2);
    }
  }
}