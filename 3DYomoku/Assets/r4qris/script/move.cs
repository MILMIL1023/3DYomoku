using UnityEngine;

public class SceneViewCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 1000f;
    public float zoomSpeed = 10f;

    void Update()
    {
        // 平行移動 (WASDキー)
        float h = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(h, 0, v);

        // 回転 (右クリック + マウス移動)
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, mouseX, Space.World);
            transform.Rotate(Vector3.left, mouseY);
        }

        // ズーム (マウスホイール)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed);
    }
}