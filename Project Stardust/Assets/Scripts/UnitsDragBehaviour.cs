using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 
/// Logic for draging ALL Unit views on table. (NOT cards, but UNITS)
/// 
/// </summary>

namespace StarDust
{
  public class UnitsDragBehaviour : MonoBehaviour
  {
 
   
    Camera cam;
    Vector3 hitPosition;
    public GameObject probe; 

    UnitView attackingUnitView = null;
    UnitView attackedUnitView = null;


    [Inject]
    GameLogic _gameLogic;

    private void Start()
    {
      cam = Camera.main;
    }


    private UnitView RaycastForUnitCardView(Vector2 screenPosition)
    {
      UnitView selected = null;
      Ray rayFromCamera;
      RaycastHit rayHit;
      rayFromCamera = cam.ScreenPointToRay(Input.mousePosition);
      bool hitSuccess = Physics.Raycast(rayFromCamera, out rayHit);

      if (hitSuccess)
      { 
        probe.transform.position = rayHit.point;
        selected = rayHit.transform.GetComponent<UnitView>();
      }
      return selected;
    }
    
    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        attackingUnitView = RaycastForUnitCardView(Input.mousePosition);
        bool hasHit = (attackingUnitView != null);
        
      }
      if (attackingUnitView == null)
      {
        return;
      }
       

      // stop drag on button up:
      if (Input.GetMouseButtonUp(0))
      {
        attackedUnitView = RaycastForUnitCardView(Input.mousePosition);
        
        if (attackedUnitView == null)
        {
          Debug.Log("No unit attacked");
          return;
        }
        if (ReferenceEquals(attackingUnitView, attackedUnitView) == false)
        {
          _gameLogic.UnitAttack(attackingUnitView.unitCard, attackedUnitView.unitCard);
        }
      }
    }
  }
}