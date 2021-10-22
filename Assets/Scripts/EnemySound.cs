using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemySound : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource SlimeAudio;
    [SerializeField] private AudioSource GhostAudio;
    [SerializeField] private AudioSource ChestAudio;

    public void PlaySlime() { SlimeAudio.Play(); Debug.Log("Playing"); }
    public void PlayGhost() { GhostAudio.Play(); Debug.Log("Playing"); }
    public void PlayChest() { ChestAudio.Play(); }
    public void PlaySFX(AudioSource _audio) { _audio.Play(); }

}
