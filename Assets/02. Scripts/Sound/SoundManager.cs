using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] List<AudioClip> bgmClipList;
    [SerializeField] List<AudioClip> sfxClipList;
    [SerializeField] float fadeVolumeTime = 3f;

    // �̱���
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource GetBgmSource()
    {
        return bgmSource;
    }

    /// BGM
    public void SetBGM(string clipName)
    {
        bgmSource.clip = bgmClipList.Find(clip => clip.name == clipName);
    }

    public void PlayBGM()
    {
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void FadeInBGM()
    {
        StartCoroutine(FadeInVolume(bgmSource));
    }

    public void FadeOutBGM()
    {
        StartCoroutine(FadeOutVolume(bgmSource));
    }

    /// SFX
    public void PlaySFX(string clipName)
    {
        AudioClip clipToPlay = sfxClipList.Find(clip => clip.name == clipName);

        sfxSource.Stop();
        sfxSource.PlayOneShot(clipToPlay);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    /// ���� ���̵���
    private IEnumerator FadeInVolume(AudioSource audio)
    {
        float targetVolume = 1f;
        float currentTime = 0f;

        audio.volume = 0;
        audio.Play();

        while (currentTime < fadeVolumeTime)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(0f, targetVolume, currentTime / fadeVolumeTime);
            yield return null;
        }

        audio.volume = targetVolume;
    }

    /// ���� ���̵�ƿ�
    private IEnumerator FadeOutVolume(AudioSource audio)
    {
        float startVolume = audio.volume;
        float currentTime = 0f;

        while (currentTime < fadeVolumeTime)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeVolumeTime);
            yield return null;
        }

        audio.volume = 0f;
        audio.Stop();
    }
}
