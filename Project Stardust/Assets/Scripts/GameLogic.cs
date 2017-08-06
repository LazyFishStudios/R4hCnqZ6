using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public enum PlayerRound
  {
    ATTACKER,
    DEFENDER
  }

  public class GameLogic
  {
    public event Action OnNextRoundStarted;
    public event Action OnPlayerInCurrentRoundChanged;

    public int CurrentRound { get; private set; }

    public GameLogic()
    {
      CurrentRound = 1;
    }


    public void StartGame()
    {

    }

    public void StartNextRound()
    {
      CurrentRound++;
      if (OnNextRoundStarted != null) OnNextRoundStarted();
    }

    public void UnitAttack(UnitCard attacking, UnitCard target)
    {
      Debug.Log(attacking.CardName + " attacked " + target.CardName);

      target.UpdateDefence(-attacking.Attack);
      attacking.OnUnitAttacked();
      if (target.Defence == 0) {
        // Destroy Unit
        // add left damage to planet
      } 
    }
  }
}