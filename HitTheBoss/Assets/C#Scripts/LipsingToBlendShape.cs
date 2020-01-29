using UnityEngine;
// SimpleSyncMove.cs
// Author: Dave Arendash
// (c) 2012-2019 Quantum Leap Computing

[RequireComponent(typeof(SimpleSyncVolume))]
public class LipsingToBlendShape : MonoBehaviour
{
	[Tooltip("GameObject representing 'mouth', or null if 'this' object")]
	public Transform mouth;
	[Tooltip("Scaling factor: larger for greater range of motion")]
	public float motionScale = 10.0f;
	[Tooltip("Lowest value, during silence")]
	public Vector3 rangeMinimum = Vector3.zero;
	[Tooltip("Highest value, during loudest sounds")]
	public Vector3 rangeMaximum = Vector3.down;

    public Vector3 valueAudio= new Vector3 ();

    private SimpleSyncVolume ssVolume;

	void Start()
	{
		ssVolume = GetComponent<SimpleSyncVolume>();
		if (!mouth)
			mouth = transform;
	}

	public void Update()
	{
		Vector3 val;
		Vector3 rng = rangeMaximum - rangeMinimum;
		//val = rng * ssVolume.intensity * motionScale + rangeMinimum;
		val = rng * ssVolume.intensity * motionScale + rangeMinimum;
		//mouth.localPosition = val;
        valueAudio = val;
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, Mathf.Abs(valueAudio.y * 500));
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Mathf.Abs(valueAudio.y * 500));


    }
}
