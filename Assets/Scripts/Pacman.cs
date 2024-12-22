using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Pacman : MonoBehaviour
{
    public int coins = 0, hearts = 5, score = 0;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Material orange, yellow, blue;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;
    private Vector3 PacInitialPosition, GhostInitialPosition;
    private bool canMove = true, isRed = false;
    private int angle = 0;
    private AudioSource eatSoundAudioSource;
    private AudioSource deathSoundAudioSource;
    public AudioClip eatSound;
    public AudioClip deathSound;
    private bool playDeathSound = false;
    private bool canPlayEatSound = true;
    private float eatSoundCooldown = 1.5f; // Adjust this value as needed
    private int remainingCoins;
    private bool isAudioMuted = false;


    private void Start()
    {        
        PacInitialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = yellow;
        eatSoundAudioSource = GetComponent<AudioSource>();
        deathSoundAudioSource = GetComponent<AudioSource>();
        remainingCoins = GameObject.FindGameObjectsWithTag("Coin").Length;



    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canMove)
        {
            // Handle movement logic
            rb.velocity = moveDirection.normalized * moveSpeed;

            if (horizontalInput > 0)
            {
                moveDirection = Vector3.right;
                angle = 90;
            }
            else if (horizontalInput < 0)
            {
                moveDirection = Vector3.left;
                angle = -90;
            }
            else if (verticalInput > 0)
            {
                moveDirection = Vector3.forward;
                angle = 0;
            }
            else if (verticalInput < 0)
            {
                moveDirection = Vector3.back;
                angle = 180;
            }
            transform.rotation = Quaternion.Euler(0, angle, 0);

            //    // Check if the moveSound audio clip is assigned
            //    if (moveSound != null)
            //    {
            //        // Check if the audio source is not playing to prevent overlapping
            //        if (!audioSource.isPlaying)
            //        {
            //            // Set the audio clip and play it
            //            audioSource.clip = moveSound;
            //            audioSource.Play();
            //        }
            //    }
            //}
            //else
            //{
            //    // Stop the audio if Pacman can't move
            //    audioSource.Stop();
        }
    }

    private void LoadCongradulationScene()
    {
        // Replace "CongratulationsSceneName" with the name of your congratulations scene
        SceneManager.LoadScene("Congradulation");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Cherry(collision);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin(collision);
        }
        if (collision.gameObject.CompareTag("PowerPellet"))
        {
            StartCoroutine(PowerPellet(collision));
        }
        if (collision.gameObject.CompareTag("Ghost"))
        {
            StartCoroutine(Ghost(collision));
        }
    }

    private void Cherry(Collision collision)
    {
        Destroy(collision.gameObject);
        score += 2000;
    }

    private void Coin(Collision collision)
    {
        // Check if enough time has passed since the last time the eat sound played
        if (canPlayEatSound)
        {
            // Stop the eat sound if it's currently playing
            if (eatSoundAudioSource.isPlaying)
            {
                eatSoundAudioSource.Stop();
            }

            // Play the eat sound
            eatSoundAudioSource.clip = eatSound;
            eatSoundAudioSource.Play();

            // Set the cooldown to prevent the sound from playing immediately again
            canPlayEatSound = false;
            StartCoroutine(ResetEatSoundCooldown());
        }

        remainingCoins--;
        Destroy(collision.gameObject);
        coins++;
        score += 50;
        if (remainingCoins == 0 && hearts > 0)
        {
            // All coins are destroyed and there are still hearts remaining
            LoadCongradulationScene();
        }
    }

    private IEnumerator ResetEatSoundCooldown()
    {
        yield return new WaitForSeconds(eatSoundCooldown);
        canPlayEatSound = true;
    }

    private IEnumerator PowerPellet(Collision collision)
    {
        Destroy(collision.gameObject);
        score += 200;
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            isRed = true;
            renderer.material = orange;

            yield return new WaitForSeconds(8f);

            isRed = false;
            renderer.material = yellow;
        }
    }

    private IEnumerator Ghost(Collision collision)
    {
        if (isRed)
        {
            collision.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            collision.gameObject.transform.position = GhostInitialPosition;
            score += 500;

            yield return new WaitForSeconds(5f);

            collision.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;

        }
        else if (!isRed && hearts >= 1)
        {
            playDeathSound = true;

            if (eatSoundAudioSource.isPlaying)
            {
                eatSoundAudioSource.Stop();
            }
            if (!deathSoundAudioSource.isPlaying)
            {
                deathSoundAudioSource.clip = deathSound;
                deathSoundAudioSource.Play();
            }
            transform.position = PacInitialPosition;
            canMove = false;
            GetComponent<SkinnedMeshRenderer>().enabled = false;

            GameObject heartImage = GameObject.Find("Heart" + hearts);
            Destroy(heartImage);
            hearts--;
            //score -= 1000;
            //if (score <= 0)
            //{
            //    score = 0;
            //}

            yield return new WaitForSeconds(3f);

            canMove = true;
            GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        else if (hearts == 0)
        {
            Destroy(gameObject);
        }
    }
    public void ToggleAudio()
    {
        isAudioMuted = !isAudioMuted;

        if (isAudioMuted)
        {
            // Mute audio
            eatSoundAudioSource.volume = 0.0f;
            deathSoundAudioSource.volume = 0.0f;
        }
        else
        {
            // Unmute audio (adjust volume as needed)
            eatSoundAudioSource.volume = 1.0f;
            deathSoundAudioSource.volume = 1.0f;
        }
    }


}

//canMove = false;
//GetComponent<SkinnedMeshRenderer>().enabled = false;
//GetComponent<SphereCollider>().enabled = false;
//transform.position = PacInitialPosition;

