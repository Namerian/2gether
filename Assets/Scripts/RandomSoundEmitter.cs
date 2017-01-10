using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundEmitter : MonoBehaviour
{
    public AudioClip[] M_audioClips;

    private AudioSource m_audioSource;

    // Use this for initialization
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            m_audioSource.clip = M_audioClips[Random.Range(0, M_audioClips.Length)];
            m_audioSource.Play();
        }
    }
}
