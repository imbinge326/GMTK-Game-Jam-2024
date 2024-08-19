using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    ParticleManager particleManager;
    SoundManager soundManager;
    TextMeshProUGUI magazineText;

    // Can remove SerializeField and just make the fields private
    [Header("Shot Counter")]
    [SerializeField] private int enlargeCount = 0;
    [SerializeField] private int shrinkCount = 0;
    public int magazine = 7;

    [Header("Multipliers")]
    // Public so that outside script can alter
    public float enlargeMultiplier = 1f;
    public float shrinkMultiplier = 1f;

    private RaycastHit2D hit;

    private Camera mainCamera;
   
    void Awake()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;

        particleManager = GetComponent<ParticleManager>();
        soundManager = GameObject.Find("Sound Emitter").GetComponent<SoundManager>();
        magazineText = GameObject.Find("Bullet Count").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        transform.position = worldPosition;

        magazineText.text = (magazine + " | 7");
    }
    private Transform CheckHitObject(RaycastHit2D hit)
    {
        var hitObject = hit.collider;
        if (hitObject != null)
        {
            // Check if the object hit has a specific tag
            if (hitObject.CompareTag("Item"))
            {
                Transform hitTransform = hitObject.transform;

                if (hitObject.GetComponent<ObjectMultiplier>() != null)
                {
                    ObjectMultiplier multiplier = hitObject.GetComponent<ObjectMultiplier>();
                    CheckMultiplier(multiplier);
                }
                else
                {
                    enlargeMultiplier = 1f;
                    shrinkMultiplier = 1f;
                }

                return hitTransform;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    void CheckMultiplier(ObjectMultiplier multiplier)
    {
        enlargeMultiplier = multiplier.enlargeMultiplier;
        shrinkMultiplier = multiplier.shrinkMultiplier;
    }

    public void EnlargeShoot(float enlargeSize)
    {
        Transform hitTransform = CheckHitObject(hit);
        if (hitTransform != null && enlargeCount < 3)
        {
            hitTransform.localScale *= enlargeSize * enlargeMultiplier;
            enlargeCount++;
            shrinkCount--;
            magazine--;

            EmitParticle(hitTransform);
            PlayAudio(hitTransform, 0); // 0 is the order in the list for enlarge sound

            if (enlargeCount > 3)
            {
                enlargeCount = 3;
            }
        }
    }

        public void ShrinkShoot(float shrinkSize)
    {
        Transform hitTransform = CheckHitObject(hit);
        if (hitTransform != null && shrinkCount < 3)
        {
            hitTransform.localScale *= shrinkSize / shrinkMultiplier;
            shrinkCount++;
            enlargeCount--;
            magazine--;

            EmitParticle(hitTransform);
            PlayAudio(hitTransform, 1); // 1 is the order in the list for shrink sound

            if (shrinkCount > 3)
            {
                shrinkCount = 3;
            }
        }
    }

    void EmitParticle(Transform hitTransform)
    {
        particleManager.EmitHitParticle(50, hitTransform); // Replace 50 with number of particles to emit
    }

    void PlayAudio(Transform hitTransform, int audioClipNum)
    {
        soundManager.EmitSound(audioClipNum, hitTransform);
    }
}
