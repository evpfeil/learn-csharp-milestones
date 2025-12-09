using UnityEngine;
using System.Collections.Generic;

public class LearningCurve : MonoBehaviour
{
    public int level = 1;
    private float experience = 0f;
    public string playerName = "Player";
    private bool isActive = true;
    private List<string> itemList = new List<string> { "a", "b", "c" };
    private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>()
    {
        { "Evan", 10 },
        { "Hannah", 20 },
        { "Avi", 15 }
    };

    // --- Chapter 7: Movement variables ---
    public float moveSpeed = 5f;
    public float rotateSpeed = 90f;

    // For physics movement
    private Rigidbody rb;
    public float physicsMoveSpeed = 3f;

    // --- Chapter 8: Shooting ---
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed = 10f;

    void Start()
    {
        Debug.Log("Integer " + level);
        Debug.LogFormat("Float {0}", experience);
        Debug.Log($"String {playerName}");

        int sum = AddTwoNumbers(5, 7);
        Debug.Log("AddTwoNumbers result: " + sum);

        PrintThingy("j");

        int testValue = 67;

        if (testValue > 67)
        {
            Debug.Log("Greater than six seven");
        }
        else if (testValue == 67)
        {
            Debug.Log("Six Sevennnn");
        }
        else
        {
            Debug.Log("Less than six seven");
        }

        bool isReady = true;
        if (isReady)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }

        int score = 95;
        if (score >= 90)
        {
            if (score == 100)
            {
                Debug.Log("Perfect score!");
            }
            else
            {
                Debug.Log("You got an A!");
            }
        }

        string grade = "B";
        switch (grade)
        {
            case "A":
                Debug.Log("Excellent!");
                break;
            case "B":
                Debug.Log("Good work!");
                break;
            case "C":
                Debug.Log("Average.");
                break;
            default:
                Debug.Log("Needs improvement.");
                break;
        }
        int[] arr = { 10, 20, 30 };

        Debug.Log("Items in itemList:");
        foreach (string item in itemList)
        {
            Debug.Log(item);
        }

        Debug.Log("Dictionary contents:");
        foreach (KeyValuePair<string, int> pair in scoreDictionary)
        {
            Debug.Log($"Key: {pair.Key}, Value: {pair.Value}");
        }

        for (int i = 0; i < itemList.Count; i++)
        {
            Debug.Log($"Item at index {i}: {itemList[i]}");
        }
        foreach (string item in itemList)
        {
            Debug.Log("List item: " + item);
        }
        foreach (var pair in scoreDictionary)
        {
            Debug.Log($"Name: {pair.Key}, Score: {pair.Value}");
        }

        // ============================
        //   CHAPTER 5 — CLASSES
        // ============================

        Character hero = new Character("HeroName", 12);
        Character heroine = new Character("HeroineName", 10);

        hero.PrintStatsInfo();
        heroine.PrintStatsInfo();

        // ============================
        //   CHAPTER 5 — STRUCTS
        // ============================

        Weapon huntingBow = new Weapon("Hunting Bow", 15);
        Weapon warBow = new Weapon("War Bow", 30);

        Debug.Log($"Weapon 1: {huntingBow.weaponName}, Damage: {huntingBow.damage}");
        Debug.Log($"Weapon 2: {warBow.weaponName}, Damage: {warBow.damage}");

        // ============================
        //   CHAPTER 5 — CHILD CLASSES
        // ============================

        Paladin knight = new Paladin("Sir Roland", 20, new Weapon("Holy Blade", 50));
        knight.PrintStatsInfo();

        // ============================
        //   CHAPTER 5 — REFERENCING OBJECTS
        // ============================

        Transform camTransform = GetComponent<Transform>();
        Debug.Log($"Camera Local Position: {camTransform.localPosition}");

        GameObject lightObj = GameObject.Find("Directional Light");
        Transform lightTransform = lightObj.GetComponent<Transform>();
        Debug.Log($"Light Local Position: {lightTransform.localPosition}");

        // ============================
        //   CHAPTER 7 — PHYSICS SETUP
        // ============================
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ============================
        //   CHAPTER 7 — MOVEMENT
        // ============================

        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        // Position vector vs. direction vector
        Vector3 direction = new Vector3(0, 0, move);

        transform.Translate(direction * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime);

        // ============================
        //   CHAPTER 8 — SHOOTING
        // ============================

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proj = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Rigidbody projRB = proj.GetComponent<Rigidbody>();

            projRB.linearVelocity = projectileSpawnPoint.forward * projectileSpeed;

            Destroy(proj, 3f);
        }
    }

    void FixedUpdate()
    {
        // ============================
        //   CHAPTER 7 — PHYSICS MOVEMENT
        // ============================

        if (rb != null)
        {
            Vector3 move = transform.forward * physicsMoveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger of: " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited trigger of: " + other.gameObject.name);
    }

    void PrintThingy(string message)
    {
        Debug.Log(message);
    }

    int AddTwoNumbers(int a, int b)
    {
        return a + b;
    }
}
