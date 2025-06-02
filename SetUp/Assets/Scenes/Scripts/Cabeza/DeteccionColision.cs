using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColision : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)]
    private float _detectionDelay = 0.05f;

    [SerializeField]
    private float _detectionDistance = 0.2f;

    [Header("Tags a detectar")]
    [SerializeField]
    private string[] _detectionTags;

    public List<RaycastHit> DetectedColliderHits { get; private set; }

    private float _currentTime = 0;

    private List<RaycastHit> RealizarDeteccion(Vector3 posicion, float distancia)
    {
        List<RaycastHit> impactosDetectados = new();
        List<Vector3> direcciones = new() { transform.forward, transform.right, -transform.right };

        foreach (var dir in direcciones)
        {
            if (Physics.Raycast(posicion, dir, out RaycastHit hit, distancia))
            {
                if (_detectionTags == null || _detectionTags.Length == 0)
                {
                    impactosDetectados.Add(hit); // si no hay tags definidos, acepta todos
                }
                else
                {
                    foreach (var tag in _detectionTags)
                    {
                        if (hit.collider.CompareTag(tag))
                        {
                            impactosDetectados.Add(hit);
                            break;
                        }
                    }
                }
            }
        }

        return impactosDetectados;
    }

    private void Start()
    {
        DetectedColliderHits = RealizarDeteccion(transform.position, _detectionDistance);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _detectionDelay)
        {
            _currentTime = 0;
            DetectedColliderHits = RealizarDeteccion(transform.position, _detectionDistance);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Color color = DetectedColliderHits.Count > 0 ? new Color(1, 0, 0, 0.5f) : new Color(0, 1, 0, 0.5f);
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, _detectionDistance);

        Gizmos.color = Color.magenta;
        List<Vector3> direcciones = new() { transform.forward, transform.right, -transform.right };
        foreach (var dir in direcciones)
        {
            Gizmos.DrawRay(transform.position, dir * _detectionDistance);
        }
    }
}
