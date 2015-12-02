using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Speech.Synthesis;

using Newtonsoft.Json;

namespace TimeSpeak
{
    class Program
    {
        static void Main(string[] args)
        {
            string sURL;
            sURL = "http://api.nytimes.com/svc/topstories/v1/yourAPIKey";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            wrGETURL.Proxy = WebProxy.GetDefaultProxy();
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string line = "";
            line = objReader.ReadLine();
            line = line.Replace("\"abstract\"","\"abstra\"");
            dynamic stories = JsonConvert.DeserializeObject<Rootobject>(line);
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();
                for (int i = 0; i < stories.num_results; i++)
                {
                    // Speak a string synchronously.
                    string number = i.ToString();
                    synth.Speak(number+ "\n" + stories.results[i].title);
                    synth.Speak(stories.results[i].abstra);
                }
            }
        }
    }
}
