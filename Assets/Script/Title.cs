using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    TMP_Text textMesh;
    public float waveSpeed = 4f;
    public float waveHeight = 40f;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMesh.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int index = textInfo.characterInfo[i].vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            float offsetY = Mathf.Sin(Time.time * waveSpeed + i * 0.3f) * waveHeight;

            vertices[index + 0].y += offsetY;
            vertices[index + 1].y += offsetY;
            vertices[index + 2].y += offsetY;
            vertices[index + 3].y += offsetY;
        }

        // §ó·s mesh
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
