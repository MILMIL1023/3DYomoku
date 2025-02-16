using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverLogger : MonoBehaviour
{
    private string lastHoveredName = ""; // 前回ログ出力したオブジェクト名

    void Update()
    {
        // マウス位置からレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // ヒットしたオブジェクトの名前を取得
            string currentName = hit.collider.gameObject.name;
            if (currentName != lastHoveredName)
            {
                Debug.Log("カーソルが乗っているオブジェクト: " + currentName);
                lastHoveredName = currentName; // 名前を更新
            }
        }
        else
        {
            lastHoveredName = ""; // 何もヒットしない場合リセット
        }
    }
}
