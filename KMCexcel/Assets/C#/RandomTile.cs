using System.Collections.Generic;
using UnityEngine;

public class RandomTile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // �F�t���^�C���p�̃}�e���A����Inspector���犄�蓖��
    public float changeInterval = 2f; // �F�̕ω��Ԋu
    public LayerMask tileLayer; // �^�C������p���C���[�iPlayer�Ɠ����j

    private Renderer tileRenderer;

    // �}�e���A���ꗗ�i�S�F���������Ń}�b�s���O�j
    public List<Material> allMaterials;

    // �J�n���ɏ�����
    void Start()
    {
        tileRenderer = GetComponent<Renderer>();

        if (allMaterials == null || allMaterials.Count == 0)
        {
            Debug.LogError("[RandomTile] �}�e���A�����ݒ肳��Ă��܂���I");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(ChangeColorFromNeighbors), 1f, changeInterval);
    }

    // ���͂̃^�C���̐F���擾���A�������烉���_���ŕω�
    void ChangeColorFromNeighbors()
    {
        List<string> neighborTextureNames = new List<string>();

        Vector3[] directions = {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (Vector3 dir in directions)
        {
            Vector3 checkPos = transform.position + dir;
            Collider[] hits = Physics.OverlapSphere(checkPos, 0.4f, tileLayer);

            foreach (var hit in hits)
            {
                Renderer neighborRenderer = hit.GetComponent<Renderer>();
                if (neighborRenderer != null && neighborRenderer.material.mainTexture != null)
                {
                    string texName = neighborRenderer.material.mainTexture.name;
                    if (!neighborTextureNames.Contains(texName))
                    {
                        neighborTextureNames.Add(texName);
                    }
                }
            }
        }

        if (neighborTextureNames.Count == 0) return;

        // �����_����1�I�����Ă��̖��O�ƈ�v����}�e���A����K�p
        string chosenTexName = neighborTextureNames[Random.Range(0, neighborTextureNames.Count)];
        Material chosenMat = allMaterials.Find(mat => mat.mainTexture != null && mat.mainTexture.name == chosenTexName);

        if (chosenMat != null)
        {
            tileRenderer.material = chosenMat;
            Debug.Log($"[RandomTile] �F�ύX �� {chosenMat.name}");
        }
    }
}
