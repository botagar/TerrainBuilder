namespace NoiseGenerators
{
    public interface INoiseMap<T>
    {
        int Width();
        int Height();
        T[,] Data();
    }
}
