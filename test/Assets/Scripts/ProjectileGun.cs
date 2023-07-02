using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public PlayerInputAsset playerInput;
    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    public int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    public bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    /*private void OnEnable()
    {
        playerInput.Player.Fire.performed += Fire;
        playerInput.Player.Reload.performed += Reload;
    }*/
    private void Start()
    {
        playerInput = new PlayerInputAsset();
        //playerInput.LevelSelect.Disable();
        
        playerInput.Player.Enable();
        playerInput.Player.Fire.performed += Fire;
        playerInput.Player.Reload.performed += Reload;
    }

    private void Update()
    {
        MyInput();

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;
            //Debug.Log("we are firing continuously lol");
            Shoot();
        }
    }



    //!
    public void Fire(InputAction.CallbackContext context)
    {

        shooting = true;


        

    }

    //@
    public void Reload(InputAction.CallbackContext context)
    {
        if (context.performed && bulletsLeft < magazineSize && !reloading)
        {
            //reloading = true;
            Reload();
            Debug.Log("reloading....");
        }

        /*if (context.canceled)
        {
            reloading = false;
        }*/
    }

    /* public void Shoot(InputAction.CallbackContext context)
     {
         if (allowButtonHold)
             shooting = context.ReadValue<bool>();
         else
             shooting = context.ReadValue<bool>();

     }
 */
    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        //!@#currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;
        
        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            
            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
            
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
            Debug.Log("we are the japanese goblin");
        }
        shooting = false;


    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        shooting = false;
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
