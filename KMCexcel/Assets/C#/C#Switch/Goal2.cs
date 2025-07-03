using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("�S�[���ݒ�")]
    public Vector3 goalPosition = new Vector3(20, 1, 20); // �S�[�����W�i�C���X�y�N�^�[�Őݒ�j
    public float waitTime = 1.0f;                         // �V�[���J�ڂ܂ł̑ҋ@����

    private float stayTime = 0f;          // �S�[���n�_�ɗ��܂�������
    private bool playerAtGoal = false;    // �v���C���[���S�[���ɂ��邩�ǂ���
    private Transform playerTransform;    // �v���C���[�� Transform

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("[Goal2] Player�^�O�̂����I�u�W�F�N�g��������܂���");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        if (IsAtGoal(playerTransform.position))
        {
            stayTime += Time.deltaTime;
            Debug.Log($"[Goal2] �S�[�����ɑ؍ݒ�: {stayTime:F2}/{waitTime}");

            if (!playerAtGoal && stayTime >= waitTime)
            {
                Debug.Log("[Goal2] �V�[���ړ����s�FClear");
                SceneManager.LoadScene("Clear");
                playerAtGoal = true;
            }
        }
        else
        {
            stayTime = 0f;
            playerAtGoal = false;
        }
    }

    // �v���C���[���S�[���ʒu�ɂ��邩�̔���iXZ�덷0.5�ȓ��AY�͊��S��v�j
    private bool IsAtGoal(Vector3 pos)
    {
        Vector2 playerXZ = new Vector2(pos.x, pos.z);
        Vector2 goalXZ = new Vector2(goalPosition.x, goalPosition.z);
        return Vector2.Distance(playerXZ, goalXZ) < 0.5f && Mathf.Approximately(pos.y, goalPosition.y);
    }
}
