using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Collider2D ChangeScene;
    public string NextStageScene;
    public Button StartScene;
    public string SceneA;

    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public void MoveA()
    {
        SceneManager.LoadScene(SceneA);
    }

    public void MoveLoadNextSceneB()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneA);
        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }

    ////コライダ―に入ったらscene切替
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneA);
    }
    public void MoveLoadNextSceneC()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextScene());
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーなど、特定のタグを持つオブジェクトが入った場合にシーンを移行
        if (other.CompareTag("Player") || other.CompareTag("Player"))  // "Player"タグがついたオブジェクトで判定
        {
            Debug.Log("Player entered trigger, switching scene.");
            SceneManager.LoadScene(NextStageScene);  // シーンを切り替える
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");

        SceneManager.LoadScene(NextStageScene);
    }
}
