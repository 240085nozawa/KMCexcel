using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsYes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // �q���g�{�^���������ƃS�[���܂ł̎w�萔�itipLength�j�̃��[�g���ꎞ�I�Ƀn�C���C�g�\������X�N���v�g

    [Header("�q���g�ݒ�")]
    public List<GameObject> hintPath = new List<GameObject>(); // �蓮�ŃZ�b�g���鐳�����[�g
    public int tipLength = 5;          // �\������ő�}�X��
    public float tipDuration = 3f;     // �\�����ԁi�b�j
    public GameObject hintMarkerPrefab; // �\������}�[�J�[�i0.5�}�X��ɕ\�������j

    private List<GameObject> spawnedMarkers = new List<GameObject>();

    // �{�^������Ăяo���p
    public void ShowHint()
    {
        StartCoroutine(ShowHintCoroutine());
    }

    IEnumerator ShowHintCoroutine()
    {
        spawnedMarkers.Clear();

        // �w�肳�ꂽ�}�X���܂ŕ\��
        for (int i = 0; i < Mathf.Min(tipLength, hintPath.Count); i++)
        {
            GameObject tile = hintPath[i];
            Vector3 markerPos = tile.transform.position + new Vector3(0, 0.5f, 0); // �^�C���̏�ɕ\��
            GameObject marker = Instantiate(hintMarkerPrefab, markerPos, Quaternion.identity);
            spawnedMarkers.Add(marker);
        }

        yield return new WaitForSeconds(tipDuration);

        // �}�[�J�[�폜
        foreach (GameObject marker in spawnedMarkers)
        {
            if (marker != null)
                Destroy(marker);
        }
        spawnedMarkers.Clear();
    }
}
