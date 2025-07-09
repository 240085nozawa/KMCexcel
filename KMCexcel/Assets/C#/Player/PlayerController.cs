using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform[] faceCheckers; // 6方向の FaceChecker を登録（順番：前後左右上下）
    public float moveDuration = 0.3f;
    public LayerMask tileLayer;
    public GameObject arrowParent; // 矢印の親オブジェクト

    private bool isMoving = false;
    private MoveCounter moveCounter;

    void Start()
    {
        moveCounter = FindObjectOfType<MoveCounter>();
        ShowArrows();
    }

    public void ShowArrows()
    {
        if (isMoving) return;

        ClearArrows();

        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        for (int i = 0; i < 4; i++)
        {
            Vector3 dir = directions[i];
            Transform face = faceCheckers[i];

            // 前方のタイル上にRayを飛ばす
            Vector3 tilePos = transform.position + dir;
            Collider[] hitTiles = Physics.OverlapSphere(tilePos, 0.1f, tileLayer);

            if (hitTiles.Length > 0)
            {
                GameObject tile = hitTiles[0].gameObject;

                // WhiteTairu なら無条件でOK
                if (tile.CompareTag("White"))
                {
                    SpawnArrow(dir);
                }
                else
                {
                    // FaceChecker のタグとタイル上の Cube のタグを比較
                    RaycastHit hit;
                    if (Physics.Raycast(tile.transform.position + Vector3.up * 1f, Vector3.down, out hit, 2f))
                    {
                        if (hit.collider != null && hit.collider.CompareTag(face.tag))
                        {
                            SpawnArrow(dir);
                        }
                    }
                }
            }
        }
    }

    void SpawnArrow(Vector3 dir)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position + dir, Quaternion.LookRotation(dir));
        arrow.transform.SetParent(arrowParent.transform, true);
        arrow.GetComponent<ArrowController>().Initialize(dir, this);
    }

    public void Move(Vector3 direction)
    {
        if (isMoving) return;

        StartCoroutine(MoveRoutine(direction));
    }

    IEnumerator MoveRoutine(Vector3 direction)
    {
        isMoving = true;
        ClearArrows();

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction;

        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0) * startRot;

        float elapsed = 0;
        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        transform.rotation = endRot;

        moveCounter.UseMove();
        isMoving = false;
        ShowArrows();
    }

    void ClearArrows()
    {
        foreach (Transform child in arrowParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
