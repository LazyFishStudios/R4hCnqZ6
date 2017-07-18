using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace StarDust
{
  /// <summary>
  /// 
  /// Represents units view that is on field.
  /// 
  /// </summary>
  public class UnitView : MonoBehaviour
  {
    [SerializeField]
    TextMeshProUGUI DefenceLabel;

    [SerializeField]
    TextMeshProUGUI AttackLabel;

    [SerializeField]
    TextMeshProUGUI FuelLabel;

    [SerializeField]
    Transform Center; // Place where 3D model should be placed.

    // UnitCard attached to this view
    public UnitCard unitCard;

    public void FillValues(UnitCard unitCard)
    {
      this.unitCard = unitCard;
      UnitCard_OnCardValuesUpdated();
    }

    private void Start()
    {
      unitCard.OnCardValuesUpdated += UnitCard_OnCardValuesUpdated;
    }

    private void UnitCard_OnCardValuesUpdated()
    {
      DefenceLabel.text = unitCard.Defence.ToString();
      AttackLabel.text = unitCard.Attack.ToString();
      FuelLabel.text = unitCard.Fuel.ToString();
      Instantiate(unitCard.Prefab, Center);
    }

    private void OnDestroy()
    {
      unitCard.OnCardValuesUpdated -= UnitCard_OnCardValuesUpdated;
    }



    // This is used by Zenject binding
    public class Factory : Factory<UnitView>
    {

    }
  }
}