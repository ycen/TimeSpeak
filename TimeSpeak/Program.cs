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
            sURL = "http://api.nytimes.com/svc/topstories/v1/world.json?api-key=e40918abbccbb231b9558826929ef1a6:6:69444533";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            wrGETURL.Proxy = WebProxy.GetDefaultProxy();
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string line = "";
            line = objReader.ReadLine();
            line = line.Replace("\"abstract\"","\"abstra\"");
            //Console.WriteLine(line);
            dynamic stories = JsonConvert.DeserializeObject<Rootobject>(line);
            //int nlist = stories.results.length;
            //string abs = stories.results[0].abstra;
            //Console.WriteLine(abs);
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
