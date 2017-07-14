using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace StarDust
{
  public class UnitView : MonoBehaviour
  {
    [Inject]
    PlayerModel pm;

    [SerializeField]
    TextMeshProUGUI DefenceLabel;

    [SerializeField]
    TextMeshProUGUI AttackLabel;

    [SerializeField]
    TextMeshProUGUI FuelLabel;

    [SerializeField]
    Transform Center;
    public void FillValues(UnitCard unitCard)
    {
      DefenceLabel.text = unitCard.Defence.ToString();
      AttackLabel.text = unitCard.Attack.ToString();
      FuelLabel.text = unitCard.Fuel.ToString();
      Instantiate(unitCard.Prefab, Center);
    }

    // This is used by Zenject binding
    public class Factory : Factory<UnitView>
    {

    }
  }
}