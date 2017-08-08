using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class Arrow : MonoBehaviour
  {
    [SerializeField]
    Transform ArrowHead;

    [Inject]
    InputManager _inputManager;


    LineRenderer _lineRenderer;
    void Start()
    {
      _lineRenderer = GetComponent<LineRenderer>();
      _inputManager.OnDragStart += _inputManager_OnDragStart;
      _inputManager.OnDragEnd += _inputManager_OnDragEnd;
      _inputManager.OnDrag += _inputManager_OnDrag;

      SetArrowVisibility(false);

    }

    private void _inputManager_OnDragStart(GameObject dragged, Vector3 newWorldPosition)
    {
      _lineRenderer.SetPosition(0, new Vector3( dragged.transform.position.x, dragged.transform.position.y, newWorldPosition.z));
      SetArrowVisibility(true);
    }

    private void _inputManager_OnDrag(GameObject arg1, Vector3 newWorldPosition)
    {
      _lineRenderer.SetPosition(1, newWorldPosition);
      ArrowHead.position = newWorldPosition;
      ArrowHead.up = _lineRenderer.GetPosition(1) - _lineRenderer.GetPosition(0);
    }


    private void _inputManager_OnDragEnd(GameObject arg1)
    {
      SetArrowVisibility(false);
    }

    private void SetArrowVisibility(bool visiblity)
    {
      _lineRenderer.enabled = visiblity;
      ArrowHead.gameObject.SetActive(visiblity);
    }
  }
}