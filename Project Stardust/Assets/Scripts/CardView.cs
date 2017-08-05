using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public abstract class CardView : MonoBehaviour
  {
    public  CardType type { get; protected set; }
  }
}