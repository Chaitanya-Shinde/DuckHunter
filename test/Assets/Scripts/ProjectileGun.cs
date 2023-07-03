using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public PlayerInputAsset playerInput;
    public GameObject bullet;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    public int bulletsLeft, bulletsShot;

    public Rigidbody playerRb;
    public float recoilForce;

    public bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    public bool allowInvoke = true;

    

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Start()
    {
        playerInput = new PlayerInputAsset();
        
        playerInput.Player.Enable();
        playerInput.Player.Fire.performed += Fire;
        playerInput.Player.Reload.performed += Reload;
    }

    private void Update()
    {
        MyInput();
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }



    public void Fire(InputAction.CallbackContext context)
    {
        shooting = true;
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (context.performed && bulletsLeft < magazineSize && !reloading)
        {
            //reloading = true;
            Reload();
            Debug.Log("reloading....");
        }
    }

   
    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); 

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); 

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); 
        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;
        
        if (allowInvoke)
        {
            
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
            
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
            Debug.Log("we are the japanese goblin");
        }
        shooting = false;


    }
    private void ResetShot()
    {
        shooting = false;
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
