using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("Taken Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    public static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
