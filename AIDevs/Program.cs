using AIDevs.Helpers;

var keys = ApiKeysHelper.Get();
Environment.SetEnvironmentVariable("AI_DEVS_API_KEY", keys.Item1);
Environment.SetEnvironmentVariable("OPENAI_API_KEY", keys.Item2);

var task = new S02E01Helper();
await task.ResolveTask();