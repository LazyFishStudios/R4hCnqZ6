using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Zenject;

namespace StarDust
{
  public class EnergyBarView : MonoBehaviour
  {
    [Inject]
    DefendingPlayer defendingPlayer;

    public Color filledColor;
    public Color emptyColor;

    public List<Image> energyFields;

    void Start()
    {
      energyFields = new List<Image>();
      foreach (Transform childTransform in transform)
      {
        energyFields.Add(childTransform.GetComponent<Image>());
      }
      defendingPlayer.OnEnergyChanged += _gameLogic_OnRoundChanged;
      SetEnergyValue(defendingPlayer.Energy);
    }

    private void OnDestroy()
    {
      defendingPlayer.OnEnergyChanged -= _gameLogic_OnRoundChanged;
    }

    private void _gameLogic_OnRoundChanged()
    {
      SetEnergyValue(defendingPlayer.Energy);
    }

    private void SetEnergyValue(int energyValue)
    {
      energyFields.ForEach(im => im.color = emptyColor); // clear each element
      energyFields.Take(energyValue).ToList().ForEach(im => im.color = filledColor); // fill again
    }
  }
}