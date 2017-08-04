using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 
/// Logic for draging ALL Unit views on table. (NOT cards, but UNITS)
/// Draw drag arrow also.
/// 
/// </summary>

namespace StarDust
{
  public class UnitsDragBehaviour : MonoBehaviour
  {
    LineRenderer _lineRenderer;
    SpriteRenderer _arrowSpriteRenderer;

    [SerializeField]
    Transform ArrowHead;

    Camera cam;
    Vector3 hitPosition;
    public GameObject probe;
    float distanceToCamera;

    UnitView attackingUnitView = null;
    UnitView attackedUnitView = null;


    [Inject]
    GameLogic _gameLogic;

    private void Start()
    {
      cam = Camera.main;
      _lineRenderer = GetComponent<LineRenderer>();
      _arrowSpriteRenderer = ArrowHead.GetComponent<SpriteRenderer>();
      _arrowSpriteRenderer.color = _lineRenderer.endColor;
      SetArrowVisibility(false);
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
        // Get distance to camera:
        Vector3 h = rayHit.point - cam.transform.position;
        distanceToCamera = Vector3.Dot(h, cam.transform.forward);
      }
      return selected;
    }

    private void SetArrowVisibility(bool visiblity)
    {
      _lineRenderer.enabled = visiblity;
      _arrowSpriteRenderer.enabled = visiblity;
    }

    private void UpdateArrowHeadPosition()
    {
      Vector3 p = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
      _lineRenderer.SetPosition(1, p);
      ArrowHead.position = p;
      ArrowHead.up = _lineRenderer.GetPosition(1) - _lineRenderer.GetPosition(0);
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        attackingUnitView = RaycastForUnitCardView(Input.mousePosition);
        bool hasHit = (attackingUnitView != null);

        SetArrowVisibility(hasHit);
        if (hasHit)
        {
          _lineRenderer.SetPosition(0, attackingUnitView.transform.position);
        }

      }
      if (attackingUnitView == null)
      {
        return;
      }

      UpdateArrowHeadPosition();

      // stop drag on button up:
      if (Input.GetMouseButtonUp(0))
      {
        attackedUnitView = RaycastForUnitCardView(Input.mousePosition);
        SetArrowVisibility(false);
        if (attackedUnitView == null)
        {
          Debug.Log("No unit attacked");
          return;
        }
        if (ReferenceEquals(attackingUnitView, attackedUnitView) == false)
        {
          _gameLogic.UnitAttack(attackedUnitView.unitCard, attackedUnitView.unitCard);
        }
      }
    }
  }
}