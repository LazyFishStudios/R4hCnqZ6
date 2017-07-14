using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class UnitView : MonoBehaviour
  {
    [Inject]
    PlayerModel pm;

    private void Update()
    {
      Debug.Log(pm.Lives);
    }

    public void FillValues(UnitCard unitCard)
    {
      Debug.Log(unitCard.Attack);
    }

    // This is used by Zenject binding
    public class Factory : Factory<UnitView>
    {

    }
  }
}