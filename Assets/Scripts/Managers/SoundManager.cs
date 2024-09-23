using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> sounds;
        public void Play(int count)
    {
        sounds[count].Play();
    }
}