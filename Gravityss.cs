using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravityss : MonoBehaviour
{
    //use this to define variables that are acc being used!!!

    //test variables
    public float ForceMagnitude;
    public float Accel;
    public float whereis;
    public float t;
    public float aphel;
    public float bphel;
    public float timeperiod;
    public float vel;

    public Vector3 initialvelocity;
    const float G = 6.674e-4f; //used to speed up gravity process


    public static List<Gravityss> Planets; //make a list of attracting bodies

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialvelocity;
        aphel = rb.position.x;
        bphel = aphel;
    }

    void FixedUpdate()
    {
        aphel = rb.position.x;
        aphel = (int)Mathf.FloorToInt (aphel);
        foreach (Gravityss planet in Planets) //this small for loop calls the attract function for each planet
        {
            if (planet != this)
                Attract(planet);
            whereis = rb.position.magnitude;
            t += Time.deltaTime;
            if (aphel == bphel )
                timeperiod = t;
            Vector3 orbvel = rb.velocity;
            vel = orbvel.magnitude;
        }
    }

    void OnEnable() //speeds up the process  by only adding features to the list when necessary
    {
        if (Planets == null) //reduces redundancies by only adding planets to a list to be used if they are new planets
            Planets = new List<Gravityss>();

        Planets.Add(this);
    }

    private void OnDisable() //removes the planet from the list after it has been used
    {
        Planets.Remove(this);
    }
    void EllipticalOrbit(Gravityss PlanetToAttract)
    {
        Vector3 displacement = rb.position;
        float seperation = displacement.magnitude;
    }
    void Attract(Gravityss PlanetToAttract)
    {
        Rigidbody rbToAttract = PlanetToAttract.rb; //considers the attracting planet as a rigidbody

        Vector3 displacement = rb.position - rbToAttract.position; //calculates the displacement between planets
        float seperation = displacement.magnitude; //calculates the seperation of planets

        ForceMagnitude = ((rb.mass * rbToAttract.mass) * G) / Mathf.Pow(seperation, 2); //calculates the magnitude of the gravity

        Vector3 force = displacement.normalized * ForceMagnitude; //converts the force into a vector
        rbToAttract.AddForce(force); //adds the force vector
        Accel = ForceMagnitude / 330000;
    }
}
