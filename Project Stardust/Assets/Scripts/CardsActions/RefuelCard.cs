using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class RefuelCard : InstantCard
  {
    [Inject] // This is PROBABLY after ctors()
    DefendingPlayer _playerModel;

    [Inject]
    CardsModel _cardsModel;

    // parameter passed bo base must match card description ScriptableObject in Resourced 
    public RefuelCard() : base("Refuel")
    {
      // Debug.Log("Heal card ctor()");
    }

    public override void OnCardPlayed()
    {
      // For example each ship gets +1 to fuel; 
      Card target = _cardsModel.LastFieldInteraction.Target;
      (target as UnitCard).UpdateFuel(1);
      Debug.Log("Refuel card used");
    }
  }
}