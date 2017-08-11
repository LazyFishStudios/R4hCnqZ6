using System;
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

    [Inject]
    protected CardsModel _cardsModel;

    public CardsModel GetCardsModel
    {
      get {
        //Debug.Log("Card model request");
        return _cardsModel;
      }
    }


    public int Energy { get; private set; }
    public event Action OnEnergyChanged;

    [Inject]
    public void InjectDependencies(GameLogic gameLogic)
    {
      _gameLogic = gameLogic;
      _gameLogic.OnNextRoundStarted += _gameLogic_OnNextRoundStarted;
    }

    private void _gameLogic_OnNextRoundStarted()
    {
      Debug.Log("Next round started :3=");
    }

    public void AddEnergy(int e)
    {
      Energy += e;
      if (OnEnergyChanged != null) OnEnergyChanged();
    }
  }
}