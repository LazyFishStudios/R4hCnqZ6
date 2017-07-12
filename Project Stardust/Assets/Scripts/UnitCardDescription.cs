using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  [CreateAssetMenu(fileName = "UnitCard", menuName = "Cards/UnitCard", order = 1)]
  public class UnitCardDescription : CardDescription
  {
    public int Defence;
    public int Attack;
    public int Fuel;
    public GameObject ModelPrefab;
  }
}