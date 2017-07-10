using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public class UnitCard : Card
  {
    public int Fuel { get; private set; }
    public int Attack { get; private set; }
    public int Defence { get; private set; }
  }
}