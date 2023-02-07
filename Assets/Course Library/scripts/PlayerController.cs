using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier = 10;
    private bool isStay = true;
    private bool gameOver = false;
    public float speedModifier = 1.0005f;
    Animator playrAnim;
    spawnManager sm;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down * gravityModifier * 9.8f;
        Time.timeScale = 1;
        playrAnim = GetComponent<Animator>();
        sm = FindObjectOfType<spawnManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isStay == true )
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playrAnim.SetTrigger("Jump_trig");
            isStay = false;
        }
        playrAnim.SetFloat("Speed_Mult", playrAnim.GetFloat("Speed_Mult") * speedModifier);
        sm.speedModifier *= speedModifier;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isStay = true;
        }
        else if(collision.gameObject.tag == "obstacle")
        {
            
            foreach (var ml  in FindObjectsOfType<moveLeft>())
            {
                Destroy(ml);
            }
            Destroy(FindObjectOfType<spawnManager>());

            playrAnim.SetBool("Death_b", true);
            playrAnim.SetInteger("DeathType_int", 1);

            StartCoroutine(ReloadLevel());
        }
        
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }

}
