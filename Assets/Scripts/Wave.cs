using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public Text[] letters;           // 每個 Text 對應一個字母
    public float waveSpeed = 3f;
    public float waveHeight = 20f;

    void Update()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            Vector3 pos = letters[i].rectTransform.anchoredPosition;
            pos.y = Mathf.Sin(Time.time * waveSpeed + i * 0.3f) * waveHeight;
            letters[i].rectTransform.anchoredPosition = pos;
        }
    }
}