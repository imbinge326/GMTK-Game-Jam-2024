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
    private Collider2D CheckHitObject(RaycastHit2D hit)
    {
        var hitObject = hit.collider;
        if (hitObject != null)
        {
            // Check if the object hit has a specific tag
            if (hitObject.CompareTag("Item") && hitObject.GetComponent<ObjectMultiplier>() != null)
            {
                ObjectMultiplier multiplier = hitObject.GetComponent<ObjectMultiplier>();
                CheckMultiplier(multiplier);

                return hitObject;
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
        var hitObj = CheckHitObject(hit);

        if (hitObj != null)
        {
            ObjectMultiplier multiplier = hitObj.GetComponent<ObjectMultiplier>();
            if (multiplier.enlargeCount < 3)
            {
                Transform hitTransform = hitObj.transform;

                hitTransform.localScale *= enlargeSize * enlargeMultiplier;
                multiplier.enlargeCount++;
                multiplier.shrinkCount--;

                EmitParticle(hitTransform);
                PlayAudio(hitTransform, 0); // 0 is the order in the list for enlarge sound

                if (multiplier.enlargeCount > 3)
                {
                    multiplier.enlargeCount = 3;
                }
            }
        }
    }

    public void ShrinkShoot(float shrinkSize)
    {
        var hitObj = CheckHitObject(hit);

        if (hitObj != null)
        {
            ObjectMultiplier multiplier = hitObj.GetComponent<ObjectMultiplier>();
            if (multiplier.shrinkCount < 3)
            {
                Transform hitTransform = hitObj.transform;
                hitTransform.localScale *= shrinkSize / shrinkMultiplier;
                multiplier.shrinkCount++;
                multiplier.enlargeCount--;

                EmitParticle(hitTransform);
                PlayAudio(hitTransform, 1); // 1 is the order in the list for shrink sound

                if (multiplier.shrinkCount > 3)
                {
                    multiplier.shrinkCount = 3;
                }
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
