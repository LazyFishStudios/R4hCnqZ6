using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSlotView : MonoBehaviour 
{
  public int SlotId;
  public bool used;

	public void SetVisiblity(bool visibility)
  {
    gameObject.SetActive(visibility);
  }
}