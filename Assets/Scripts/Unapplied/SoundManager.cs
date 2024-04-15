using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject soundManagerGo = new GameObject("SoundManager");
                    instance = soundManagerGo.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeathSound(AudioClip deathSoundClip, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(deathSoundClip, position, volume);
    }
}
