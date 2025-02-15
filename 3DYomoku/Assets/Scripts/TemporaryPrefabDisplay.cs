using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPrefabDisplay : MonoBehaviour
{
    public GameObject TemporaryPrefabWhite;
    public GameObject TemporaryPrefabBlack;

    public GameManager GameManager;

    // カーソルが乗った時の処理
    void OnMouseEnter(){
        if (GameObject.CompareTag("TargetPrefab")){
            Debug.Log("TemporaryprefabDisplay: カーソルが" + GameObject.name + "に触れました");
            if (GameManager.Instance != null){
                if (GameManager.Instance.currentPlayer == 0){
                    
                }
            }
        }
    }

    // カーソルが離れたときの処理
    void OnMouseExit(){

    }
}
