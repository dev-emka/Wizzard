using UnityEngine;

public class Level1SoundManager : MonoBehaviour
{
    [SerializeField]AudioClip backgroundClip;
    [SerializeField] AudioSource backGroundSource;
    public static bool IsmusicOn;

    private void Awake()
    {
        IsmusicOn = PlayerPrefs.GetString("ismusicon") == "true" ? true : false;
    }

    private void Update()
    {
        IsmusicOn = PlayerPrefs.GetString("ismusicon") == "true" ? true : false;

        if (IsmusicOn && !backGroundSource.isPlaying)
        {
            backGroundSource.clip = backgroundClip;
            backGroundSource.Stop();
            backGroundSource.Play();
        }else if (!IsmusicOn)
        {
            backGroundSource.Stop();
        }
    }
}
