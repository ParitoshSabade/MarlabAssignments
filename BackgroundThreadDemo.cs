using System;
namespace TrainingProject
{
	public class BackgroundThreadDemo
	{
        private static readonly Dictionary<string, int> keyValueStore = new Dictionary<string, int>();
        

        static void Main()
        {
            
            Thread backgroundThread = new Thread(BackgroundWork);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

            // Sleep for 2 seconds to allow the background thread to set values
            Thread.Sleep(2000);

            
            
            foreach (var kvp in keyValueStore)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            
        }

        static void BackgroundWork()
        {
            
            
            keyValueStore["Key1"] = 10;
            keyValueStore["Key2"] = 29999;
            keyValueStore["Key3"] = 9876;
            
        }
    }
}

