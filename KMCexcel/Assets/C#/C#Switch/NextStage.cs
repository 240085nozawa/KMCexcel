using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class NextStage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // "���̃X�e�[�W��" �{�^�����������Ƃ��Ɏ��̃X�e�[�W�֐i��

    public Button nextStageButton;

    void Start()
    {
        if (nextStageButton != null)
        {
            nextStageButton.onClick.AddListener(LoadNextStage);
        }
        else
        {
            Debug.LogError("NextStage�{�^�����ݒ肳��Ă��܂���BInspector�Őݒ肵�Ă��������B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadNextStage()
    {
        string currentScene = StageTracker.LastPlayedStage;

        Match match = Regex.Match(currentScene, @"TGS(\d+)-(\d+)"); // �� �������C��

        if (!match.Success || match.Groups.Count < 3)
        {
            Debug.LogError("�V�[������ TGSX-Y �̌`���ł͂���܂���: " + currentScene);
            return;
        }

        int group = int.Parse(match.Groups[1].Value); // TGS�̃O���[�v�ԍ�
        int stage = int.Parse(match.Groups[2].Value); // �X�e�[�W�ԍ�

        // ���̌��𐶐�
        string nextStageName = $"TGS{group}-{stage + 1}";

        // ���݂��邩�`�F�b�N�iBuild Settings�ɓo�^����Ă���K�v����j
        if (Application.CanStreamedLevelBeLoaded(nextStageName))
        {
            SceneManager.LoadScene(nextStageName);
        }
        else
        {
            // ���݂��Ȃ��ꍇ�͎��̃O���[�v��1�X�e�[�W�ڂɐi��
            string nextGroupName = $"TGS{group + 1}-1";
            if (Application.CanStreamedLevelBeLoaded(nextGroupName))
            {
                SceneManager.LoadScene(nextGroupName);
            }
            else
            {
                Debug.Log("����ȏ�X�e�[�W�����݂��܂���B�Q�[���N���A�H");
            }
        }
    }
}
