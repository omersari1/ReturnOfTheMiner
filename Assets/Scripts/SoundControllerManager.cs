using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    pickAxe,
    swordHit,
    startingSound,
    playingSound,
    clickSound,
    meltingSound,
    SwordCreateSound,
    DieSound,
    danceSound,
}
public class SoundControllerManager : MonoBehaviour
{
    public static SoundControllerManager instance;

    public AudioListener sceneAudioListener;
    [SerializeField]
    private AudioSource pickAxe;
    [SerializeField]
    private AudioSource swordHit;
    [SerializeField]
    private AudioSource startingSound;
    [SerializeField]
    private AudioSource playingSound;
    [SerializeField]
    private AudioSource clickSound;
    [SerializeField]
    private AudioSource meltingSound;
    [SerializeField]
    private AudioSource SwordCreateSound;
    [SerializeField]
    private AudioSource DieSound;
    [SerializeField]
    private AudioSource danceSound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Play(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.clickSound:
                clickSound?.Play();
                break;
            case SoundType.startingSound:
                startingSound?.Play();
                break;
            case SoundType.playingSound:
                playingSound?.Play();
                break;
            case SoundType.pickAxe:
                pickAxe?.Play();
                break;
            case SoundType.swordHit:
                swordHit?.Play();
                break;
            case SoundType.meltingSound:
                meltingSound?.Play();
                break;
            case SoundType.DieSound:
                DieSound?.Play();
                break;
            case SoundType.SwordCreateSound:
                SwordCreateSound?.Play();
                break;
            case SoundType.danceSound:
                danceSound?.Play();
                break;

            default:
                break;
        }
    }
    public void Stop(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.clickSound:
                clickSound?.Stop();
                break;
            case SoundType.startingSound:
                startingSound?.Stop();
                break;
            case SoundType.playingSound:
                playingSound?.Stop();
                break;
            case SoundType.pickAxe:
                pickAxe?.Stop();
                break;
            case SoundType.swordHit:
                swordHit?.Stop();
                break;
            case SoundType.meltingSound:
                meltingSound?.Stop();
                break;
            case SoundType.DieSound:
                DieSound?.Stop();
                break;
            case SoundType.SwordCreateSound:
                SwordCreateSound?.Stop();
                break;
            case SoundType.danceSound:
                danceSound?.Stop();
                break;
            default:
                break;
        }
    }

}
