using UnityEngine;

public class KaitenYuka : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 30f); // �C����ਤ�� (Z�b)

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
