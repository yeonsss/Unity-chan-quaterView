using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public AudioClip audioClip;
    public AudioClip audioClip2;
    // ���带 ���ÿ� Ʋ�� ���ÿ� �������� �鸰��....

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(audioClip); // �ϴ� ������ Ʋ�����.
        //�ڵ�� ������Ʈ�� ������ �Ҹ��� �ٸ� ��ġ���� �߻���Ű��
        //audio.PlayClipAtPoint(audioClip, new Vector3(0.1f, 0.1f, 0.1f)); 
        //audio.PlayOneShot(audioClip2);
        //float lifeTime = Mathf.Max(audioClip.length, audioClip2.length);
        //GameObject.Destroy(gameObject, lifeTime); // ���� ������� ��µǴ� ���� �������� ������ �����.

        // ���嵵 ������·� �����ͽ�Ʈ�� ���� ������ �̷��� �����ϴ°� �� ȿ����
        if (i % 2 == 0)
        {
            Managers.Sound.Play(audioClip, Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play(audioClip2, Define.Sound.Bgm);
        }

    }

    // ĳ���Ϳ� ����� �����ʸ� �߰��ϰ������ ����ī�޶��� ����� �����ʸ� ���� ������ �߻����� �ʴ´�.
    // ����� �����ʴ� �ݵ�� 1����
}
