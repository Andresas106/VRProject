using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum MagicSpellType
{
    Light,
    Teleport,
    Break,
    TimeStop,
    Fireball
}


public class MagicSpellManager : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject lightPrefab;
    public Transform castPoint;

    public void CastSpell(MagicSpellType spell)
    {
        switch (spell)
        {
            case MagicSpellType.Light:
                CastLight();
                break;
            case MagicSpellType.Teleport:
                CastTeleport();
                break;
            case MagicSpellType.Break:
                CastBreak();
                break;
            case MagicSpellType.TimeStop:
                CastTimeStop();
                break;
            case MagicSpellType.Fireball:
                CastFireball();
                break;
        }
    }

    void CastLight()
    {
        Instantiate(lightPrefab, castPoint.position, Quaternion.identity);
    }

    void CastTeleport()
    {
        // Solo para pruebas, te teleporta 3m hacia adelante
        transform.position += transform.forward * 3f;
    }

    void CastBreak()
    {
        Ray ray = new Ray(castPoint.position, castPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            if (hit.collider.CompareTag("Breakable"))
                Destroy(hit.collider.gameObject);
        }
    }

    void CastTimeStop()
    {
        Time.timeScale = (Time.timeScale == 1f) ? 0f : 1f;
    }

    void CastFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, castPoint.position, castPoint.rotation);
        fireball.GetComponent<Rigidbody>().AddForce(castPoint.forward * 800f);
    }
}
