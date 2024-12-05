using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float projectileForce = 1000.0f;
    public GameObject proj;
    public AudioClip pew;
    public AudioSource audio;
    public bool hasKey = false;

    // door
    public float doorOpenSpeed = 2f; // Kecepatan membuka pintu
    private bool doorOpen = false; // Status apakah pintu sedang membuka
    private Transform door; // Referensi pintu
    private Vector3 targetDoorPosition; // Posisi target pintu

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        pew = Resources.Load<AudioClip>("error");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) //This controls forward
        {
            rb.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A)) //This controls left
        {
            rb.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))//This controls back
        {
            rb.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))//This controls right
        {
            rb.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if (doorOpen && door != null)
        {
            door.position = Vector3.MoveTowards(door.position, targetDoorPosition, Time.deltaTime * doorOpenSpeed);
        }
    }
    void Fire()
    {
        //CREATE proj
        //Posisi: gameObject.transform.position (player)
        //Rotasi: Quaternion.identity (vector 4D, q0, q1, q2, q3 => 1,0,0,0 tidak ada rotasi)
        GameObject p = Instantiate(proj, gameObject.transform.position, Quaternion.identity) as GameObject;
        
        //DIBERI GAYA F, addForce,
        //Ada massa peluru: proj, rigidbody, massa unity
        p.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileForce); //Vector3.forward = arah sb.z
        //Umur peluru 5s
        Destroy(p, 5.0f);

        audio.PlayOneShot(pew);
        //GetComponent<AudioSource>().PlayOneShot(pew);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            hasKey = true;
        }

        if (other.gameObject.tag == "Win") // player menekan -> win
        {
            //Application.LoadLevel("win");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LockedDoor") && hasKey && !doorOpen)
        {
            Debug.Log("Membuka pintu...");

            // Atur pintu untuk mulai membuka
            door = other.transform;
            targetDoorPosition = door.position + new Vector3(5f, 0, 0); // Geser 5 unit ke kanan
            doorOpen = true;
        }
    }
}
