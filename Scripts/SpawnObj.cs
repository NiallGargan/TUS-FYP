using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject objPrefab;
    public float objCooldown;
    public bool readyToFire;
    public KeyCode fire = KeyCode.Mouse0;

    // Start is called before the first frame update
    void Start()
    {
        readyToFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if fire button is pressed and its ready to fire, shoot and ivoke resetfireball after 2 seconds
        if (Input.GetKey(fire) && readyToFire)
        {
            readyToFire = false;
            Shoot();

            Invoke(nameof(ResetObj), objCooldown);

        }

    }

    void Shoot()
    {
        //spawn in object
        Instantiate(objPrefab, transform.position, Quaternion.identity);
    }

    private void ResetObj()
    {
        readyToFire = true;
    }
}
