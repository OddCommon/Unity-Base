using System;
using System.Collections;
using System.Threading;
using OddCommon.Debug;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;


namespace OddCommon.Tests
{
    public class WorkerThreadLoggerTests
    {
        [UnityTest]
        public IEnumerator WorkerThreadThrownExceptionTest()
        {
            LogAssert.NoUnexpectedReceived();
            LogAssert.Expect(LogType.Log, "[OddCommon.Debug.WorkerThreadLogger] Setting first instance as single instance.");
            GameObject testGameObject =
                new GameObject
                (
                    "Test GameObject with WorkerThreadLogger",
                    typeof(WorkerThreadLogger)
                );
            yield return null;
            Thread testThread =
                new Thread(() => throw new Exception("Exception on worker thread."));
            LogAssert.Expect(LogType.Exception, "Exception: Exception on worker thread.");
            // We have to add a second exception log expect call because Unity, for some dumb ass
            // reason, has their own unhandled exception handler but ONLY if the iOS module is installed
            if (BuildPipeline.IsBuildTargetSupported(BuildTargetGroup.iOS, BuildTarget.iOS))
            {
                LogAssert.Expect(LogType.Exception, "Exception: Exception on worker thread.");   
            }
            testThread.Start();
            while (testThread.IsAlive)
            {
                yield return null;
            }
        }
    }
}
