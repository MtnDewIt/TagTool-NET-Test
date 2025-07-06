namespace TagTool.Common
{
    public enum GameSimulationType : byte
    {
        None = 0,
        Local,
        SynchronousClient,
        SynchronousServer,
        DistributedClient,
        DistributedServer,
    }
}
