using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SphereMove : MonoBehaviour
   
{

    // Start is called before the first frame update
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    private bool countdown;
    private float timer;
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Time.timeScale == 0) { 
                Time.timeScale = 1;
                pauseObject.SetActive(false);
            } else { 
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }

        }

        float speed = 10 * Time.deltaTime;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed; 
        float vertMove = Input.GetAxisRaw("Vertical") * speed; 
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Q)) {
            countdown = true;
        }

        if (countdown) { 
            if (timer < 3) { 
                timer += Time.deltaTime; 
            } else { 
                UnityEditor.EditorApplication.isPlaying = false; } }




    }

    private void OnTriggerEnter(Collider other)
    {
        float newX = Random.Range(-12, 12); 
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0, newZ);
        score++;
        scoreText.text = "Score: " +score;


    }
}
