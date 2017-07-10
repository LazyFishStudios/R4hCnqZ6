using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StarDust
{
  public class UnitCardView : MonoBehaviour
  {
    [SerializeField]
    TextMeshProUGUI cost;

    [SerializeField]
    TextMeshProUGUI defence;

    [SerializeField]
    TextMeshProUGUI attack;

    [SerializeField]
    TextMeshProUGUI fuel;

    public void UpdateDisplayedValues(UnitCard newUnitCard)
    {
      cost.text = newUnitCard.Cost.ToString();
      defence.text = newUnitCard.Defence.ToString();
      attack.text = newUnitCard.Attack.ToString();
      fuel.text = newUnitCard.Fuel.ToString();
    }
  }
}