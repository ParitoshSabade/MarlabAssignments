using System;
using System.Collections.Generic;
using System.Threading;

class ThreadPoolDemo
{
    private static readonly Dictionary<string, int> keyValueStore = new Dictionary<string, int>();
    private static readonly object lockObject = new object();

    static void Main()
    {
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("set", "key1", 10));
        Thread.Sleep(1000);
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("get", "key1"));
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("set", "key2", 100));
        Thread.Sleep(1000);
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("get", "key2"));
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("get", "key2"));
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("set", "key2", 2000));
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("get", "key2"));
        ThreadPool.QueueUserWorkItem(KeyValueWorker, new KeyValueAction("get", "key2"));

        // Sleep to allow time for the thread pool tasks to complete
        Thread.Sleep(2000);


    }

    static void KeyValueWorker(object state)
    {
        KeyValueAction action = (KeyValueAction)state;
        if (action.Action == "set")
        {
            string result = KeyValueDatabase("set", action.Key, action.Value);
            Console.WriteLine(result);
        }
        else if (action.Action == "get")
        {
            string result = KeyValueDatabase("get", action.Key);
            Console.WriteLine($"Result of 'get {action.Key}': {result}");
        }
    }

    static string KeyValueDatabase(string action, string key, int value = 0)
    {
        lock (lockObject)
        {
            if (action == "set")
            {
                keyValueStore[key] = value;
                return $"Value({key},{value}) set successfully.";
            }
            else if (action == "get")
            {
                if (keyValueStore.ContainsKey(key))
                {
                    return keyValueStore[key].ToString();
                }
                else
                {
                    return "Key not found.";
                }
            }
            else
            {
                return "Invalid action.";
            }
        }
    }
}

class KeyValueAction
{
    public string Action { get; }
    public string Key { get; }
    public int Value { get; }

    public KeyValueAction(string action, string key, int value = 0)
    {
        Action = action;
        Key = key;
        Value = value;
    }
}
