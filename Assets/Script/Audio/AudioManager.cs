using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	#region Fields

	[Header("Audio Sources")]
	[Space]
	[SerializeField]
	protected AudioSource m_MusicAudioSource;
	[SerializeField]
	protected AudioSource m_ShootAudioSource;
	[SerializeField]
	protected AudioSource m_HitAudioSource;
	[SerializeField]
	protected AudioSource m_ButtonAudioSource;

	[Header("Music Clips")]
	[Space]
	[SerializeField]
	protected AudioClip m_MusicClip;

	[Header("Sound Clips")]
	[Space]
	[SerializeField]
	protected AudioClip m_ShootSound;
	[SerializeField]
	protected AudioClip m_HitSound;
	[SerializeField]
	protected AudioClip m_UIButtonSound;

	#endregion
	#region Methods

	public void PlayMusic()
	{
		m_MusicAudioSource.clip = m_MusicClip;
		m_MusicAudioSource.Play();
	}
	public void StopMusic()
    {
		m_MusicAudioSource.Stop();
	}
	public void PlaySoundOn(AudioSource audio, AudioClip clip)
	{
		audio.clip = clip;
		audio.Play();
	}

	public void PlayUIButtonSound()
	{
		PlaySoundOn(m_ButtonAudioSource, m_UIButtonSound);
	}

	public void PlayShootSound()
	{
		PlaySoundOn(m_ShootAudioSource, m_ShootSound);
	}
	public void PlayHitSound()
	{
		PlaySoundOn(m_HitAudioSource, m_HitSound);
	}

	#endregion

}