using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume = 1f;
    public void PlayShootingClip() {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamgeClip() {
        PlayClip(damageClip, damageVolume);
    }

    private void PlayClip(AudioClip clip, float clipVolume) {
        if (clip == null)
            return;
        Vector2 audioPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, audioPos, clipVolume);
    }
}
