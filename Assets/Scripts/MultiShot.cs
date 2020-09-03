using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiShot : MonoBehaviour
{
    
    public Animator animator;
    public GameObject scopeOverlay;
    private bool isScoped = false;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 200f;
    public AudioSource awmSound;
    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadingTime = 2f;
    private bool isReloading = false;
    public int totalBullets = 25;
    public Text ammo;
    public GameObject noScopeCrossHair;

    private void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
        ammo.text = currentAmmo + "/" + totalBullets;
    }

    private void Update()
    {
        if (isReloading)
        {
            animator.SetBool("Scoped", false);
            OnUnScoped();
            return;
        }

        if (isScoped)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                mainCamera.fieldOfView -= 2;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                mainCamera.fieldOfView += 2;
            }
        }

        if (currentAmmo <= 0)
        {
            if (totalBullets == 0)
            {
                return;
            }
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (!isScoped)
            {
                animator.SetBool("Scoped", true);
                isScoped = true;
                StartCoroutine(OnScoped());

            }
            else
            {
                animator.SetBool("Scoped", false);
                isScoped = false;
                OnUnScoped();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= reloadingTime)
            {
                Shoot();
            }
        }
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        noScopeCrossHair.SetActive(false);
        mainCamera.fieldOfView = 15;
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        noScopeCrossHair.SetActive(true);
        mainCamera.fieldOfView = 60;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        awmSound.Play();
        currentAmmo--;
        totalBullets--;
        ammo.text = currentAmmo + "/" + totalBullets;
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 0.1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadingTime);
        isReloading = false;
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        ammo.text = currentAmmo + "/" + totalBullets;
    }

    public void UpdateAmmoOnGUI()
    {
        ammo.text = currentAmmo + "/" + totalBullets;
    }
}
