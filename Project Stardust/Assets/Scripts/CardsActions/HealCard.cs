using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class HealPlanetCard : InstantCard
  {
    [Inject] // This is PROBABLY after ctors()
    DefendingPlayer _playerModel;

    [Inject]
    CardsModel _cardsModel;

    // parameter passed bo base must match card description ScriptableObject in Resourced 
    public HealPlanetCard() : base("HealPlanet")
    {
      // Debug.Log("Heal card ctor()");
    }

    public override void OnCardPlayed()
    {
      // For example each ship gets +1 to fuel; 
      Card target = _cardsModel.LastFieldInteraction.Target;
      (target as UnitCard).UpdateFuel(1);
      Debug.Log("Heal card used");
    }
  }
}