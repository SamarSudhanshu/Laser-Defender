using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 1f;

    [Header("AI")]
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.2f;
    [SerializeField] private bool useAI;
    private Coroutine firingCoroutine;
    [HideInInspector] public bool isFiring;

    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }

    private void Start() {
        if(useAI)
            isFiring = true;
    }
    private void Update() {
        Fire();
    }

    private void Fire() {
        if (isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FiringContiuosly());
        else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FiringContiuosly() {
        while (true) {
            GameObject instance = Instantiate(projectilePrefab, 
                                                transform.position, 
                                                Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, 
                                                        baseFiringRate + firingRateVariance);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(Mathf.Clamp(timeToNextProjectile, 
                                                            minimumFiringRate, 
                                                            float.MaxValue));
            
        }
    }
}
