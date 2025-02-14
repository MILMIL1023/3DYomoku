using UnityEngine;

public class CameraBasedSpawner : MonoBehaviour
{
    public GameObject prefab; // 生成するPrefab
    public Camera[] cameras; // 複数のカメラを格納する配列
    private int activeCameraIndex = 0; // 現在アクティブなカメラのインデックス
    public string clickableTag = "Clickable"; // クリック可能なオブジェクトのタグ

    void Start()
    {
        // 最初にカメラを切り替えて、正しいカメラをアクティブ化
        if (cameras.Length > 0)
        {
            SwitchCamera(activeCameraIndex);
        }
        else
        {
            Debug.LogError("カメラが設定されていません！");
        }
    }

    void Update()
    {
        // 左クリックでオブジェクトを配置
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObjectAtClick();
        }

        // 数字キーでカメラを切り替え (例: 1, 2, 3キー)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchCamera(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchCamera(4);
        }
    }

    void SpawnObjectAtClick()
    {
        // 配列が空の場合は処理を中断
        if (cameras.Length == 0)
        {
            Debug.LogError("カメラが設定されていません！");
            return;
        }

        // 現在アクティブなカメラを取得
        if (activeCameraIndex < 0 || activeCameraIndex >= cameras.Length)
        {
            Debug.LogError($"activeCameraIndex ({activeCameraIndex}) が無効です。");
            return;
        }

        Camera activeCamera = cameras[activeCameraIndex];

        // マウスのスクリーン座標を取得
        Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycastでクリック位置を取得
        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;

            // 特定のタグを持つオブジェクトだけクリック可能にする
            if (!clickedObject.CompareTag(clickableTag))
            {
                Debug.Log("クリック可能なオブジェクトではありません。");
                return;
            }

            Debug.Log($"クリックされたオブジェクト: {clickedObject.name}");

            Collider clickedCollider = hit.collider;
            Collider prefabCollider = prefab.GetComponent<Collider>();

            if (clickedCollider != null && prefabCollider != null)
            {
                // 下方向にRaycastして一番下にあるオブジェクトを検出
                Vector3 rayOrigin = clickedCollider.bounds.center; // オブジェクトの中心からRaycast開始
                rayOrigin.y = clickedCollider.bounds.max.y + 0.1f; // オブジェクトの上面から少し上

                RaycastHit downHit;

                // クリックしたオブジェクトをRaycastから除外するためにコライダーを一時的に無効化
                bool originalState = clickedCollider.enabled;
                clickedCollider.enabled = false;

                if (Physics.Raycast(rayOrigin, Vector3.down, out downHit, Mathf.Infinity))
                {
                    GameObject belowObject = downHit.collider.gameObject;

                    Vector3 spawnPosition = new Vector3(
                        clickedCollider.bounds.center.x,   // X座標はクリックしたオブジェクトと同じ
                        downHit.collider.bounds.max.y + prefabCollider.bounds.extents.y, // 下のオブジェクトの上面 + Prefab高さ分だけ上に移動
                        clickedCollider.bounds.center.z    // Z座標もクリックしたオブジェクトと同じ
                    );

                    // Prefabを生成し、一時的にコライダーを無効化して衝突を防ぐ
                    GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

                    Collider spawnedCollider = spawnedObject.GetComponent<Collider>();
                    if (spawnedCollider != null)
                    {
                        spawnedCollider.enabled = false; // コライダー無効化
                        StartCoroutine(EnableColliderAfterFrame(spawnedCollider)); // 次フレームで有効化
                    }

                    spawnedObject.transform.SetParent(belowObject.transform);

                    Debug.Log($"Prefab を生成しました。位置: {spawnPosition} 親オブジェクト: {belowObject.name}");
                }
                else
                {
                    Debug.Log("下方向にオブジェクトが見つかりませんでした。");
                }

                // コライダーの状態を元に戻す
                clickedCollider.enabled = originalState;
            }
            else
            {
                Debug.LogError("クリックされたオブジェクトまたはPrefabにコライダーがありません！");
            }
            
        }
        else
        {
            Debug.Log("クリックした場所にヒットするオブジェクトがありませんでした。");
        }
    }

    void SwitchCamera(int cameraIndex)
    {
        // インデックス範囲外の場合は処理しない
        if (cameraIndex < 0 || cameraIndex >= cameras.Length)
        {
            Debug.LogError($"指定されたカメラインデックス {cameraIndex} は無効です。");
            return;
        }

        // 全てのカメラを非アクティブ化
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == cameraIndex);
        }

        // アクティブなカメラを更新
        activeCameraIndex = cameraIndex;
    }

    private System.Collections.IEnumerator EnableColliderAfterFrame(Collider collider)
    {
        yield return null; // 次のフレームまで待機
        collider.enabled = true; // コライダー有効化
    }
}