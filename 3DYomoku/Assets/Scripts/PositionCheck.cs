using UnityEngine;

public class ClickedObjectGlobalPosition : MonoBehaviour
{
    void Update()
    {
        // 左クリックが押されたときの処理
        if (Input.GetMouseButtonDown(0))
        {
            // カメラからマウス位置に向かってRay（レイ）を生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // Raycastでオブジェクトの衝突を検知
            if (Physics.Raycast(ray, out hit))
            {
                // Rayが当たったオブジェクトのグローバル座標を取得（transform.positionはワールド座標）
                Vector3 globalPosition = hit.collider.gameObject.transform.position;
                
                // クリックしたオブジェクトの名前とグローバル座標をコンソールへ出力
                Debug.Log("Clicked Object: " + hit.collider.gameObject.name +
                          ", Global Position: " + globalPosition);
            }
        }
    }
}
