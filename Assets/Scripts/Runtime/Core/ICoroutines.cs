using System.Collections;
using UnityEngine;

namespace Client.Runtime
{
    public interface ICoroutines
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}