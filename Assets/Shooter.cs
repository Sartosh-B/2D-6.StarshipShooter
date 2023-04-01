using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring;

    Coroutine firingCoroutine;
    private void Update()
    {
        Fire();
    }

    public void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
            Debug.Log("strzelom");
        }
        else
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            Instantiate(projectilePrefab,
            transform.position,
            Quaternion.identity);
            Destroy(projectilePrefab, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
       
    }
}
