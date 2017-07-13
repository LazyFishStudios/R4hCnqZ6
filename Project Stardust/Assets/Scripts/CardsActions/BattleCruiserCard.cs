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

    [Inject]
    CardsModel _cardsModel;

    // parameter passed bo base must match card description ScriptableObject in Resourced 
    public BattleCruiserCard() : base("BattleCruiser")
    {
      Debug.Log("BattleCruiser ctor()");
    }

    public override void OnCardPlayed()
    {
      // For example each ship gets +1 to fuel; 
      Vector2 p = _cardsModel.lastCardEventData.position;
      Vector3 pos =Camera.main.ScreenToWorldPoint(new Vector3(p.x, p.y, 10));
      GameObject.Instantiate(Prefab,pos,Prefab.transform.rotation);
      _playerModel.Lives++;
    }
  }
}