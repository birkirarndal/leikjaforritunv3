using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemychase : MonoBehaviour
{
    // breytur
    private int obstacleRange = 3;
    private int moveSpeed = 2;
    private int MinDist = 10;

    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        // finnur transform á gameobject sem er með Player tag
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ef fjarlægðinn á afturgönguni og spilaranum er minna eða jafn og 10
        if (Vector3.Distance(transform.position, Player.transform.position) <= MinDist)
        {
            // aftur gangan horfir á spilaran og labbar til hans
            transform.LookAt(Player);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            
        }
        // ef fjarlægðinn á afturgönguni og spilaranum er stærri en 10
        else if (Vector3.Distance(transform.position, Player.transform.position) > MinDist)
        {

            
            transform.Translate(0, 0, moveSpeed * Time.deltaTime); // hreyfir afturgönguna þegar hún sér ekki spilarann
            
            Ray ray = new Ray(transform.position, transform.forward); // finnur lengdina frá afturgönguni og gameobjecti sem er fyrir framan hana
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) // skillar true ef það hittir einhvern collider
            {
                if (hit.distance < obstacleRange) // ef lengdinn á milli gameobjectinn sem er fyrir framan afturgönguna er minna en ákveðinn lengd
                {
                    // snýr afturgöngunni frá gameobjectinum
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}
