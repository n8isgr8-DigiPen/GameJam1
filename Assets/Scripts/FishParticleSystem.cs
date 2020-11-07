using UnityEngine;
using System.Collections;

public class FishParticleSystem : MonoBehaviour
{
    ParticleSystemRenderer myPS;
    public Material[] fish;
    
    // Use this for initialization
    void Start()
    {
        myPS = GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myPS.material = fish[Random.Range(0, fish.Length)];
    }
}
