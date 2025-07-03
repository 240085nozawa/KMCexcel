using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [Header("�\���E��\���Ώۂ�UI�v�f")]
    [SerializeField] private List<GameObject> optionElements = new List<GameObject>();

    private bool isVisible = false;

    // Option�{�^���������ꂽ�Ƃ��ɌĂ΂��
    public void ToggleOptions()
    {
        isVisible = !isVisible;

        foreach (GameObject element in optionElements)
        {
            if (element != null)
                element.SetActive(isVisible);
        }
    }

    // �J�n���͂��ׂĔ�\���ɂ���
    void Start()
    {
        foreach (GameObject element in optionElements)
        {
            if (element != null)
                element.SetActive(false);
        }
    }
}
