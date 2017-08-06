using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class TestCardAdding : MonoBehaviour
  {
    [Inject(Id = "d")]
    CardsModel cm;

    [Inject]
    GameLogic gl;

    [Inject]
    DefendingPlayer dp;
    
    public void OnButtonPressed()
    {
      cm.AddTopCardFromDeckToHand();
      gl.StartNextRound();
    }

    public void StartGame()
    {
      cm.Initialize();
    }
  }
}