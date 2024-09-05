using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Vector3 = UnityEngine.Vector3;

// Make sure that the GameObject running the Brain script
// will always have the ThirdPersonCharacter component.
[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    [SerializeField] int dnaLength = 1; // Num of genes.
    float timeAlive; // Survival time.
    float metersRunned; // How far it run away from start.
    Vector3 startPos; // Starting position.
    DNA dna;

    ThirdPersonCharacter bot;
    Vector3 movement;
    bool jump;
    bool alive = true;

    public DNA GetDNA()
    {
        return dna;
    }

    public float GetTimeAlive()
    {
        return timeAlive;
    }

    public float GetMetersRunned()
    {
        return metersRunned;
    }


    // bots who fall of from platform dies.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lava"))
        {
            alive = false;
        }
    }

    // Initialize dna.
    public void Init()
    {
        // 0 forward
        // 1 back
        // 2 left
        // 3 right
        // 4 jump
        // 5 crouch
        dna = new(dnaLength, 6);
        bot = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startPos = transform.position;
    }

    // Update but synchronised with physics.
    void FixedUpdate()
    {
        float h = 0; // Horizontal
        float v = 0; // Vertical
        bool crouch = false;

        // Convert gene to movement.
        switch (dna.GetGene(0))
        {
            case 0:
                v = 1;         break;
            case 1:
                v = -1;        break;
            case 2:
                h = -1;        break;
            case 3:
                h = 1;         break;
            case 4:
                jump = true;   break;
            case 5:
                crouch = true; break;
        }

        movement = v * Vector3.forward + h * Vector3.right;
        bot.Move(movement, crouch, jump); // Method from thirdpersoncharacter class.
        jump = false;

        if (alive)
        {
            timeAlive += Time.deltaTime;
            
            // Calculate distance of bot and starting point.
            metersRunned = Vector3.Distance(transform.position, startPos);
        }
    }

}