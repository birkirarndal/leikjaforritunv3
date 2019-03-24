using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    // breytur
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController charCont;
    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>(); // sækir component
        Cursor.lockState = CursorLockMode.Locked; // læsir músina
        Cursor.visible = false; // gerir músina ósýnilega
    }

    // Update is called once per frame
    void Update()
    {
        // fær takkana til að hreyfa spilaran
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = Vector3.ClampMagnitude(movement, speed); // takmarkar hámarkshraða á spilaranum

        movement.y = gravity; // setur þyngdarafl á spilaran

        movement *= Time.deltaTime; // lætur hraðan á spilaranum ekki breytast eftir frame ratei
        movement = transform.TransformDirection(movement);
        charCont.Move(movement);
    }
}
