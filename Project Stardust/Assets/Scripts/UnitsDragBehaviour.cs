using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 
/// Logic for draging ALL Unit views on table.
/// Draw drag arrow also
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
    Vector3 offset;
    Vector3 hitPosition;
    public GameObject probe;
    bool isDragging;
    public Transform hitObject;
    float dist;
    RaycastHit[] hits;
    UnitCard attackingUnit;
    UnitCard attackedUnit;

    [Inject]
    GameLogic _gameLogic;

    private void Start()
    {
      cam = Camera.main;
      _lineRenderer = GetComponent<LineRenderer>();
      _lineRenderer.enabled = false;
      _arrowSpriteRenderer = ArrowHead.GetComponent<SpriteRenderer>();
      _arrowSpriteRenderer.color = _lineRenderer.endColor;
      _arrowSpriteRenderer.enabled = false;
    }

    private void Update()
    {
      Ray rayFromCamera = cam.ScreenPointToRay(Input.mousePosition);

      // Find first object to drag:
      if (isDragging == false)
      {

        RaycastHit rayHit;
        bool hitSuccess = Physics.Raycast(rayFromCamera, out rayHit);
        if (hitSuccess)
        {
          hitObject = rayHit.transform;
          probe.transform.position = rayHit.point;
          attackingUnit = hitObject.GetComponent<UnitView>().unitCard;
        }

        if (hitSuccess && Input.GetMouseButtonDown(0))
        {
          Debug.Log("Drag start");
          _lineRenderer.enabled = true;
          _arrowSpriteRenderer.enabled = true;
          
          isDragging = true;
          offset = hitObject.transform.position - rayHit.point;
          _lineRenderer.SetPosition(0, hitObject.transform.position);
          // Get distance to camera:
          Vector3 h = rayHit.point - cam.transform.position;
          dist = Vector3.Dot(h, cam.transform.forward);
        }
      }

      if (isDragging)
      {
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist));
       // hitObject.transform.position = p + offset;
        _lineRenderer.SetPosition(1, p);
        ArrowHead.position = p;
        ArrowHead.up = _lineRenderer.GetPosition(1) - _lineRenderer.GetPosition(0);


        // if we are dragging a card, check if anything else will be hit by raycast:
        hits = Physics.RaycastAll(rayFromCamera);
      }

      // stop drag on button up:
      if (Input.GetMouseButtonUp(0) && isDragging)
      {
        isDragging = false;
        _lineRenderer.enabled = false;
        _arrowSpriteRenderer.enabled = false;
        /* 2 is only valid state to call gamelogic.UnitAttacked.
         2 hits means that we are dragging UnitView and it was released when cursor was over secong UnitView.
         I assume that there are no other gameobjects on table than UnitViews.
        */
        if(hits.Length == 2)
        {
          // Raycast doesn't guaratntee any order, so I must check what is attacking and what is attacked.
          UnitCard uc_0 = hits[0].transform.GetComponent<UnitView>().unitCard;
          UnitCard uc_1 = hits[1].transform.GetComponent<UnitView>().unitCard;

          // we stored attacking unit reference (it is the one dragged). Now just compare which is what:
          if(ReferenceEquals(uc_0,attackingUnit))
          {
            _gameLogic.UnitAttack(uc_0, uc_1);
          }
          else
          {
            _gameLogic.UnitAttack(uc_1, uc_0);
          }

        }
      }

      //Debug.DrawRay(r.origin, r.direction * 100, Color.red);
      //Debug.DrawLine(rh.point, rh.point + offset, Color.yellow);
    }
  }
}