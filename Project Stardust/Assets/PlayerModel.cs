using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
/// <summary>
/// Base class for both attacking and defending player
/// </summary>
/// 
  public abstract class PlayerModel
  {
    GameLogic _gameLogic;

    public int Energy { get; private set; }

    [Inject]
    public void InjectDependencies(GameLogic gameLogic)
    {
      _gameLogic = gameLogic;
      _gameLogic.OnNextRoundStarted += _gameLogic_OnNextRoundStarted;
    }

    private void _gameLogic_OnNextRoundStarted()
    {
      Debug.Log(":3=");
    }
  }
}