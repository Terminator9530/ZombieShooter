using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ScrollUp();
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ScrollDown();
        }
    }

    private void ScrollDown()
    {
        if(selectedWeapon >= transform.childCount - 1)
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon++;
        }
        SelectWeapon();
    }

    private void ScrollUp()
    {
        if (selectedWeapon <= 0)
        {
            selectedWeapon = transform.childCount - 1;
        }
        else
        {
            selectedWeapon--;
        }
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        
        foreach(Transform weapon in transform)
        {
            

            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                if(weapon.tag == "OneShot")
                {
                    weapon.GetComponent<OneShot>().noScopeCrossHair.SetActive(true);
                }

                if (weapon.tag == "MultiShot")
                {
                    weapon.GetComponent<MultiShot>().noScopeCrossHair.SetActive(true);
                }
            }
            else
            {
                weapon.gameObject.SetActive(false);
                if (weapon.tag == "OneShot")
                {
                    weapon.GetComponent<OneShot>().noScopeCrossHair.SetActive(false);

                }

                if (weapon.tag == "MultiShot")
                {
                    weapon.GetComponent<MultiShot>().noScopeCrossHair.SetActive(false);
                }
            }
            i++;
        }
    }
}
