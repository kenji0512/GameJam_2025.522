using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCon : MonoBehaviour
{
    [SerializeField]
    AudioClip _audioClip;

    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }


}
