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
    // 사운드를 동시에 틀면 동시에 여러개가 들린다....

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(audioClip); // 일단 무조건 틀고봐라.
        //코드는 오브젝트에 심지만 소리는 다른 위치에서 발생시키기
        //audio.PlayClipAtPoint(audioClip, new Vector3(0.1f, 0.1f, 0.1f)); 
        //audio.PlayOneShot(audioClip2);
        //float lifeTime = Mathf.Max(audioClip.length, audioClip2.length);
        //GameObject.Destroy(gameObject, lifeTime); // 만약 오디오가 출력되는 도중 지워지면 음악이 끊긴다.

        // 사운드도 경로형태로 데이터시트에 들어가기 때문에 이렇게 구현하는게 더 효율적
        if (i % 2 == 0)
        {
            Managers.Sound.Play(audioClip, Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play(audioClip2, Define.Sound.Bgm);
        }

    }

    // 캐릭터에 오디오 리스너를 추가하고싶을때 메인카메라의 오디오 리스너를 꺼야 에러가 발생하지 않는다.
    // 오디오 리스너는 반드시 1개만
}
