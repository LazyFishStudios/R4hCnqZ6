using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class TestCardAdding : MonoBehaviour
  {
    [Inject]
    CardsModel cm;

    [Inject]
    GameLogic gl;
    
    public void OnButtonPressed()
    {
      cm.AddTopCardFromDeckToHand();
      gl.StartNextRound();
    }
  }
}