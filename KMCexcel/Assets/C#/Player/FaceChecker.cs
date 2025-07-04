using UnityEngine;

public class FaceChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // このFaceCubeの色（タグ名と同じ文字列をInspectorで設定）
    public string faceColor;

    // この面がタイルと接触しているかを記録する
    [HideInInspector]
    public bool isTouchingSameColor = false;

    // 毎フレーム判定を初期化（接触していなければfalseのまま）
    void Update()
    {
        isTouchingSameColor = false;
    }

    // 他のColliderとぶつかったときに呼ばれる関数（isTriggerが必要）
    private void OnTriggerStay(Collider other)
    {
        // 接触した相手のタグが自分の色と一致しているか確認
        if (other.CompareTag(faceColor) || other.CompareTag("White"))
        {
            // 同じ色、またはWhiteTileと接触中であることを記録
            isTouchingSameColor = true;
        }
    }
}
