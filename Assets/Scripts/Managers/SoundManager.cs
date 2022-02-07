using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource[] _audioSource = new AudioSource[(int)Define.Sound.MaxCount];
    // MP3 Player -> AudioSource
    // Mp3 ���� -> AudioClip
    // ����(��) -> AudioListener

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);
            // �̰� ������� �ʴ� ������Ʈ�� ���鶧 ���. �� ���߽� �޸� ���� ���ϴ� ������ ��,

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for(int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSource[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }
            _audioSource[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Clear()
    {
        foreach(AudioSource audioSource in _audioSource)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }
    // �ϳ��� ������ �̿��� �ٸ� �������� Ż�ٲ޽�Ű��.
    // �ȿ� ����� �����ؼ� �����ϴٺ��� ������ ������ �߻��� ���̴�.
    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f) { 
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null) return;

        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSource[(int)Define.Sound.Bgm];

            if (audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }
            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {

            AudioSource audioSource = _audioSource[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }


    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{path}";
        }

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
            
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip))
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
            // ����Ʈ ������ ��� ���� ����ǰų� ���������� �ϱ� ������
            // ĳ���� �ȴٸ� �ſ� ȿ�����̴�.
        }

        if (audioClip == null)
        {
            Debug.Log($"AudioClip Missing ! {path}");
        }


        return audioClip;
    }

}
