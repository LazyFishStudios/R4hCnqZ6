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

    public void StartNextRound()
    {
      CurrentRound++;
      if (OnNextRoundStarted != null) OnNextRoundStarted();
    }
  }
}