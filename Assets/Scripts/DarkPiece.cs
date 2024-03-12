using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DarkPiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    private BoxPosition boxPosition;
    public void OnBeginDrag(PointerEventData ev){
        boxPosition.x = transform.parent.gameObject.GetComponent<BoxManager>().boxPosition.x;
        boxPosition.y = transform.parent.gameObject.GetComponent<BoxManager>().boxPosition.y;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData ev){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData ev){
        Debug.Log("x: " + boxPosition.x + " y: " + boxPosition.y);
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public bool Movement(BoxPosition boxPositionTarget){
        if(boxPositionTarget.x == boxPosition.x - 1 && (boxPositionTarget.y == boxPosition.y + 1 || boxPositionTarget.y == boxPosition.y - 1)){
            boxPosition.x = boxPositionTarget.x;
            boxPosition.y = boxPositionTarget.y;
            return true;
        }
        return false;
    }
}
