using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 矢印のプレハブ（4方向分）
    public GameObject arrowFront;
    public GameObject arrowBack;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    // 各方向のFaceChecker（見えない判定キューブ）の参照
    public FaceChecker faceFront;
    public FaceChecker faceBack;
    public FaceChecker faceLeft;
    public FaceChecker faceRight;
    public FaceChecker faceTop;
    public FaceChecker faceBottom;

    // 矢印の表示位置（少し前に出すためのオフセット）
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    // Startで一度だけチェック
    void Start()
    {
        ShowArrowsBasedOnFaceCheckers();
    }

    // 面ごとの接触状態を見て、矢印を出す処理
    void ShowArrowsBasedOnFaceCheckers()
    {
        Debug.Log("ShowArrowsBasedOnFaceCheckers called");

        Debug.Log($"Front: {faceFront.isTouchingSameColor}");
        Debug.Log($"Back: {faceBack.isTouchingSameColor}");
        Debug.Log($"Left: {faceLeft.isTouchingSameColor}");
        Debug.Log($"Right: {faceRight.isTouchingSameColor}");
        Debug.Log($"Top: {faceTop.isTouchingSameColor}");
        Debug.Log($"Bottom: {faceBottom.isTouchingSameColor}");

        // Front（前）
        if (faceFront.isTouchingSameColor)
        {
            Debug.Log("Spawning ArrowFront");
            Instantiate(arrowFront, transform.position + Vector3.forward + offset, Quaternion.identity);
        }

        // Back（後）
        if (faceBack.isTouchingSameColor)
        {
            Instantiate(arrowBack, transform.position + Vector3.back + offset, Quaternion.identity);
        }

        // Left（左）
        if (faceLeft.isTouchingSameColor)
        {
            Instantiate(arrowLeft, transform.position + Vector3.left + offset, Quaternion.identity);
        }

        // Right（右）
        if (faceRight.isTouchingSameColor)
        {
            Instantiate(arrowRight, transform.position + Vector3.right + offset, Quaternion.identity);
        }
    }
}
