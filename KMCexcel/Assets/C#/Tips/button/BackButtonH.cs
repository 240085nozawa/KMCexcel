using System.Collections.Generic;
using UnityEngine;

public class BackButtonH : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // �o�c�{�^���Ȃǂ��������Ƃ��ɁA�w�肵�� UI �v�f���܂Ƃ߂Ĕ�\���ɂ���X�N���v�g

    [Header("��\���ɂ�����UI�v�f")]
    [SerializeField] private List<GameObject> targetsToHide = new List<GameObject>();

    // �o�c�{�^���������ꂽ�Ƃ��ɌĂяo���p�iButton �� OnClick �ɓo�^�j
    public void HideUI()
    {
        foreach (GameObject element in targetsToHide)
        {
            if (element != null)
                element.SetActive(false);
        }
    }
}
