using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Vector3 goalPosition = new Vector3(20, 1, 20); // �S�[�����W�i�ύX�\�j
    public float requiredTime = 1.0f; // ���b�o�߂�����V�[���ړ����邩�i�ύX�\�j

    private float stayTime = 0f; // �v���C���[���S�[���ɗ��܂�������
    private bool playerAtGoal = false; // �v���C���[���S�[���ɂ��邩
    private Transform playerTransform; // �v���C���[��Transform

    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�I�u�W�F�N�g��T���� Transform ���擾
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("[Goal] Player�^�O�̂����I�u�W�F�N�g��������܂���I");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�I�u�W�F�N�g��T���� Transform ���擾
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("[Goal] Player�^�O�̂����I�u�W�F�N�g��������܂���I");
        }

        if (playerTransform == null) return; // �v���C���[��������Ȃ���Ώ������Ȃ�

        if (IsAtGoal(playerTransform.position))
        {
            if (!playerAtGoal)
            {
                Debug.Log("[Goal] �v���C���[���S�[�����W�ɓ��B�I");
                playerAtGoal = true;
                stayTime = 0f; // �J�E���g���Z�b�g
            }

            stayTime += Time.deltaTime;
            Debug.Log($"[Goal] ���݂̑؍ݎ���: {stayTime}/{requiredTime}");

            if (stayTime >= requiredTime)
            {
                StageTracker.LastPlayedStage = SceneManager.GetActiveScene().name;

                Debug.Log("[Goal] �V�[���ړ������s�I");
                SceneManager.LoadScene("Clear"); // �V�[���ړ��i�V�[�����͕ύX�j
            }
        }
        else
        {
            playerAtGoal = false;
            stayTime = 0f; // �S�[������o���烊�Z�b�g
        }
    }

    // �v���C���[���S�[�����W�ɂ��邩����
    private bool IsAtGoal(Vector3 playerPos)
    {
        return Vector3.Distance(playerPos, goalPosition) < 0.5f; // �덷���l��
    }
}
