using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Target : MonoBehaviour
{
    // breytur
    public float health = 50f; // lífið á afturgönguni
    public static int count; // breyta sem tilheyrir eingöngu klassanum
    private bool alive = true;

    public Animator animator;
    public AudioSource zombiehit;

    void Start()
    {
        // sækir componenta
        animator = GetComponent<Animator>();
        zombiehit = GetComponent<AudioSource>();
    }

    // fall til að minnka lífi hjá afturgöngum
    // fallið lokar leiknum ef allar afturgöngur er dauðar
    public void TakeDamage (float amount)
    {
        if (alive) // gáir hvort að afturganga er lifandi
        {
            health -= amount;
            zombiehit.Play(); // spilar hljóð
            if (health <= 0f) // gáir hvort að lífið sé minna eða jafnt og 0 á afturgönguni
            {
                alive = false;
                animator.SetBool("isDead", true); // lætur afturgönguna spila dauða hreyfingar
                Destroy(gameObject, 0.7f); // eyðir afturgönguna eftir 0.7 sek
                count += 1;
                if (count == 20) // gáir hvort að spilarinn er búinn að drepa 20 afturgöngur
                {
                    SceneManager.LoadScene("Win"); // hleður Win sceneinu
                }
            }
        }

    }
}
