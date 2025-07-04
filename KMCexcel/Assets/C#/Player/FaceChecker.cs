using UnityEngine;

public class FaceChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ����FaceCube�̐F�i�^�O���Ɠ����������Inspector�Őݒ�j
    public string faceColor;

    // ���̖ʂ��^�C���ƐڐG���Ă��邩���L�^����
    [HideInInspector]
    public bool isTouchingSameColor = false;

    // ���t���[��������������i�ڐG���Ă��Ȃ����false�̂܂܁j
    void Update()
    {
        isTouchingSameColor = false;
    }

    // ����Collider�ƂԂ������Ƃ��ɌĂ΂��֐��iisTrigger���K�v�j
    private void OnTriggerStay(Collider other)
    {
        // �ڐG��������̃^�O�������̐F�ƈ�v���Ă��邩�m�F
        if (other.CompareTag(faceColor) || other.CompareTag("White"))
        {
            // �����F�A�܂���WhiteTile�ƐڐG���ł��邱�Ƃ��L�^
            isTouchingSameColor = true;
        }
    }
}
