using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using Utilities;
using Random = UnityEngine.Random;

[RequireComponent(typeof(DiceSides))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class DiceRoller : MonoBehaviour
{
    [Title("Dice Rolling Settings")]
    [SerializeField] float rollForce = 50f;
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] float maxRollTime = 3f;
    [SerializeField] float minAngularVelocity = 0.1f;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float maxSpeed = 15f;

    [Title("UI References")]
    [SerializeField] TMPro.TextMeshProUGUI resultText;
    [SerializeField] GameObject inputPanel;
    [SerializeField] TMPro.TMP_InputField targetInputField;

    [Title("Audio & Particle Effects")]
    [SerializeField] AudioClip shakeClip;
    [SerializeField] AudioClip rollClip;
    [SerializeField] AudioClip impactClip;
    [SerializeField] AudioClip finalResultClip;
    [SerializeField] GameObject impactEffect;
    [SerializeField] GameObject finalResultEffect;

    DiceSides diceSides;
    AudioSource audioSource;
    Rigidbody rb;

    CountdownTimer rollTimer;

    Vector3 originPosition;
    Vector3 currentVelocity;
    bool finalize;
    int targetNumber;

    void Awake()
    {
        diceSides = GetComponent<DiceSides>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        resultText.text = "";
        originPosition = transform.position;

        rollTimer = new CountdownTimer(maxRollTime);
        rollTimer.OnTimerStart += PerformInitialRoll;
        rollTimer.OnTimerStop += () => finalize = true;

        inputPanel.SetActive(true);
    }

    public void ConfirmTargetNumber()
    {
        if (int.TryParse(targetInputField.text, out targetNumber))
        {
            resultText.text = "Rolling...";
            rollTimer.Start();
        }
        else
        {
            resultText.text = "Invalid input. Enter a number.";
            Debug.LogError("Invalid input. Please enter a valid number.");
        }
    }

    void Update()
    {
        if (rollTimer == null)
        {
            Debug.LogError("rollTimer is NULL! Check if it's initialized properly.");
            return;
        }
        rollTimer.Tick(Time.deltaTime);

        if (finalize)
        {
            MoveDiceToCenter();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (rollTimer.IsRunning && rollTimer.Progress < 0.5f && rb.angularVelocity.magnitude < minAngularVelocity)
        {
            finalize = true;
        }

        audioSource.PlayOneShot(impactClip);
        var particles = InstantiateFX(impactEffect, col.contacts[0].point, 1f);
        Destroy(particles, 1f);
    }

    void PerformInitialRoll()
    {
        ResetDiceState();
        resultText.text = "";

        Vector3 targetPosition = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        rb.AddForce(targetPosition * rollForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * torqueAmount, ForceMode.Impulse);

        audioSource.clip = shakeClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void MoveDiceToCenter()
    {
        transform.position = Vector3.SmoothDamp(transform.position, originPosition, ref currentVelocity, smoothTime, maxSpeed);

        if (originPosition.InRangeOf(transform.position, 0.1f))
        {
            FinalizeRoll();
        }
    }

    void FinalizeRoll()
    {
        rollTimer.Stop();
        finalize = false;
        ResetDiceState();

        audioSource.loop = false;
        audioSource.Stop();
        audioSource.PlayOneShot(finalResultClip);

        var particles = InstantiateFX(finalResultEffect, transform.position, 5f);
        Destroy(particles, 3f);

        int result = diceSides.GetMatch();
        Debug.Log($"Dice landed on {result}");

        if (result >= targetNumber)
        {
            resultText.text = $"Success! ({result})";
        }
        else
        {
            resultText.text = $"Fail! ({result})";
        }
    }

    void ResetDiceState()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originPosition;
    }

    GameObject InstantiateFX(GameObject fx, Vector3 position, float size)
    {
        var particles = Instantiate(fx, position, Quaternion.identity);
        particles.transform.localScale = Vector3.one * size;
        return particles;
    }
}
