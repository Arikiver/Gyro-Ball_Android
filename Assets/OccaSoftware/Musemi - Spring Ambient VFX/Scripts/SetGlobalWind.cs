using System.Collections;
using UnityEngine;

namespace OccaSoftware.Musemi
{
    // This MonoBehaviour should be assigned to the object that should be treated as the Wind Controller.
    // The forward vector of this object will set the Wind Direction.

    [ExecuteAlways]
    public class SetGlobalWind : MonoBehaviour
    {
        [SerializeField, Min(0), Tooltip("Main  Wind Speed. Global wind will never go below this value. Default: 1m/s.")] private float windSpeed = 1f;
        [SerializeField, Min(0), Tooltip("Maximum additional wind speed. Global wind will never exceed Wind Speed + Wind Variation. Default: 0.5m/s.")] private float windVariation = 0.5f;
        [SerializeField, Min(0), Tooltip("Frequency at which wind variation changes over time. Default: 2hz.")] private float windFrequency = 2f;
        [SerializeField, Min(0), Tooltip("How many times per second to update global wind velocity. Default: 30hz.")] private float refreshRate = 30f;
        private float refreshTiming = 0f;

        private Vector3 windDirection = Vector3.zero;
        private float windSpeedTurbulent = 0f;
        private Vector3 windVelocity = Vector3.zero;

        private void OnEnable()
        {
            refreshTiming = 1.0f / refreshRate;
            StartCoroutine(UpdateWindVelocity());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator UpdateWindVelocity()
        {
            while (true)
            {
                float noise = Mathf.Clamp01(Mathf.PerlinNoise(Time.time * windFrequency, 0f));
                noise *= windVariation;
                windDirection = transform.rotation * Vector3.forward;
                windSpeedTurbulent = windSpeed + noise;
                windVelocity = windDirection * (windSpeedTurbulent);
                yield return new WaitForSeconds(refreshTiming);
            }
        }

        public Vector3 GetGlobalWindVelocity()
        {
            return windVelocity;
        }


        // We draw some additional Gizmos in Editor to help provide information about wind speed and direction.
        private void OnDrawGizmos()
        {
            Vector3 target = transform.position + (transform.forward * windSpeedTurbulent);
            Gizmos.DrawLine(transform.position, target);
            Gizmos.DrawLine(target, target - (Vector3.up * 0.05f));
            Gizmos.DrawLine(target, target + (Vector3.up * 0.05f));
            Gizmos.DrawLine(transform.position - (transform.right * 0.2f), transform.position + (transform.right * 0.2f));
            Gizmos.DrawLine(transform.position - (transform.up * 0.2f), transform.position + (transform.up * 0.2f));
        }
    }
}