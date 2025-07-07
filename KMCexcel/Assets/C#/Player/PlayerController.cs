using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // �����o��������������ArrowManager�ւ̎Q��
    private ArrowManager arrowManager;

    // ���łɖ����o���Ă��邩�i���x���o���Ȃ��悤�Ɂj
    private bool arrowsSpawned = false;

    void Start()
    {
        // ArrowManager�����̃I�u�W�F�N�g�iPlayer�j����T��
        Debug.Log("PlayerController Start");

        arrowManager = GetComponent<ArrowManager>();

        if (arrowManager == null)
        {
            Debug.LogWarning("ArrowManager not found!");
        }

        // �ŏ��̃t���[���Ŗ����o��
        Invoke("ShowArrows", 0.1f);
    }

    void Update()
    {
        // ����A�ړ�������ȂǂɍĂі����o��������ǉ����邽�߂�Update�ɍ\����p��
    }

    // �����o���֐�
    public void ShowArrows()
    {
        if (arrowManager != null && arrowsSpawned == false)
        {
            // ArrowManager�̒��̖��\���������Ăяo��
            arrowManager.SendMessage("ShowArrowsBasedOnFaceCheckers");
            arrowsSpawned = true;
        }
    }

    // �ړ����I��������ƂɌĂ΂�邱�Ƃ�z�肵�����ĕ\��
    public void ResetArrowDisplay()
    {
        arrowsSpawned = false;
        ShowArrows();
    }
}
