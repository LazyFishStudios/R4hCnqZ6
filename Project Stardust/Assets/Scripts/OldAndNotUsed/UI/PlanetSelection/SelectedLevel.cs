using System;
using System.Collections;
using System.Collections.Generic;
using PlanetSelection;
using UnityEngine;
using UnityEngine.UI;

public class SelectedLevel : MonoBehaviour
{
    public SelectedLevelData right;
    public SelectedLevelData left;
    
    public void Hide()
    {
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
    }

    public void ShowPlanetUI(LockTrigger lockTrigger)
    {
        SelectedLevelData selectedLevelData = null;
        switch (lockTrigger.planetSide)
        {
            case LockTrigger.PlanetSelectionSide.Right:
                selectedLevelData = right;
                break;
            case LockTrigger.PlanetSelectionSide.Left:
                selectedLevelData = left;
                break;
        }

        selectedLevelData.planetNameText.text = lockTrigger.planet.planetName;
        selectedLevelData.gameObject.SetActive(true);
    }

    
}
