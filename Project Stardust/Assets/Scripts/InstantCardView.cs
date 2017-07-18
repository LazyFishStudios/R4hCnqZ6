using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StarDust
{
  public class InstantCardView : CardView
  {
    [SerializeField]
    TextMeshProUGUI cost;

    public void UpdateDisplayedValues(InstantCard newInstantCard)
    {
      cost.text = newInstantCard.Cost.ToString();
      
    }
  }
}