using UnityEngine;

public class Camera2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ��]�̒��S�ƂȂ���W�i�C���X�y�N�^�[�Őݒ�\�j
    public Vector3 targetPosition = Vector3.zero;

    // �����i�Y�[�������j
    public float distance = 10.0f;

    // �}�E�X���x
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    // �㉺�̊p�x����
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    // ���݂̊p�x
    private float x = 0.0f;
    private float y = 0.0f;

    public float minDistance = 1.5f; // �ŏ��Y�[������
    public float maxDistance = 10.0f; // �ő�Y�[������
    public float zoomSpeed = 5.0f; // �Y�[�����x

    void Start()
    {
        // �����p�x�̎擾
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // �J�[�\�����b�N�͕K�v�ɉ�����
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // �}�E�X�z�C�[���ŃY�[��
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // �E�N���b�N���Ă���Ԃ�����]
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            y = ClampAngle(y, yMinLimit, yMaxLimit);
        }

        // ��]�v�Z
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + targetPosition;

        transform.rotation = rotation;
        transform.position = position;
    }

    // �p�x�����֐�
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
