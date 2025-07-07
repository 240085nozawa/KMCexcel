using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 矢印を出す処理を持ったArrowManagerへの参照
    private ArrowManager arrowManager;

    // すでに矢印を出しているか（何度も出さないように）
    private bool arrowsSpawned = false;

    void Start()
    {
        // ArrowManagerをこのオブジェクト（Player）から探す
        Debug.Log("PlayerController Start");

        arrowManager = GetComponent<ArrowManager>();

        if (arrowManager == null)
        {
            Debug.LogWarning("ArrowManager not found!");
        }

        // 最初のフレームで矢印を出す
        Invoke("ShowArrows", 0.1f);
    }

    void Update()
    {
        // 今後、移動完了後などに再び矢印を出す処理を追加するためにUpdateに構造を用意
    }

    // 矢印を出す関数
    public void ShowArrows()
    {
        if (arrowManager != null && arrowsSpawned == false)
        {
            // ArrowManagerの中の矢印表示処理を呼び出す
            arrowManager.SendMessage("ShowArrowsBasedOnFaceCheckers");
            arrowsSpawned = true;
        }
    }

    // 移動が終わったあとに呼ばれることを想定した矢印再表示
    public void ResetArrowDisplay()
    {
        arrowsSpawned = false;
        ShowArrows();
    }
}
