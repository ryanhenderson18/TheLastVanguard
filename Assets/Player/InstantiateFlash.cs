using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFlash : MonoBehaviour
{
    public GameObject muzzleFlash;
    private float fireRate = 1.0f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate && (Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)))
        {
            GameObject flash = Instantiate(muzzleFlash, transform.position, transform.rotation);
            Destroy(flash, 0.25f);
            timer = 0f;
        }
    }
}
