using UnityEngine;

// SimpleSyncVolume.cs
// Author: Dave Arendash
// (c) 2012-2019 Quantum Leap Computing

[RequireComponent(typeof(AudioSource))]

public class SimpleSyncVolume : MonoBehaviour
{
	[HideInInspector]
	public float intensity;
	public enum Response { VeryFast = 0, Fast, Normal, Slow, VerySlow };
	[Tooltip("Responsiveness to volume variations")]
	public Response response = Response.Normal;
	[Tooltip("Use microphone instead of audio clip")]
	public bool useMicrophone = false;
	[Tooltip("Microphone sampling rate")]
	public int micSampleRate = 44100;
	[Tooltip("Seconds to record from microphone before processing (min = 1)")]
	public int lengthSeconds = 1;

	private int winWidth = 1024 * 8;
	private float[] samples;

    void Start()
	{
		SetResponse(response);
#if !UNITY_WEBGL
		if (useMicrophone)
		{
			GetComponent<AudioSource>().playOnAwake = false;
			if (lengthSeconds < 1)
				Debug.LogError("SimpleSync Microphone lengthSeconds must be at least 1");
			GetComponent<AudioSource>().clip = Microphone.Start("", true, lengthSeconds, micSampleRate);
			GetComponent<AudioSource>().Play();
		}
#endif
	}

	void SetResponse( Response r)
    {
	    response = r;
	    switch (r)
	    {
		    case Response.VeryFast:
			    winWidth = 1024;
			    break;
		    case Response.Fast:
			    winWidth = 1024*2;
			    break;
		    case Response.Normal:
			    winWidth = 1024 * 4;
			    break;
		    case Response.Slow:
			    winWidth = 1024*8;
			    break;
		    case Response.VerySlow:
			    winWidth = 1024*16;
			    break;
	    }
	    samples = new float[winWidth];
    }

    void Update ()
    {
	    if (!GetComponent<AudioSource>().isPlaying)
	    {
		    intensity = 0;
	    }
	    else
	    {
			float min = 10000000.0f;
			float max = -10000000.0f;
		    GetComponent<AudioSource>().GetOutputData (samples, 0);
		    float average = 0.0f;
		    for (var i = 0; i < winWidth; i++)
		    {
			    var abs = Mathf.Abs(samples[i]);
			    if (abs < min)
				    min = abs;
			    if (abs > max)
				    max = abs;
			    average += abs;
		    }
		    average /= winWidth;
		    intensity = average;
	    }
    }
}
