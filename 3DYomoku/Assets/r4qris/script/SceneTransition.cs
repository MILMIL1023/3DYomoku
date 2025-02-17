using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // この関数がボタンのOnClickイベントで呼ばれます
    public void LoadMILScene()
    {
        // "MILScene"という名前のシーンを読み込みます
        SceneManager.LoadScene("MILScene");
    }
}