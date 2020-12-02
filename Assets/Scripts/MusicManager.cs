using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// for playing music, modifying volume, transitioning music
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource musicSource;

    [SerializeField]
    AudioClip[] tracklist;

    public enum Track
    {
        Overworld,
        TransitionSFX,
        Battle
    }


    void Awake() {
        // PlayOverworldMusic();    
    }


    public void PlayTrack(MusicManager.Track trackID)
    {
        musicSource.clip = tracklist[(int)trackID];
        musicSource.Play();
    }


    public void PlayEncounterTransition()
    {
        if (musicSource.clip != tracklist[1])
        {
            PlayTrack(Track.TransitionSFX);

        }
    }

    public void PlayBattleSceneMusic()
    {
        if (musicSource.clip != tracklist[2])
        {
            PlayTrack(Track.Battle);
        }
    }

    public void PlayOverworldMusic()
    {
        if (musicSource.clip != tracklist[0])
        {
            PlayTrack(Track.Overworld);

        }
    }
    

}
