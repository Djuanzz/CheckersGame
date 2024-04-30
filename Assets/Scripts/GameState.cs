using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool statePiece = false;

    private void Start(){

    }

    public void ChangeState(){
        statePiece = !statePiece;
        Debug.Log(statePiece);
    }

}
