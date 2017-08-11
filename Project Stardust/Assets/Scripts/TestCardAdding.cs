using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class TestCardAdding : MonoBehaviour
  {
    // This won't work, because there is no cardModel Context
    //CardsModel cm;

    [Inject]
    GameLogic gl;

    [Inject]
    AttackingPlayerModel apm;

    [Inject]
    DefendingPlayerModel dpm;
    
    public void OnButtonPressed()
    {
      apm.GetCardsModel.AddTopCardFromDeckToHand();
      dpm.GetCardsModel.AddTopCardFromDeckToHand();
      gl.StartNextRound();
    }

    public void StartGame()
    {
      apm.GetCardsModel.Initialize();
      dpm.GetCardsModel.Initialize();
    }
  }
}