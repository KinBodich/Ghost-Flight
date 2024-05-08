using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManagement : MonoBehaviour
{
    private ParticleSystem _explosionParticle;
    public bool ReadyToShow { get; set; }

    private void Start()
    {
        _explosionParticle = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (transform.parent)
            return;

        transform.Translate(Vector3.forward * Time.deltaTime * 100);

        if (ReadyToShow)
        {
            ShowExplosion();
            ReadyToShow = false;
        }
    }

    private void ShowExplosion()
    {
        _explosionParticle.Play();
        
        StartCoroutine(ExplosionDuration());
    }

    private IEnumerator ExplosionDuration()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
