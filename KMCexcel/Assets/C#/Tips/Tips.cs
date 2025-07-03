using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("�\���E��\���Ώۂ�UI�v�f")]
    [SerializeField] private List<GameObject> tipsElements = new List<GameObject>();

    private bool isVisible = false;

    // Option�{�^���������ꂽ�Ƃ��ɌĂ΂��
    public void ToggleTips()
    {
        isVisible = !isVisible;

        foreach (GameObject element in tipsElements)
        {
            if (element != null)
                element.SetActive(isVisible);
        }
    }

    // �J�n���͂��ׂĔ�\���ɂ���
    void Start()
    {
        foreach (GameObject element in tipsElements)
        {
            if (element != null)
                element.SetActive(false);
        }
    }
}
