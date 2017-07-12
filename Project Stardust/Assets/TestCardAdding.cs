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
    

    public void OnButtonPressed()
    {
      cm.AddNewCard(); 
    }
  }
}