using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] cameras; // カメラを格納する配列

    void Start()
    {
        // 最初のカメラ以外を非アクティブ化
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    void Update()
    {
        // キーボード入力でカメラ切り替え
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(0); // 配列の0番目のカメラ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(1); // 配列の1番目のカメラ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera(2); // 配列の2番目のカメラ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchCamera(3); // 配列の3番目のカメラ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchCamera(4); // 配列の4番目のカメラ
        }
    }

    void SwitchCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(i == index); // 指定したカメラだけアクティブ化
        }
    }
}