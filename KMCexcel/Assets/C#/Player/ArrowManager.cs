using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ���̃v���n�u�i4�������j
    public GameObject arrowFront;
    public GameObject arrowBack;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    // �e������FaceChecker�i�����Ȃ�����L���[�u�j�̎Q��
    public FaceChecker faceFront;
    public FaceChecker faceBack;
    public FaceChecker faceLeft;
    public FaceChecker faceRight;

    // ���̕\���ʒu�i�����O�ɏo�����߂̃I�t�Z�b�g�j
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    // Start�ň�x�����`�F�b�N
    void Start()
    {
        ShowArrowsBasedOnFaceCheckers();
    }

    // �ʂ��Ƃ̐ڐG��Ԃ����āA�����o������
    void ShowArrowsBasedOnFaceCheckers()
    {
        // Front�i�O�j
        if (faceFront.isTouchingSameColor)
        {
            Instantiate(arrowFront, transform.position + Vector3.forward + offset, Quaternion.identity);
        }

        // Back�i��j
        if (faceBack.isTouchingSameColor)
        {
            Instantiate(arrowBack, transform.position + Vector3.back + offset, Quaternion.identity);
        }

        // Left�i���j
        if (faceLeft.isTouchingSameColor)
        {
            Instantiate(arrowLeft, transform.position + Vector3.left + offset, Quaternion.identity);
        }

        // Right�i�E�j
        if (faceRight.isTouchingSameColor)
        {
            Instantiate(arrowRight, transform.position + Vector3.right + offset, Quaternion.identity);
        }
    }
}
