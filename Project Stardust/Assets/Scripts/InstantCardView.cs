using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace StarDust
{
  public class InstantCardView : CardView
  {
    [SerializeField]
    TextMeshProUGUI cost;

    [SerializeField]
    Image thumbnail;

    public void UpdateDisplayedValues(InstantCard newInstantCard)
    {
      cost.text = newInstantCard.Cost.ToString();
      type = newInstantCard.Type;
      thumbnail.sprite = newInstantCard.Thumbnail;
    }
  }
}