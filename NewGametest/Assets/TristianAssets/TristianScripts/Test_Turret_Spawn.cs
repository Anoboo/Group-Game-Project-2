using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Turret_Spawn : MonoBehaviour
{
    public GameObject coinPrefab;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            PutCoin(Input.mousePosition);
    }

    public void PutCoin(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        GameObject.Instantiate(coinPrefab, hit.point, Quaternion.identity);
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}
