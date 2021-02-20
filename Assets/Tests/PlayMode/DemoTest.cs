using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class DemoTest
    {
        [Test]
        public void DemoScoreUpdateTest()
        {
            GameObject go = new GameObject();
            ScoreController sc= go.AddComponent<ScoreController>();

            //setting text component
            Text sctext=go.AddComponent<Text>();
            sc.ScoreText = sctext;

            sc.TotalScore = 10;
            sc.RefreshScore(25);
            Assert.AreEqual(35, sc.TotalScore);

        }
    }
}
