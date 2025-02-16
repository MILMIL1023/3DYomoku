using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TemporaryPrefabDisplay : MonoBehaviour
{
    public GameObject TemporaryPrefabWhite;
    public GameObject TemporaryPrefabBlack;

    public GameManager GameManager;

    void Update(){
        // マウス位置からレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.z;
            Debug.Log("x: " + x + " y: " + y);
            if (GameManager.Instance != null){
                if (GameManager.Instance.currentPlayer == 0){
                    Vector3 PrefabPosition = new Vector3(x, 0, y);
                    Instantiate(TemporaryPrefabBlack, PrefabPosition, Quaternion.identity);
                }
                if(GameManager.Instance.currentPlayer == 1){
                    Vector3 PrefabPosition = new Vector3(x, 0, y);
                    Instantiate(TemporaryPrefabWhite, PrefabPosition, Quaternion.identity);
                }
            }
        }
    }
}
