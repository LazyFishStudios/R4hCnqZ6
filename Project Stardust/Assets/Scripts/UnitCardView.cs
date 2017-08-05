using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace StarDust
{
  public class UnitCardView : CardView
  {
    [SerializeField]
    TextMeshProUGUI cost;

    [SerializeField]
    TextMeshProUGUI defence;

    [SerializeField]
    TextMeshProUGUI attack;

    [SerializeField]
    TextMeshProUGUI fuel;

    [SerializeField]
    Image thumbnail;

    public UnitCard thisUnitCard;

    public void UpdateDisplayedValues(UnitCard newUnitCard)
    {
      cost.text = newUnitCard.Cost.ToString();
      defence.text = newUnitCard.Defence.ToString();
      attack.text = newUnitCard.Attack.ToString();
      fuel.text = newUnitCard.Fuel.ToString();
      type = newUnitCard.Type;
      thisUnitCard = newUnitCard;
      thumbnail.sprite = newUnitCard.Thumbnail;
    }
  }
}