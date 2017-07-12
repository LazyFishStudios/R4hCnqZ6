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
    PlayerModel _playerModel;

    // parameter passed bo base must match card description ScriptableObject in Resourced 
    public HealPlanetCard() : base("HealPlanet")
    {
      Debug.Log("Heal card ctor()");
    }

    public override void OnCardPlayed()
    {
      // For example each ship gets +1 to fuel;      
      _playerModel.Lives++;
    }
  }
}