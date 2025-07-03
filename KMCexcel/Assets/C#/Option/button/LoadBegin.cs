using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBegin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Button restartButton; // ���߂���{�^��

    void Start()
    {
        // ���߂���{�^���̃N���b�N�C�x���g��ݒ�
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �u���߂���v�{�^�����������Ƃ��̏���
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
