using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LCSBenchmark : MonoBehaviour
{
    [SerializeField] private TextAsset _a;
    [SerializeField] private TextAsset _b;

    private void Start()
    {
        var stopwatch = Stopwatch.StartNew();
        var lcs = LCS.Find(_a.text, _b.text);
        Debug.Log($"LCS length: {lcs.Length} took: {stopwatch.ElapsedMilliseconds}ms");
    }
}