using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public BoxManager boxPrefab;
    public RectTransform gridPanel;

    private BoxManager uiBox;
    public void Start(){
        for (int x = 0; x < 8; x++){
            for (int y = 0; y < 8; y++){
                uiBox = Instantiate(boxPrefab, transform); 
                uiBox.transform.SetParent(gridPanel);
                uiBox.boxPosition.x = x;
                uiBox.boxPosition.y = y;
                
                if((x + y) % 2 != 0 && x < 3){
                    uiBox.CreateLightPiece();
                }

                if((x + y) % 2 != 0 && x > 4){
                    uiBox.CreateDarkPiece();
                }
            }
        }
    }
}
