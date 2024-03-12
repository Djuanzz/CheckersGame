using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxManager : MonoBehaviour, IDropHandler
{
    public DarkPiece darkPiecePrefabs;
    public LightPiece lightPiecePrefabs;
    public RectTransform boxPanel;
    public BoxPosition boxPosition;

    public void OnDrop(PointerEventData ev){
        if(transform.childCount == 0){
            GameObject droppedPiece = ev.pointerDrag;
            DarkPiece darkPiece = droppedPiece.GetComponent<DarkPiece>();
            if(darkPiece){
                if(darkPiece.Movement(boxPosition)){
                    darkPiece.parentAfterDrag = transform;
                }
            }
            LightPiece lightPiece = droppedPiece.GetComponent<LightPiece>();
            if(lightPiece){
                if(lightPiece.Movement(boxPosition)){
                    lightPiece.parentAfterDrag = transform;
                }
            }
        }
    }
    public void CreateLightPiece(){
        LightPiece uilightPiece = Instantiate(lightPiecePrefabs, transform);
        uilightPiece.transform.SetParent(boxPanel);
    }

    public void CreateDarkPiece(){
        DarkPiece uidarkPiece = Instantiate(darkPiecePrefabs, transform);
        uidarkPiece.transform.SetParent(boxPanel);
    }

}

public struct BoxPosition{
    public int x;
    public int y;
}
