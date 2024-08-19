using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    ParticleSystem particle;

    void Start()
    {
        particle = GameObject.Find("Hit Particle").GetComponent<ParticleSystem>();
    }

    public void EmitHitParticle(int particleCount, Transform hitObject)
    {
        var shape = particle.shape;
        shape.radius = hitObject.localScale.magnitude;
        particle.transform.position = hitObject.position;
        particle.Emit(particleCount);
    }
}
